-- MySQL dump 10.13  Distrib 8.0.46, for Win64 (x86_64)
--
-- Host: 192.168.227.14    Database: tradeddr
-- ------------------------------------------------------
-- Server version	8.0.42-0ubuntu0.20.04.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `Orders_Import`
--

DROP TABLE IF EXISTS `Orders_Import`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Orders_Import` (
  `№Orders` int DEFAULT NULL,
  `OrderContents` text,
  `OrderContents1` int DEFAULT NULL,
  `OrderContents2` text,
  `OrderContents3` int DEFAULT NULL,
  `DateOrders` text,
  `DateDelivery` text,
  `PicupPoint` int DEFAULT NULL,
  `Surname` text,
  `Name` text,
  `Patronymic` text,
  `Code` int DEFAULT NULL,
  `StatusOrders` text,
  `MyUnknownColumn` text,
  `MyUnknownColumn_[0]` text,
  `MyUnknownColumn_[1]` text,
  `MyUnknownColumn_[2]` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Orders_Import`
--

LOCK TABLES `Orders_Import` WRITE;
/*!40000 ALTER TABLE `Orders_Import` DISABLE KEYS */;
INSERT INTO `Orders_Import` VALUES (1,'А112Т4',1,'G843Y6',1,'19.05.2022','25.05.2022',1,'Савин','Станислав','Гордеевич',921,'Завершен','','','',''),(2,'S648N6',2,'D493Y7',2,'20.05.2022','26.05.2022',36,'Григорьевна','Есения','Александровна',922,'Новый ','','','',''),(3,'C635R4',1,'F735H6',1,'21.05.2022','27.05.2022',2,'Игнатов','Роман',' Степанович',923,'Новый ','','','',''),(4,'S538J7',5,'V835G5',5,'23.05.2022','29.05.2022',11,'Лебедева','Софья',' Марковна',924,'Новый ','','','',''),(5,'P846H6',2,'S530N6',2,'23.05.2022','29.05.2022',2,'Копылова','Алиса','Кирилловна',925,'Завершен','','','',''),(6,'S530N6',1,'S844B6',1,'24.05.2022','30.05.2022',34,'Кузнецов','Лев','Федерович',926,'Завершен','','','',''),(7,'B846B6',4,'L486B6',2,'25.05.2022','31.05.2022',3,'Анисимова','Алисия','Сергеевна',927,'Новый ','','','',''),(8,'H845N5',2,'F047G5',1,'27.05.2022','02.06.2022',19,'Иванов','Михаил','Ильич',928,'Новый ','','','',''),(9,'C453B6',1,'B835H6',1,'27.05.2022','02.06.2022',5,'Волков','Богдан','Денисович',929,'Новый ','','','',''),(10,'B964G6',4,'N764H5',5,'28.05.2022','03.06.2022',25,'Кроков','Тимофей','Тимофеевич',930,'Завершен','','','','');
/*!40000 ALTER TABLE `Orders_Import` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `PickupPoint_import (1)`
--

DROP TABLE IF EXISTS `PickupPoint_import (1)`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `PickupPoint_import (1)` (
  `344288` int DEFAULT NULL,
  `г. Михайловка` text,
  `ул. Чехова` text,
  `1` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `PickupPoint_import (1)`
--

LOCK TABLES `PickupPoint_import (1)` WRITE;
/*!40000 ALTER TABLE `PickupPoint_import (1)` DISABLE KEYS */;
INSERT INTO `PickupPoint_import (1)` VALUES (344288,'г. Михайловка','ул. Чехова',1),(614164,'г.Михайловка','  ул. Степная',30),(394242,'г. Михайловка','ул. Коммунистическая',43),(660540,'г. Михайловка','ул. Солнечная',25),(125837,'г. Михайловка','ул. Шоссейная',40),(125703,'г. Михайловка','ул. Партизанская',49),(625283,'г. Михайловка','ул. Победы',46),(614611,'г. Михайловка','ул. Молодежная',50),(454311,'г.Михайловка','ул. Новая',19),(660007,'г.Михайловка','ул. Октябрьская',19),(603036,'г. Михайловка','ул. Садовая',4),(450983,'г.Михайловка','ул. Комсомольская',26),(394782,'г. Михайловка','ул. Чехова',3),(603002,'г. Михайловка','ул. Дзержинского',28),(450558,'г. Михайловка','ул. Набережная',30),(394060,'г.Михайловка','ул. Фрунзе',43),(410661,'г. Михайловка','ул. Школьная',50),(625590,'г. Михайловка','ул. Коммунистическая',20),(400562,'г. Михайловка','ул. Зеленая',32),(614510,'г. Михайловка','ул. Маяковского',47),(410542,'г. Михайловка','ул. Светлая',46),(620839,'г. Михайловка','ул. Цветочная',8),(443890,'г. Михайловка','ул. Коммунистическая',1),(603379,'г. Михайловка','ул. Спортивная',46),(603721,'г. Михайловка','ул. Гоголя',41),(410172,'г. Михайловка','ул. Северная',13),(420151,'г. Михайловка','ул. Вишневая',32),(125061,'г. Михайловка','ул. Подгорная',8),(630370,'г. Михайловка','ул. Шоссейная',24),(614753,'г. Михайловка','ул. Полевая',35),(426030,'г. Михайловка','ул. Маяковского',44),(625560,'г. Михайловка','ул. Некрасова',12),(630201,'г. Михайловка','ул. Комсомольская',17),(190949,'г. Михайловка','ул. Мичурина',26);
/*!40000 ALTER TABLE `PickupPoint_import (1)` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_import`
--

DROP TABLE IF EXISTS `product_import`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `product_import` (
  `Art` text,
  `Name` text,
  `UnitOfMeasurement` text,
  `price` int DEFAULT NULL,
  `SizeMaxSale` int DEFAULT NULL,
  `Manufacurer` text,
  `Supplier` text,
  `Category` text,
  `Sale` int DEFAULT NULL,
  `QuantityInStock` int DEFAULT NULL,
  `Description` text,
  `Image` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_import`
--

LOCK TABLES `product_import` WRITE;
/*!40000 ALTER TABLE `product_import` DISABLE KEYS */;
INSERT INTO `product_import` VALUES ('А112Т4','Серьги','шт.',800,30,'ЮвелирКарат','SunLight','Серьги',3,6,'Серьги серебряные в позолоте продёвки на цепочке \"Звезда\"','А112Т4.png'),('G843Y6','Подвеска','шт.',240,25,'ЮвелирТорг','Sokolov','Подвеска',3,6,'Подвеска серебряная с фианитами 2138729/9 Ювелир Карат','G843Y6.jpg'),('G836H6','Подвеска','шт.',140,10,'ЮвелирТорг','Sokolov','Подвеска',2,16,'Подвеска серебряная в позолоте с фианитами 2139189/9п Ювелир Карат','G836H6.jpg'),('S648N6','Серьги','шт.',990,5,'ЮвелирКарат','SunLight','Серьги',4,5,'Серьги \"Бабочки\" в позолоте','S648N6.png'),('D493Y7','Ожерелье','шт.',79000,30,'ЮвелирКарат','Sokolov','Ожерелье',3,2,'Ожерелье Cordelia (муассанит, 11шт, 3,5мм, круг, BS Regular, 40см','D493Y7.jpg'),('D936R6','Серьги','шт.',890,30,'ЮвелирТорг','SunLight','Серьги',3,6,'Серьги со стразами Swarovski 2129919/96П Ювелир Карат','Images/cf0d61fab0d7462d93df5906223a9d76.jpg'),('S395J7','Серьги','шт.',7000,25,'ЮвелирКарат','Sokolov','Серьги',3,6,'Серьги из золота 029038','S395J7.jpg'),('C635R4','Ожерелье','шт.',590000,10,'ЮвелирТорг','SunLight','Ожерелье',2,16,'Ожерелье Lace (муассанит, круг, BS Regular, 6,5мм, 2 муассанит Кр-57 6мм','C635R4.jpg'),('F735H6','Серьги','шт.',12000,5,'ЮвелирТорг','Sokolov','Серьги',4,5,'Серьги из золота с эмалью','F735H6.jpg'),('S538J7','Серьги','шт.',2300,30,'ЮвелирКарат','Sokolov','Серьги',3,2,'Серьги с 4 фианитами из серебра с позолотой','S538J7.jpg'),('V835G5','Подвеска','шт.',695,10,'ЮвелирКарат','SunLight','Подвеска',3,6,'Подвеска из золочёного серебра с фианитами','no-image.png'),('P846H6','Подвеска','шт.',5195,5,'ЮвелирТорг','Sokolov','Подвеска',3,6,'Подвеска из красного золота П142-4547','no-image.png'),('S530N6','Серьги','шт.',2900,15,'ЮвелирКарат','SunLight','Серьги',2,16,'Серебряные серьги c ювелирной керамикой','no-image.png'),('N385N6','Серьги','шт.',6200,20,'ЮвелирКарат','Sokolov','Серьги',4,5,'Серьги-продевки из золота с фианитами','no-image.png'),('K943G6','Серьги','шт.',11545,25,'ЮвелирТорг','Sokolov','Серьги',3,2,'Серьги из золота с эмалью','no-image.png'),('S844B6','Подвеска','шт.',2100,6,'ЮвелирТорг','SunLight','Подвеска',3,6,'Подвеска из серебра с позолотой','no-image.png'),('B846B6','Браслет','шт.',5900,15,'ЮвелирКарат','Sokolov','Браслет',3,6,'Браслет из золота \"Бесконечность\" яхонт','no-image.png'),('L486B6','Серьги','шт.',7000,30,'ЮвелирКарат','Sokolov','Серьги',2,16,'Серьги из красного золота','no-image.png'),('H845N5','Серьги','шт.',2400,25,'ЮвелирТорг','SunLight','Серьги',4,5,'Серьги из серебра с позолотой','no-image.png'),('F047G5','Брошь','шт.',7100,10,'ЮвелирКарат','Sokolov','Брошь',3,2,'Брошь PLATINA jewelry из серебра 925 пробы с эмалью','no-image.png'),('A485H6','Кольцо','шт.',1110,5,'ЮвелирКарат','SunLight','Кольцо',4,11,'Кольцо из серебра с позолотой','no-image.png'),('B845B6','Серьги','шт.',5200,30,'ЮвелирТорг','Sokolov','Серьги',3,6,'Серьги с фианитами и гематитами из серебра с позолотой','no-image.png'),('L596G5','Серьги','шт.',11000,15,'ЮвелирТорг','SunLight','Серьги',3,6,'Серьги из красного золота','no-image.png'),('C453B6','Подвеска','шт.',5300,25,'ЮвелирКарат','Sokolov','Подвеска',2,16,'Подвеска из красного золота','no-image.png'),('B835H6','Колье','шт.',2600,20,'ЮвелирКарат','Sokolov','Колье',4,5,'Ювелирное колье из серебра 925 пробы с фианитами','no-image.png'),('P033N7','Подвеска','шт.',4300,5,'ЮвелирКарат','SunLight','Подвеска',3,2,'Подвеска из красного золота','no-image.png'),('B936H6','Колье','шт.',17500,5,'ЮвелирТорг','Sokolov','Колье',3,9,'Колье Эстет Золотое колье','no-image.png'),('B964G6','Подвеска','шт.',5350,5,'ЮвелирТорг','Sokolov','Подвеска',2,6,'Подвеска с 1 бриллиантом из красного золота','no-image.png'),('N764H5','Серьги','шт.',10600,10,'ЮвелирКарат','SunLight','Серьги',4,3,'Платина Серьги из красного золота без камней','no-image.png'),('V494H6','Подвеска','шт.',480,15,'ЮвелирКарат','Sokolov','Подвеска',2,12,'Подвеска серебряная с фианитами','no-image.png');
/*!40000 ALTER TABLE `product_import` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role_import1`
--

DROP TABLE IF EXISTS `role_import1`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `role_import1` (
  `Role` text,
  `ID` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role_import1`
--

LOCK TABLES `role_import1` WRITE;
/*!40000 ALTER TABLE `role_import1` DISABLE KEYS */;
INSERT INTO `role_import1` VALUES ('Администратор',1),('Менеджер',2),('Клиент',3),('Гость',4);
/*!40000 ALTER TABLE `role_import1` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_import`
--

DROP TABLE IF EXISTS `user_import`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_import` (
  `employeeRole` text,
  `Surname` text,
  `Name` text,
  `patronymic` text,
  `Login` text,
  `Password` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_import`
--

LOCK TABLES `user_import` WRITE;
/*!40000 ALTER TABLE `user_import` DISABLE KEYS */;
INSERT INTO `user_import` VALUES ('Администратор','Савин','Станислав','Гордеевич','dlh4o1tzrbse@yahoo.com','2L6KZG'),('Администратор','Григорьева','Есения','Александровна','rdgm3tpai7ch@outlook.com','uzWC67'),('Администратор','Копылова','Алиса','Кирилловна','048anwxsgze1@outlook.com','8ntwUp'),('Менеджер','Кузнецов','Лев','Фёдорович','9zg4lmtik3ja@yahoo.com','YOyhfR'),('Менеджер','Иванов','Михаил','Тимофеевич','1p4khxif7awq@mail.com','RSbvHv'),('Менеджер','Крюков','Тимофей','Ильич','zu56nc4l30xm@outlook.com','rwVDh9'),('Клиент','Игнатов','Роман','Степанович','iuf9onrqs1l4@mail.com','LdNyos'),('Клиент','Анисимова','Алисия','Сергеевна','hkonmlp8tdy2@mail.com','gynQMT'),('Клиент','Лебедева','Софья','Марковна','9ovm3eqak0jz@mail.com','AtnDjr'),('Клиент','Волков','Богдан','Денисович','5lfozwx7erq2@outlook.com','JlFRCZ'),(NULL,NULL,NULL,NULL,'123','123'),('Клиент','Танатарова','Диана','Есенбаевна','1','123'),('Клиент','йцу','фыв','фыв','56','00');
/*!40000 ALTER TABLE `user_import` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ЗаказНаПроизводство`
--

DROP TABLE IF EXISTS `ЗаказНаПроизводство`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ЗаказНаПроизводство` (
  `id` int NOT NULL,
  `number` text,
  `date` date DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ЗаказНаПроизводство`
--

LOCK TABLES `ЗаказНаПроизводство` WRITE;
/*!40000 ALTER TABLE `ЗаказНаПроизводство` DISABLE KEYS */;
/*!40000 ALTER TABLE `ЗаказНаПроизводство` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ЗаказНаПроизводство_Строки`
--

DROP TABLE IF EXISTS `ЗаказНаПроизводство_Строки`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ЗаказНаПроизводство_Строки` (
  `id` int NOT NULL,
  `id_заказа` int DEFAULT NULL,
  `id_продукции` int DEFAULT NULL,
  `quantity` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_заказа` (`id_заказа`),
  KEY `id_продукции` (`id_продукции`),
  CONSTRAINT `ЗаказНаПроизводство_Строки_ibfk_1` FOREIGN KEY (`id_заказа`) REFERENCES `ЗаказНаПроизводство` (`id`),
  CONSTRAINT `ЗаказНаПроизводство_Строки_ibfk_2` FOREIGN KEY (`id_продукции`) REFERENCES `Продукция` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ЗаказНаПроизводство_Строки`
--

LOCK TABLES `ЗаказНаПроизводство_Строки` WRITE;
/*!40000 ALTER TABLE `ЗаказНаПроизводство_Строки` DISABLE KEYS */;
/*!40000 ALTER TABLE `ЗаказНаПроизводство_Строки` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ЗаказПокупателя`
--

DROP TABLE IF EXISTS `ЗаказПокупателя`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ЗаказПокупателя` (
  `id` int NOT NULL,
  `number` text,
  `date` date DEFAULT NULL,
  `id_контрагента` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_контрагента` (`id_контрагента`),
  CONSTRAINT `ЗаказПокупателя_ibfk_1` FOREIGN KEY (`id_контрагента`) REFERENCES `Контрагенты` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ЗаказПокупателя`
--

LOCK TABLES `ЗаказПокупателя` WRITE;
/*!40000 ALTER TABLE `ЗаказПокупателя` DISABLE KEYS */;
INSERT INTO `ЗаказПокупателя` VALUES (1,'Заказ покупателя №1','2026-04-22',2);
/*!40000 ALTER TABLE `ЗаказПокупателя` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ЗаказПокупателя_Строки`
--

DROP TABLE IF EXISTS `ЗаказПокупателя_Строки`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ЗаказПокупателя_Строки` (
  `id` int NOT NULL,
  `id_заказа` int DEFAULT NULL,
  `id_продукции` int DEFAULT NULL,
  `quantity` decimal(10,0) DEFAULT NULL,
  `price` decimal(10,0) DEFAULT NULL,
  `discount` decimal(10,0) DEFAULT NULL,
  `amount` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_заказа` (`id_заказа`),
  KEY `id_продукции` (`id_продукции`),
  CONSTRAINT `ЗаказПокупателя_Строки_ibfk_1` FOREIGN KEY (`id_заказа`) REFERENCES `ЗаказПокупателя` (`id`),
  CONSTRAINT `ЗаказПокупателя_Строки_ibfk_2` FOREIGN KEY (`id_продукции`) REFERENCES `Продукция` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ЗаказПокупателя_Строки`
--

LOCK TABLES `ЗаказПокупателя_Строки` WRITE;
/*!40000 ALTER TABLE `ЗаказПокупателя_Строки` DISABLE KEYS */;
INSERT INTO `ЗаказПокупателя_Строки` VALUES (1,1,1,2,14120,1412,26828);
/*!40000 ALTER TABLE `ЗаказПокупателя_Строки` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Контрагенты`
--

DROP TABLE IF EXISTS `Контрагенты`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Контрагенты` (
  `id` int NOT NULL,
  `name` text,
  `inn` text,
  `address` text,
  `phone` text,
  `type` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Контрагенты`
--

LOCK TABLES `Контрагенты` WRITE;
/*!40000 ALTER TABLE `Контрагенты` DISABLE KEYS */;
INSERT INTO `Контрагенты` VALUES (1,'ООО \"Поставка\"','','г.Пятигорск','+79198634592','Поставщик'),(2,'ООО \"Кинотеатр Квант\"','26320045123','г. Железноводск, ул. Мира, 123','+79884581555','Покупатель'),(3,'ООО \"Ромашка\"','4140784214','г. Омск, ул. Строителей, 294','+79882584546','Поставщик'),(8,'ООО \"Новый JDTO\"','26320045111','г. Железноводску','+79884581555','Покупатель'),(9,'ООО \"Ипподром\"','5874045632','г. Уфа, ул. Набережная, 37','+79627486389','Поставщик'),(10,'ООО \"Ассоль\"','2629011278','г. Калуга, ул. Пушкина, 94','+79184572398','Покупатель');
/*!40000 ALTER TABLE `Контрагенты` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Материалы_и_работы`
--

DROP TABLE IF EXISTS `Материалы_и_работы`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Материалы_и_работы` (
  `id` int NOT NULL,
  `name` text,
  `unit` text,
  `price` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Материалы_и_работы`
--

LOCK TABLES `Материалы_и_работы` WRITE;
/*!40000 ALTER TABLE `Материалы_и_работы` DISABLE KEYS */;
INSERT INTO `Материалы_и_работы` VALUES (1,'Евровинт 6,5х5','тыс.шт',595.00),(2,'Мебельная деталь 500х800','шт',95.00),(3,'Мебельная деталь 600х800','шт',140.00),(4,'Опора','шт',245.00),(5,'Распил ДСП, МДФ и листового материала','услуга',450.00),(6,'Сборка модулей','услуга',1400.00),(7,'Столешница круглая','шт',3250.00),(8,'Упаковка','услуга',950.00);
/*!40000 ALTER TABLE `Материалы_и_работы` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Пользователи`
--

DROP TABLE IF EXISTS `Пользователи`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Пользователи` (
  `id` int NOT NULL AUTO_INCREMENT,
  `login` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL,
  `role` varchar(20) DEFAULT NULL,
  `is_blocked` tinyint DEFAULT '0',
  `failed_attempts` int DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `login` (`login`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Пользователи`
--

LOCK TABLES `Пользователи` WRITE;
/*!40000 ALTER TABLE `Пользователи` DISABLE KEYS */;
INSERT INTO `Пользователи` VALUES (1,'admin','admin123','Администратор',0,0),(2,'user1','user123','Пользователь',0,0),(3,'user2','123','Администратор',0,0),(4,'диана','123','Администратор',0,0),(5,'ралин','222','Пользователь',0,0);
/*!40000 ALTER TABLE `Пользователи` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Продукция`
--

DROP TABLE IF EXISTS `Продукция`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Продукция` (
  `id` int NOT NULL,
  `code` text,
  `name` text,
  `unit` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Продукция`
--

LOCK TABLES `Продукция` WRITE;
/*!40000 ALTER TABLE `Продукция` DISABLE KEYS */;
INSERT INTO `Продукция` VALUES (1,'НФ-00000006','Стол кухонный \"Самобранка\"','шт');
/*!40000 ALTER TABLE `Продукция` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Спецификация`
--

DROP TABLE IF EXISTS `Спецификация`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Спецификация` (
  `id` int NOT NULL,
  `id_продукции` int DEFAULT NULL,
  `id_материала` int DEFAULT NULL,
  `quantity` decimal(10,3) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_продукции` (`id_продукции`),
  KEY `id_материала` (`id_материала`),
  CONSTRAINT `Спецификация_ibfk_1` FOREIGN KEY (`id_продукции`) REFERENCES `Продукция` (`id`),
  CONSTRAINT `Спецификация_ibfk_2` FOREIGN KEY (`id_материала`) REFERENCES `Материалы_и_работы` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Спецификация`
--

LOCK TABLES `Спецификация` WRITE;
/*!40000 ALTER TABLE `Спецификация` DISABLE KEYS */;
INSERT INTO `Спецификация` VALUES (1,1,7,1.000),(2,1,2,2.000),(3,1,3,4.000),(4,1,1,0.012),(5,1,4,4.000),(6,1,6,1.000),(7,1,5,1.000),(8,1,8,1.000);
/*!40000 ALTER TABLE `Спецификация` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-09-26 12:36:49
