/*
Navicat MySQL Data Transfer

Source Server         : local
Source Server Version : 50519
Source Host           : localhost:3306
Source Database       : realmdb

Target Server Type    : MYSQL
Target Server Version : 50519
File Encoding         : 65001

Date: 2012-08-22 06:39:25
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `accounts`
-- ----------------------------
DROP TABLE IF EXISTS `accounts`;
CREATE TABLE `accounts` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `sessionkey` varchar(255) DEFAULT NULL,
  `securityFlags` smallint(6) NOT NULL,
  `expansion` int(11) NOT NULL DEFAULT '4',
  `gmlevel` tinyint(4) NOT NULL DEFAULT '0',
  `ip` varchar(255) DEFAULT NULL,
  `language` varchar(4) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of accounts
-- ----------------------------

-- ----------------------------
-- Table structure for `realms`
-- ----------------------------
DROP TABLE IF EXISTS `realms`;
CREATE TABLE `realms` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `ip` varchar(15) DEFAULT NULL,
  `port` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of realms
-- ----------------------------
INSERT INTO `realms` VALUES ('1', 'Arctium MoP Beta Test', '127.0.0.1', '8100');

-- ----------------------------
-- Table structure for `realm_classes`
-- ----------------------------
DROP TABLE IF EXISTS `realm_classes`;
CREATE TABLE `realm_classes` (
  `realmId` int(11) NOT NULL,
  `class` tinyint(4) NOT NULL COMMENT 'Class Id',
  `expansion` tinyint(4) NOT NULL COMMENT 'Expansion for class activation',
  PRIMARY KEY (`realmId`,`class`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of realm_classes
-- ----------------------------
INSERT INTO `realm_classes` VALUES ('1', '1', '0');
INSERT INTO `realm_classes` VALUES ('1', '2', '0');
INSERT INTO `realm_classes` VALUES ('1', '3', '0');
INSERT INTO `realm_classes` VALUES ('1', '4', '0');
INSERT INTO `realm_classes` VALUES ('1', '5', '0');
INSERT INTO `realm_classes` VALUES ('1', '6', '2');
INSERT INTO `realm_classes` VALUES ('1', '7', '0');
INSERT INTO `realm_classes` VALUES ('1', '8', '0');
INSERT INTO `realm_classes` VALUES ('1', '9', '0');
INSERT INTO `realm_classes` VALUES ('1', '10', '4');
INSERT INTO `realm_classes` VALUES ('1', '11', '0');

-- ----------------------------
-- Table structure for `realm_races`
-- ----------------------------
DROP TABLE IF EXISTS `realm_races`;
CREATE TABLE `realm_races` (
  `realmId` int(11) NOT NULL,
  `race` tinyint(4) NOT NULL COMMENT 'Race Id',
  `expansion` tinyint(4) NOT NULL COMMENT 'Expansion for race activation',
  PRIMARY KEY (`realmId`,`race`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records of realm_races
-- ----------------------------
INSERT INTO `realm_races` VALUES ('1', '1', '0');
INSERT INTO `realm_races` VALUES ('1', '2', '0');
INSERT INTO `realm_races` VALUES ('1', '3', '0');
INSERT INTO `realm_races` VALUES ('1', '4', '0');
INSERT INTO `realm_races` VALUES ('1', '5', '0');
INSERT INTO `realm_races` VALUES ('1', '6', '0');
INSERT INTO `realm_races` VALUES ('1', '7', '0');
INSERT INTO `realm_races` VALUES ('1', '8', '0');
INSERT INTO `realm_races` VALUES ('1', '9', '3');
INSERT INTO `realm_races` VALUES ('1', '10', '1');
INSERT INTO `realm_races` VALUES ('1', '11', '1');
INSERT INTO `realm_races` VALUES ('1', '22', '3');
INSERT INTO `realm_races` VALUES ('1', '24', '4');
INSERT INTO `realm_races` VALUES ('1', '25', '4');
INSERT INTO `realm_races` VALUES ('1', '26', '4');
