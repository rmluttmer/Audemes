DROP TABLE IF EXISTS `gridgame`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `gridgame` (
  `atomic` varchar(100) NOT NULL,
  `name` varchar(100) NOT NULL,
  `hint` varchar(100) NOT NULL,
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

LOAD DATA INFILE 'GRIDGAMESEQUENCES.csv' 
INTO TABLE gridgame
FIELDS TERMINATED BY ',' 
ENCLOSED BY '"'
LINES TERMINATED BY '\n'
