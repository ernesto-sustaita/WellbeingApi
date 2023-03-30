-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Versión del servidor:         10.6.7-MariaDB - mariadb.org binary distribution
-- SO del servidor:              Win64
-- HeidiSQL Versión:             11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Volcando estructura de base de datos para wellbeing
DROP DATABASE IF EXISTS `wellbeing`;
CREATE DATABASE IF NOT EXISTS `wellbeing` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;
USE `wellbeing`;

-- Volcando estructura para tabla wellbeing.activity
DROP TABLE IF EXISTS `activity`;
CREATE TABLE IF NOT EXISTS `activity` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) NOT NULL,
  `Type` int(11) NOT NULL,
  `CreatedDate` datetime(6) NOT NULL,
  `Duration` int(11) DEFAULT NULL,
  `Distractions` int(11) DEFAULT NULL,
  `SurveyId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Activity_SurveyId` (`SurveyId`),
  CONSTRAINT `FK_Activity_Survey_SurveyId` FOREIGN KEY (`SurveyId`) REFERENCES `survey` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb4;

-- Volcando datos para la tabla wellbeing.activity: ~10 rows (aproximadamente)
/*!40000 ALTER TABLE `activity` DISABLE KEYS */;
INSERT INTO `activity` (`Id`, `UserId`, `Type`, `CreatedDate`, `Duration`, `Distractions`, `SurveyId`) VALUES
	(1, 1, 1, '2022-04-12 00:00:00.000000', 5, 0, NULL),
	(2, 1, 2, '2022-04-13 04:14:21.596000', 5, 0, NULL),
	(3, 1, 2, '2022-04-13 04:20:50.674000', 3, 0, NULL),
	(4, 1, 2, '2023-03-03 05:05:16.859000', 1, 0, NULL),
	(5, 1, 2, '2023-03-03 04:29:15.704000', 1, 0, NULL),
	(6, 1, 2, '2023-03-03 05:23:45.460000', 1, 0, NULL),
	(7, 1, 2, '2023-03-03 05:27:57.231000', 1, 0, NULL),
	(8, 1, 2, '2023-03-08 06:04:35.717000', 1, 0, NULL),
	(9, 1, 2, '2023-03-08 06:10:17.875000', 1, 8, NULL),
	(10, 1, 2, '2023-03-08 06:27:55.403000', 1, 2, NULL);
/*!40000 ALTER TABLE `activity` ENABLE KEYS */;

-- Volcando estructura para tabla wellbeing.alert
DROP TABLE IF EXISTS `alert`;
CREATE TABLE IF NOT EXISTS `alert` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) NOT NULL,
  `Type` int(11) NOT NULL,
  `ExecutionTime` datetime(6) NOT NULL,
  `DaysOfExecution` int(11) NOT NULL,
  `Title` longtext DEFAULT NULL,
  `Message` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4;

-- Volcando datos para la tabla wellbeing.alert: ~1 rows (aproximadamente)
/*!40000 ALTER TABLE `alert` DISABLE KEYS */;
INSERT INTO `alert` (`Id`, `UserId`, `Type`, `ExecutionTime`, `DaysOfExecution`, `Title`, `Message`) VALUES
	(1, 1, 1, '2022-04-13 04:49:59.812000', 1, 'Test', 'Test');
/*!40000 ALTER TABLE `alert` ENABLE KEYS */;

-- Volcando estructura para tabla wellbeing.answer
DROP TABLE IF EXISTS `answer`;
CREATE TABLE IF NOT EXISTS `answer` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `QuestionId` int(11) NOT NULL,
  `Text` longtext NOT NULL,
  `Type` longtext NOT NULL,
  `CreatedDate` datetime(6) NOT NULL,
  `UserId` int(11) NOT NULL DEFAULT 0,
  PRIMARY KEY (`Id`),
  KEY `IX_Answer_QuestionId` (`QuestionId`),
  CONSTRAINT `FK_Answer_Question_QuestionId` FOREIGN KEY (`QuestionId`) REFERENCES `question` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Volcando datos para la tabla wellbeing.answer: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `answer` DISABLE KEYS */;
/*!40000 ALTER TABLE `answer` ENABLE KEYS */;

-- Volcando estructura para tabla wellbeing.question
DROP TABLE IF EXISTS `question`;
CREATE TABLE IF NOT EXISTS `question` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) NOT NULL,
  `CreatedDate` datetime(6) NOT NULL,
  `Type` int(11) NOT NULL,
  `Text` longtext NOT NULL,
  `SurveyId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Question_SurveyId` (`SurveyId`),
  CONSTRAINT `FK_Question_Survey_SurveyId` FOREIGN KEY (`SurveyId`) REFERENCES `survey` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Volcando datos para la tabla wellbeing.question: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `question` DISABLE KEYS */;
/*!40000 ALTER TABLE `question` ENABLE KEYS */;

-- Volcando estructura para tabla wellbeing.questionoption
DROP TABLE IF EXISTS `questionoption`;
CREATE TABLE IF NOT EXISTS `questionoption` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `QuestionId` int(11) NOT NULL,
  `Text` longtext NOT NULL,
  `CreatedDate` datetime(6) NOT NULL,
  `UserId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_QuestionOption_QuestionId` (`QuestionId`),
  CONSTRAINT `FK_QuestionOption_Question_QuestionId` FOREIGN KEY (`QuestionId`) REFERENCES `question` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Volcando datos para la tabla wellbeing.questionoption: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `questionoption` DISABLE KEYS */;
/*!40000 ALTER TABLE `questionoption` ENABLE KEYS */;

-- Volcando estructura para tabla wellbeing.survey
DROP TABLE IF EXISTS `survey`;
CREATE TABLE IF NOT EXISTS `survey` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CreatedDate` datetime(6) NOT NULL,
  `UserId` int(11) NOT NULL,
  `Title` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Volcando datos para la tabla wellbeing.survey: ~0 rows (aproximadamente)
/*!40000 ALTER TABLE `survey` DISABLE KEYS */;
/*!40000 ALTER TABLE `survey` ENABLE KEYS */;

-- Volcando estructura para tabla wellbeing.user
DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` longtext DEFAULT NULL,
  `Email` longtext DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;

-- Volcando datos para la tabla wellbeing.user: ~2 rows (aproximadamente)
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` (`Id`, `Name`, `Email`) VALUES
	(1, 'neto', 'neto@example.com'),
	(2, 'Neto2', 'neto2@example.com');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;

-- Volcando estructura para tabla wellbeing.__efmigrationshistory
DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE IF NOT EXISTS `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Volcando datos para la tabla wellbeing.__efmigrationshistory: ~7 rows (aproximadamente)
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
	('20220405220151_InitialCreate', '6.0.3'),
	('20220413044816_ChangeAlertTimeColumn', '6.0.3'),
	('20230308055009_AddDistractionsField', '6.0.3'),
	('20230308055233_MakeDistractionsFieldNullable', '6.0.3'),
	('20230326165302_FeedbackTables', '6.0.3'),
	('20230329045531_SurveyTablesRefactor', '6.0.3'),
	('20230330053356_UserIdOnAnswerTable', '6.0.3');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
