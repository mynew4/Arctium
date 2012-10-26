/*
Navicat MySQL Data Transfer

Source Server         : local
Source Server Version : 50519
Source Host           : localhost:3306
Source Database       : characters

Target Server Type    : MYSQL
Target Server Version : 50519
File Encoding         : 65001

Date: 2012-10-27 00:31:32
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `characters`
-- ----------------------------
DROP TABLE IF EXISTS `characters`;
CREATE TABLE `characters` (
  `guid` int(10) NOT NULL AUTO_INCREMENT,
  `accountid` int(5) NOT NULL DEFAULT '0',
  `name` varchar(255) DEFAULT NULL,
  `race` tinyint(4) NOT NULL DEFAULT '0',
  `class` tinyint(4) NOT NULL DEFAULT '0',
  `gender` tinyint(4) NOT NULL DEFAULT '0',
  `skin` tinyint(4) NOT NULL DEFAULT '0',
  `face` tinyint(4) NOT NULL DEFAULT '0',
  `hairStyle` tinyint(4) NOT NULL DEFAULT '0',
  `hairColor` tinyint(4) NOT NULL DEFAULT '0',
  `facialHair` tinyint(4) NOT NULL DEFAULT '0',
  `level` tinyint(4) NOT NULL DEFAULT '1',
  `zone` int(11) NOT NULL DEFAULT '0',
  `map` int(11) NOT NULL DEFAULT '0',
  `x` float NOT NULL DEFAULT '0',
  `y` float NOT NULL DEFAULT '0',
  `z` float NOT NULL DEFAULT '0',
  `o` float NOT NULL DEFAULT '0',
  `guildGuid` int(10) NOT NULL DEFAULT '0',
  `petDisplayId` int(11) NOT NULL DEFAULT '0',
  `petLevel` int(11) NOT NULL DEFAULT '0',
  `petFamily` int(11) NOT NULL DEFAULT '0',
  `characterFlags` int(11) NOT NULL DEFAULT '0',
  `customizeFlags` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`guid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of characters
-- ----------------------------

-- ----------------------------
-- Table structure for `character_creation_data`
-- ----------------------------
DROP TABLE IF EXISTS `character_creation_data`;
CREATE TABLE `character_creation_data` (
  `race` tinyint(4) NOT NULL,
  `class` tinyint(4) NOT NULL,
  `map` smallint(6) NOT NULL,
  `zone` smallint(6) NOT NULL,
  `posX` float NOT NULL,
  `posY` float NOT NULL,
  `posZ` float NOT NULL,
  `posO` float NOT NULL,
  PRIMARY KEY (`race`,`class`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of character_creation_data
-- ----------------------------
INSERT INTO `character_creation_data` VALUES ('24', '1', '860', '5736', '1471.67', '3466.25', '181.675', '2.77359');
INSERT INTO `character_creation_data` VALUES ('24', '3', '860', '5736', '1471.67', '3466.25', '181.675', '2.77359');
INSERT INTO `character_creation_data` VALUES ('24', '4', '860', '5736', '1471.67', '3466.25', '181.675', '2.77359');
INSERT INTO `character_creation_data` VALUES ('24', '5', '860', '5736', '1471.67', '3466.25', '181.675', '2.77359');
INSERT INTO `character_creation_data` VALUES ('24', '7', '860', '5736', '1471.67', '3466.25', '181.675', '2.77359');
INSERT INTO `character_creation_data` VALUES ('24', '8', '860', '5736', '1471.67', '3466.25', '181.675', '2.77359');
INSERT INTO `character_creation_data` VALUES ('24', '10', '860', '5736', '1471.67', '3466.25', '181.675', '2.77359');

-- ----------------------------
-- Table structure for `character_creation_skills`
-- ----------------------------
DROP TABLE IF EXISTS `character_creation_skills`;
CREATE TABLE `character_creation_skills` (
  `race` tinyint(4) NOT NULL,
  `class` tinyint(4) NOT NULL,
  `skill` int(6) NOT NULL,
  `skillName` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`race`,`class`,`skill`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of character_creation_skills
-- ----------------------------
INSERT INTO `character_creation_skills` VALUES ('24', '10', '905', 'Pandaren Neutral');

-- ----------------------------
-- Table structure for `character_creation_spells`
-- ----------------------------
DROP TABLE IF EXISTS `character_creation_spells`;
CREATE TABLE `character_creation_spells` (
  `race` tinyint(4) NOT NULL,
  `class` tinyint(4) NOT NULL,
  `spellId` int(6) NOT NULL,
  `spellName` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`race`,`class`,`spellId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of character_creation_spells
-- ----------------------------
INSERT INTO `character_creation_spells` VALUES ('24', '10', '81', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '196', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '198', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '200', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '201', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '203', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '204', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '227', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '522', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '2382', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '3050', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '3365', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '6233', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '6246', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '6247', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '6477', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '6478', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '6603', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '7266', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '7267', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '7355', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '8386', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '9077', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '9078', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '9125', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '15590', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '21651', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '21652', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '22027', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '22810', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '45927', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '61437', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '68398', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '96220', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '100780', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '103985', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '106902', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '106904', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '107072', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '107073', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '107074', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '107076', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '107079', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '107500', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '108127', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '108562', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '108977', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '110500', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '114585', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '115043', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '115074', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '115612', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '116812', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '119650', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '120272', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '120275', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '120277', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '128678', '');
INSERT INTO `character_creation_spells` VALUES ('24', '10', '131701', '');

-- ----------------------------
-- Table structure for `character_skills`
-- ----------------------------
DROP TABLE IF EXISTS `character_skills`;
CREATE TABLE `character_skills` (
  `guid` int(11) NOT NULL,
  `skill` int(5) NOT NULL,
  `skillLevel` mediumint(9) NOT NULL DEFAULT '0',
  PRIMARY KEY (`guid`,`skill`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of character_skills
-- ----------------------------

-- ----------------------------
-- Table structure for `character_spells`
-- ----------------------------
DROP TABLE IF EXISTS `character_spells`;
CREATE TABLE `character_spells` (
  `guid` int(11) unsigned NOT NULL DEFAULT '0',
  `spellId` int(11) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`guid`,`spellId`),
  KEY `Idx_spell` (`spellId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC COMMENT='Player System';

-- ----------------------------
-- Records of character_spells
-- ----------------------------
