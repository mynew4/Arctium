using Framework.Database;
using Framework.Singleton;
using WorldServer.Game.WorldEntities;
using Framework.DBC;

namespace WorldServer.Game.Managers
{
    public sealed class SpellManager : SingletonBase<SpellManager>
    {
        SpellManager() { }

        public void LoadSpells(Character pChar)
        {
            SQLResult result = DB.Characters.Select("SELECT * FROM character_spells WHERE guid = {0} ORDER BY spellId ASC", pChar.Guid);

            if (result.Count == 0)
            {
                result = DB.Characters.Select("SELECT spellId FROM character_creation_spells WHERE race = {0} AND class = {1} ORDER BY spellId ASC", pChar.Race, pChar.Class);

                for (int i = 0; i < result.Count; i++)
                    AddSpell(pChar, result.Read<uint>(i, "spellId"));

                SaveSpells(pChar);
            }
            else
            {
                for (int i = 0; i < result.Count; i++)
                    AddSpell(pChar, result.Read<uint>(i, "spellId"));
            }
        }

        public void SaveSpells(Character pChar)
        {
            pChar.SpellList.ForEach(spell =>
                DB.Characters.Execute("INSERT INTO character_spells (guid, spellId) VALUES ({0}, {1})", pChar.Guid, spell.SpellId));
        }

        public void AddSpell(Character pChar, uint spellId)
        {
            PlayerSpell newspell = new PlayerSpell()
            {
                SpellId = spellId,
                State = PlayerSpellState.Unchanged,
                Dependent = false,
            };

            pChar.SpellList.Add(newspell);
        }        
    }
}
