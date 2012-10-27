/*
 * Copyright (C) 2012 Arctium <http://>
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using Framework.Database;
using Framework.Singleton;
using WorldServer.Game.WorldEntities;

namespace WorldServer.Game.Managers
{
    public class SkillManager : SingletonBase<SkillManager>
    {
        SkillManager() { }

        public void LoadSkills(Character pChar)
        {
            SQLResult result = DB.Characters.Select("SELECT * FROM character_skills WHERE guid = {0} ORDER BY skill ASC", pChar.Guid);

            if (result.Count == 0)
            {
                result = DB.Characters.Select("SELECT skill FROM character_creation_skills WHERE race = {0} AND class = {1} ORDER BY skill ASC", pChar.Race, pChar.Class);

                for (int i = 0; i < result.Count; i++)
                    AddSkill(pChar, result.Read<uint>(i, "skill"));

                SaveSkills(pChar);
            }
            else
            {
                for (int i = 0; i < result.Count; i++)
                    AddSkill(pChar, result.Read<uint>(i, "skill"));
            }
        }

        public void SaveSkills(Character pChar)
        {
            pChar.Skills.ForEach(skill =>
                DB.Characters.Execute("INSERT INTO character_skills (guid, skill) VALUES ({0}, {1})", pChar.Guid, skill.Id));
        }

        public void AddSkill(Character pChar, uint skillId, uint skillLevel = 0)
        {
            Skill skill = new Skill()
            {
                Id         = skillId,
                SkillLevel = skillLevel,
            };

            pChar.Skills.Add(skill);
        }
    }
}
