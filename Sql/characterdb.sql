/*
Navicat MySQL Data Transfer

Source Server         : local
Source Server Version : 50519
Source Host           : localhost:3306
Source Database       : characters

Target Server Type    : MYSQL
Target Server Version : 50519
File Encoding         : 65001

Date: 2012-10-30 02:41:57
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `characters`
-- ----------------------------
DROP TABLE IF EXISTS `characters`;
CREATE TABLE `characters` (
  `guid` bigint(20) NOT NULL AUTO_INCREMENT,
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
INSERT INTO `character_creation_data` VALUES ('1', '1', '0', '9', '-8914.57', '-133.909', '80.5378', '5.13806');
INSERT INTO `character_creation_data` VALUES ('1', '2', '0', '9', '-8914.57', '-133.909', '80.5378', '5.13806');
INSERT INTO `character_creation_data` VALUES ('1', '3', '0', '9', '-8914.57', '-133.909', '80.5378', '5.13806');
INSERT INTO `character_creation_data` VALUES ('1', '4', '0', '9', '-8914.57', '-133.909', '80.5378', '5.13806');
INSERT INTO `character_creation_data` VALUES ('1', '5', '0', '9', '-8914.57', '-133.909', '80.5378', '5.13806');
INSERT INTO `character_creation_data` VALUES ('1', '8', '0', '9', '-8914.57', '-133.909', '80.5378', '5.13806');
INSERT INTO `character_creation_data` VALUES ('1', '9', '0', '9', '-8914.57', '-133.909', '80.5378', '5.13806');
INSERT INTO `character_creation_data` VALUES ('1', '10', '0', '9', '-8914.57', '-133.909', '80.5378', '5.13806');
INSERT INTO `character_creation_data` VALUES ('2', '1', '1', '14', '-618.518', '-4251.67', '38.718', '4.72222');
INSERT INTO `character_creation_data` VALUES ('2', '3', '1', '14', '-618.518', '-4251.67', '38.718', '4.72222');
INSERT INTO `character_creation_data` VALUES ('2', '4', '1', '14', '-618.518', '-4251.67', '38.718', '4.72222');
INSERT INTO `character_creation_data` VALUES ('2', '7', '1', '14', '-618.518', '-4251.67', '38.718', '4.72222');
INSERT INTO `character_creation_data` VALUES ('2', '8', '1', '14', '-618.518', '-4251.67', '38.718', '4.72222');
INSERT INTO `character_creation_data` VALUES ('2', '9', '1', '14', '-618.518', '-4251.67', '38.718', '4.72222');
INSERT INTO `character_creation_data` VALUES ('2', '10', '1', '14', '-618.518', '-4251.67', '38.718', '4.72222');
INSERT INTO `character_creation_data` VALUES ('3', '1', '0', '1', '-6230', '330', '383', '0');
INSERT INTO `character_creation_data` VALUES ('3', '2', '0', '1', '-6230', '330', '383', '0');
INSERT INTO `character_creation_data` VALUES ('3', '3', '0', '1', '-6230', '330', '383', '0');
INSERT INTO `character_creation_data` VALUES ('3', '4', '0', '1', '-6230', '330', '383', '0');
INSERT INTO `character_creation_data` VALUES ('3', '5', '0', '1', '-6230', '330', '383', '0');
INSERT INTO `character_creation_data` VALUES ('3', '7', '0', '1', '-6230', '330', '383', '0');
INSERT INTO `character_creation_data` VALUES ('3', '8', '0', '1', '-6230', '330', '383', '0');
INSERT INTO `character_creation_data` VALUES ('3', '9', '0', '1', '-6230', '330', '383', '0');
INSERT INTO `character_creation_data` VALUES ('3', '10', '0', '1', '-6230', '330', '383', '0');
INSERT INTO `character_creation_data` VALUES ('4', '1', '1', '141', '10311.3', '831.463', '1326.57', '5.48033');
INSERT INTO `character_creation_data` VALUES ('4', '3', '1', '141', '10311.3', '831.463', '1326.57', '5.48033');
INSERT INTO `character_creation_data` VALUES ('4', '4', '1', '141', '10311.3', '831.463', '1326.57', '5.48033');
INSERT INTO `character_creation_data` VALUES ('4', '5', '1', '141', '10311.3', '831.463', '1326.57', '5.48033');
INSERT INTO `character_creation_data` VALUES ('4', '8', '1', '141', '10311.3', '831.463', '1326.57', '5.48033');
INSERT INTO `character_creation_data` VALUES ('4', '10', '1', '141', '10311.3', '831.463', '1326.57', '5.48033');
INSERT INTO `character_creation_data` VALUES ('4', '11', '1', '141', '10311.3', '831.463', '1326.57', '5.48033');
INSERT INTO `character_creation_data` VALUES ('5', '1', '0', '85', '1699.85', '1706.56', '135.928', '4.88839');
INSERT INTO `character_creation_data` VALUES ('5', '3', '0', '85', '1699.85', '1706.56', '135.928', '4.88839');
INSERT INTO `character_creation_data` VALUES ('5', '4', '0', '85', '1699.85', '1706.56', '135.928', '4.88839');
INSERT INTO `character_creation_data` VALUES ('5', '5', '0', '85', '1699.85', '1706.56', '135.928', '4.88839');
INSERT INTO `character_creation_data` VALUES ('5', '8', '0', '85', '1699.85', '1706.56', '135.928', '4.88839');
INSERT INTO `character_creation_data` VALUES ('5', '9', '0', '85', '1699.85', '1706.56', '135.928', '4.88839');
INSERT INTO `character_creation_data` VALUES ('5', '10', '0', '85', '1699.85', '1706.56', '135.928', '4.88839');
INSERT INTO `character_creation_data` VALUES ('6', '1', '1', '215', '-2915.55', '-257.347', '59.2693', '0.302378');
INSERT INTO `character_creation_data` VALUES ('6', '2', '1', '215', '-2915.55', '-257.347', '59.2693', '0.302378');
INSERT INTO `character_creation_data` VALUES ('6', '3', '1', '215', '-2915.55', '-257.347', '59.2693', '0.302378');
INSERT INTO `character_creation_data` VALUES ('6', '5', '1', '215', '-2915.55', '-257.347', '59.2693', '0.302378');
INSERT INTO `character_creation_data` VALUES ('6', '7', '1', '215', '-2915.55', '-257.347', '59.2693', '0.302378');
INSERT INTO `character_creation_data` VALUES ('6', '10', '1', '215', '-2915.55', '-257.347', '59.2693', '0.302378');
INSERT INTO `character_creation_data` VALUES ('6', '11', '1', '215', '-2915.55', '-257.347', '59.2693', '0.302378');
INSERT INTO `character_creation_data` VALUES ('7', '1', '0', '1', '-4983.42', '877.7', '274.31', '3.06393');
INSERT INTO `character_creation_data` VALUES ('7', '4', '0', '1', '-4983.42', '877.7', '274.31', '3.06393');
INSERT INTO `character_creation_data` VALUES ('7', '5', '0', '1', '-4983.42', '877.7', '274.31', '3.06393');
INSERT INTO `character_creation_data` VALUES ('7', '8', '0', '1', '-4983.42', '877.7', '274.31', '3.06393');
INSERT INTO `character_creation_data` VALUES ('7', '9', '0', '1', '-4983.42', '877.7', '274.31', '3.06393');
INSERT INTO `character_creation_data` VALUES ('7', '10', '0', '1', '-4983.42', '877.7', '274.31', '3.06393');
INSERT INTO `character_creation_data` VALUES ('8', '1', '1', '14', '-1171.45', '-5263.65', '0.847728', '5.78945');
INSERT INTO `character_creation_data` VALUES ('8', '3', '1', '14', '-1171.45', '-5263.65', '0.847728', '5.78945');
INSERT INTO `character_creation_data` VALUES ('8', '4', '1', '14', '-1171.45', '-5263.65', '0.847728', '5.78945');
INSERT INTO `character_creation_data` VALUES ('8', '5', '1', '14', '-1171.45', '-5263.65', '0.847728', '5.78945');
INSERT INTO `character_creation_data` VALUES ('8', '7', '1', '14', '-1171.45', '-5263.65', '0.847728', '5.78945');
INSERT INTO `character_creation_data` VALUES ('8', '8', '1', '14', '-1171.45', '-5263.65', '0.847728', '5.78945');
INSERT INTO `character_creation_data` VALUES ('8', '9', '1', '14', '-1171.45', '-5263.65', '0.847728', '5.78945');
INSERT INTO `character_creation_data` VALUES ('8', '10', '1', '14', '-1171.45', '-5263.65', '0.847728', '5.78945');
INSERT INTO `character_creation_data` VALUES ('8', '11', '1', '14', '-1171.45', '-5263.65', '0.847728', '5.78945');
INSERT INTO `character_creation_data` VALUES ('9', '1', '648', '4737', '-8423.81', '1361.3', '104.671', '1.55428');
INSERT INTO `character_creation_data` VALUES ('9', '3', '648', '4737', '-8423.81', '1361.3', '104.671', '1.55428');
INSERT INTO `character_creation_data` VALUES ('9', '4', '648', '4737', '-8423.81', '1361.3', '104.671', '1.55428');
INSERT INTO `character_creation_data` VALUES ('9', '5', '648', '4737', '-8423.81', '1361.3', '104.671', '1.55428');
INSERT INTO `character_creation_data` VALUES ('9', '7', '648', '4737', '-8423.81', '1361.3', '104.671', '1.55428');
INSERT INTO `character_creation_data` VALUES ('9', '8', '648', '4737', '-8423.81', '1361.3', '104.671', '1.55428');
INSERT INTO `character_creation_data` VALUES ('9', '9', '648', '4737', '-8423.81', '1361.3', '104.671', '1.55428');
INSERT INTO `character_creation_data` VALUES ('10', '1', '530', '3430', '10349.6', '-6357.29', '33.4026', '5.31605');
INSERT INTO `character_creation_data` VALUES ('10', '2', '530', '3430', '10349.6', '-6357.29', '33.4026', '5.31605');
INSERT INTO `character_creation_data` VALUES ('10', '3', '530', '3430', '10349.6', '-6357.29', '33.4026', '5.31605');
INSERT INTO `character_creation_data` VALUES ('10', '4', '530', '3430', '10349.6', '-6357.29', '33.4026', '5.31605');
INSERT INTO `character_creation_data` VALUES ('10', '5', '530', '3430', '10349.6', '-6357.29', '33.4026', '5.31605');
INSERT INTO `character_creation_data` VALUES ('10', '8', '530', '3430', '10349.6', '-6357.29', '33.4026', '5.31605');
INSERT INTO `character_creation_data` VALUES ('10', '9', '530', '3430', '10349.6', '-6357.29', '33.4026', '5.31605');
INSERT INTO `character_creation_data` VALUES ('10', '10', '530', '3430', '10349.6', '-6357.29', '33.4026', '5.31605');
INSERT INTO `character_creation_data` VALUES ('11', '1', '530', '3524', '-3961.64', '-13931.2', '100.615', '2.08364');
INSERT INTO `character_creation_data` VALUES ('11', '2', '530', '3524', '-3961.64', '-13931.2', '100.615', '2.08364');
INSERT INTO `character_creation_data` VALUES ('11', '3', '530', '3524', '-3961.64', '-13931.2', '100.615', '2.08364');
INSERT INTO `character_creation_data` VALUES ('11', '5', '530', '3524', '-3961.64', '-13931.2', '100.615', '2.08364');
INSERT INTO `character_creation_data` VALUES ('11', '7', '530', '3524', '-3961.64', '-13931.2', '100.615', '2.08364');
INSERT INTO `character_creation_data` VALUES ('11', '8', '530', '3524', '-3961.64', '-13931.2', '100.615', '2.08364');
INSERT INTO `character_creation_data` VALUES ('11', '10', '530', '3524', '-3961.64', '-13931.2', '100.615', '2.08364');
INSERT INTO `character_creation_data` VALUES ('22', '1', '654', '4714', '-1451.53', '1403.35', '35.5561', '0.333847');
INSERT INTO `character_creation_data` VALUES ('22', '3', '654', '4714', '-1451.53', '1403.35', '35.5561', '0.333847');
INSERT INTO `character_creation_data` VALUES ('22', '4', '654', '4714', '-1451.53', '1403.35', '35.5561', '0.333847');
INSERT INTO `character_creation_data` VALUES ('22', '5', '654', '4714', '-1451.53', '1403.35', '35.5561', '0.333847');
INSERT INTO `character_creation_data` VALUES ('22', '8', '654', '4714', '-1451.53', '1403.35', '35.5561', '0.333847');
INSERT INTO `character_creation_data` VALUES ('22', '9', '654', '4714', '-1451.53', '1403.35', '35.5561', '0.333847');
INSERT INTO `character_creation_data` VALUES ('22', '11', '654', '4714', '-1451.53', '1403.35', '35.5561', '0.333847');
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
INSERT INTO `character_creation_spells` VALUES ('1', '1', '78', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '81', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '107', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '196', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '197', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '198', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '199', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '200', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '201', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '202', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '203', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '204', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '227', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '264', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '266', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '522', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '668', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '1180', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '2382', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '2457', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '3050', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '3127', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '3365', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '5011', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '5301', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '6233', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '6246', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '6247', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '6477', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '6478', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '6603', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '7266', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '7267', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '7355', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '8386', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '9077', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '9078', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '9116', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '9125', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '15590', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '20597', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '20598', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '20599', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '20864', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '21651', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '21652', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '22027', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '22810', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '32215', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '45927', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '59752', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '61437', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '68398', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '76268', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '76290', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '79738', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '88163', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '96220', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '110506', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '114585', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '115043', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '119811', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '122475', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '123829', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '128217', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '132334', null);
INSERT INTO `character_creation_spells` VALUES ('1', '1', '134732', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '78', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '81', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '107', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '196', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '197', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '198', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '199', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '200', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '201', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '202', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '203', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '204', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '227', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '264', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '266', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '522', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '669', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '1180', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '2382', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '2457', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '3050', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '3127', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '3365', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '5011', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '5301', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '6233', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '6246', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '6247', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '6477', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '6478', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '6603', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '7266', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '7267', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '7355', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '8386', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '9077', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '9078', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '9116', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '9125', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '15590', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '20572', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '20573', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '20574', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '21563', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '21651', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '21652', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '22027', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '22810', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '32215', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '45927', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '61437', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '68398', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '76268', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '76290', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '79743', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '88163', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '96220', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '110506', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '114585', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '115043', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '119811', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '122475', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '123829', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '128217', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '132334', null);
INSERT INTO `character_creation_spells` VALUES ('2', '1', '134732', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '78', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '81', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '107', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '196', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '197', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '198', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '199', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '200', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '201', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '202', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '203', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '204', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '227', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '264', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '266', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '522', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '668', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '672', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '1180', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '2382', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '2457', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '3050', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '3127', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '3365', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '5011', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '5301', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '6233', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '6246', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '6247', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '6477', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '6478', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '6603', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '7266', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '7267', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '7355', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '8386', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '9077', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '9078', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '9116', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '9125', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '15590', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '20594', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '20595', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '20596', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '21651', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '21652', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '22027', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '22810', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '32215', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '45927', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '59224', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '61437', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '68398', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '76268', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '76290', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '79739', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '88163', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '92682', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '96220', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '110506', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '114585', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '115043', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '119811', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '122475', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '123829', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '128217', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '132334', null);
INSERT INTO `character_creation_spells` VALUES ('3', '1', '134732', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '81', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '198', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '199', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '200', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '203', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '204', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '227', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '522', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '668', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '671', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '1180', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '2382', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '3050', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '3365', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '5176', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '6233', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '6246', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '6247', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '6477', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '6478', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '6603', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '7266', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '7267', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '7355', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '8386', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '9077', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '9078', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '9125', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '15590', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '20582', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '20583', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '20585', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '21009', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '21651', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '21652', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '22027', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '22810', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '45927', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '58984', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '61437', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '68398', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '76252', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '76275', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '76300', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '96220', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '114585', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '115043', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '132334', null);
INSERT INTO `character_creation_spells` VALUES ('4', '11', '134732', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '81', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '196', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '198', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '201', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '203', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '204', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '264', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '266', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '522', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '669', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '674', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '1180', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '1752', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '2382', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '3050', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '3365', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '5011', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '5227', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '6233', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '6246', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '6247', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '6477', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '6478', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '6603', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '7266', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '7267', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '7355', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '7744', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '8386', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '9077', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '9078', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '9125', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '15590', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '17737', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '20577', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '20579', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '21651', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '21652', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '22027', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '22810', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '45927', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '61437', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '68398', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '76273', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '76297', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '79747', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '82245', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '96220', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '110503', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '114585', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '115043', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '121733', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '132334', null);
INSERT INTO `character_creation_spells` VALUES ('5', '4', '134732', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '81', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '107', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '196', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '197', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '198', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '199', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '203', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '204', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '227', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '403', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '522', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '669', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '670', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '1180', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '2382', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '3050', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '3365', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '6233', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '6246', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '6247', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '6477', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '6478', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '6603', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '7266', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '7267', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '7355', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '8386', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '9077', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '9078', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '9116', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '9125', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '15590', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '20549', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '20550', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '20551', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '20552', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '21651', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '21652', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '22027', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '22810', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '45927', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '61437', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '68398', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '76272', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '76296', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '79746', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '96220', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '110504', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '114585', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '115043', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '123831', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '132334', null);
INSERT INTO `character_creation_spells` VALUES ('6', '7', '134732', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '81', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '201', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '203', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '204', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '227', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '522', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '668', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '686', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '688', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '1180', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '2382', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '3050', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '3365', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '5009', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '5019', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '6233', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '6246', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '6247', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '6477', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '6478', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '6603', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '7266', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '7267', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '7340', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '7355', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '8386', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '9078', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '9125', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '20589', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '20591', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '20592', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '20593', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '21651', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '21652', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '22027', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '22810', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '45927', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '61437', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '68398', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '76277', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '76299', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '79740', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '87330', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '92680', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '96220', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '110505', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '114190', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '114585', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '115043', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '121688', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '132334', null);
INSERT INTO `character_creation_spells` VALUES ('7', '9', '134732', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '81', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '107', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '196', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '197', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '198', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '199', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '203', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '204', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '227', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '403', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '522', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '669', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '1180', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '2382', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '3050', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '3365', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '6233', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '6246', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '6247', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '6477', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '6478', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '6603', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '7266', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '7267', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '7341', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '7355', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '8386', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '9077', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '9078', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '9116', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '9125', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '15590', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '20555', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '20557', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '21651', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '21652', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '22027', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '22810', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '26290', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '26297', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '45927', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '58943', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '61437', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '68398', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '76272', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '76296', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '79744', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '96220', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '110504', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '114585', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '115043', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '123831', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '132334', null);
INSERT INTO `character_creation_spells` VALUES ('8', '7', '134732', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '81', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '196', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '198', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '201', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '203', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '204', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '264', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '266', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '522', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '669', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '674', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '1180', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '1752', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '2382', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '3050', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '3365', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '5011', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '6233', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '6246', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '6247', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '6477', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '6478', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '6603', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '7266', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '7267', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '7355', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '8386', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '9077', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '9078', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '9125', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '15590', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '21651', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '21652', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '22027', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '22810', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '45927', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '61437', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '68398', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '69041', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '69042', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '69044', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '69045', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '69070', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '69269', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '76273', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '76297', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '79749', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '82245', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '96220', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '110503', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '114585', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '115043', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '121733', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '132334', null);
INSERT INTO `character_creation_spells` VALUES ('9', '4', '134732', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '81', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '201', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '203', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '204', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '227', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '522', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '669', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '813', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '822', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '1180', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '2382', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '3050', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '3365', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '5009', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '5019', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '6233', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '6246', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '6247', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '6477', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '6478', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '6603', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '7266', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '7267', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '7355', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '8386', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '9078', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '9125', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '21651', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '21652', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '22027', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '22810', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '28730', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '28877', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '44614', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '45927', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '61437', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '68398', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '76276', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '76298', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '79748', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '96220', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '110499', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '113857', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '114585', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '114995', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '115043', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '121039', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '132334', null);
INSERT INTO `character_creation_spells` VALUES ('10', '8', '134732', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '81', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '107', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '196', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '197', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '198', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '199', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '200', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '201', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '202', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '203', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '204', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '522', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '668', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '2382', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '3050', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '3365', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '6233', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '6246', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '6247', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '6477', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '6478', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '6562', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '6603', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '7266', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '7267', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '7355', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '8386', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '9077', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '9078', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '9116', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '9125', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '21651', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '21652', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '22027', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '22810', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '28875', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '29932', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '35395', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '45927', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '59535', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '59542', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '61437', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '68398', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '76271', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '76294', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '79741', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '82242', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '96220', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '110501', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '114585', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '115043', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '119811', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '123830', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '132334', null);
INSERT INTO `character_creation_spells` VALUES ('11', '2', '134732', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '81', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '201', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '203', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '204', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '227', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '522', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '668', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '1180', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '2382', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '3050', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '3365', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '5009', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '5019', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '6233', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '6246', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '6247', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '6477', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '6478', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '6603', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '7266', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '7267', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '7355', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '8386', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '9078', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '9125', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '21651', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '21652', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '22027', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '22810', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '44614', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '45927', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '61437', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '68398', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '69001', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '76276', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '76298', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '79742', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '96220', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '110499', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '113857', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '114585', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '114995', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '115043', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '121039', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '132334', null);
INSERT INTO `character_creation_spells` VALUES ('22', '8', '134732', null);
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
  `guid` bigint(20) NOT NULL,
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
  `guid` bigint(20) unsigned NOT NULL DEFAULT '0',
  `spellId` int(11) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`guid`,`spellId`),
  KEY `Idx_spell` (`spellId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC COMMENT='Player System';

-- ----------------------------
-- Records of character_spells
-- ----------------------------
