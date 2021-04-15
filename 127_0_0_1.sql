-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Vært: 127.0.0.1
-- Genereringstid: 15. 04 2021 kl. 21:13:46
-- Serverversion: 10.4.17-MariaDB
-- PHP-version: 8.0.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `phpmyadmin`
--
CREATE DATABASE IF NOT EXISTS `phpmyadmin` DEFAULT CHARACTER SET utf8 COLLATE utf8_bin;
USE `phpmyadmin`;

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `pma__bookmark`
--

CREATE TABLE `pma__bookmark` (
  `id` int(10) UNSIGNED NOT NULL,
  `dbase` varchar(255) COLLATE utf8_bin NOT NULL DEFAULT '',
  `user` varchar(255) COLLATE utf8_bin NOT NULL DEFAULT '',
  `label` varchar(255) CHARACTER SET utf8 NOT NULL DEFAULT '',
  `query` text COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Bookmarks';

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `pma__central_columns`
--

CREATE TABLE `pma__central_columns` (
  `db_name` varchar(64) COLLATE utf8_bin NOT NULL,
  `col_name` varchar(64) COLLATE utf8_bin NOT NULL,
  `col_type` varchar(64) COLLATE utf8_bin NOT NULL,
  `col_length` text COLLATE utf8_bin DEFAULT NULL,
  `col_collation` varchar(64) COLLATE utf8_bin NOT NULL,
  `col_isNull` tinyint(1) NOT NULL,
  `col_extra` varchar(255) COLLATE utf8_bin DEFAULT '',
  `col_default` text COLLATE utf8_bin DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Central list of columns';

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `pma__column_info`
--

CREATE TABLE `pma__column_info` (
  `id` int(5) UNSIGNED NOT NULL,
  `db_name` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `table_name` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `column_name` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `comment` varchar(255) CHARACTER SET utf8 NOT NULL DEFAULT '',
  `mimetype` varchar(255) CHARACTER SET utf8 NOT NULL DEFAULT '',
  `transformation` varchar(255) COLLATE utf8_bin NOT NULL DEFAULT '',
  `transformation_options` varchar(255) COLLATE utf8_bin NOT NULL DEFAULT '',
  `input_transformation` varchar(255) COLLATE utf8_bin NOT NULL DEFAULT '',
  `input_transformation_options` varchar(255) COLLATE utf8_bin NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Column information for phpMyAdmin';

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `pma__designer_settings`
--

CREATE TABLE `pma__designer_settings` (
  `username` varchar(64) COLLATE utf8_bin NOT NULL,
  `settings_data` text COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Settings related to Designer';

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `pma__export_templates`
--

CREATE TABLE `pma__export_templates` (
  `id` int(5) UNSIGNED NOT NULL,
  `username` varchar(64) COLLATE utf8_bin NOT NULL,
  `export_type` varchar(10) COLLATE utf8_bin NOT NULL,
  `template_name` varchar(64) COLLATE utf8_bin NOT NULL,
  `template_data` text COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Saved export templates';

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `pma__favorite`
--

CREATE TABLE `pma__favorite` (
  `username` varchar(64) COLLATE utf8_bin NOT NULL,
  `tables` text COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Favorite tables';

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `pma__history`
--

CREATE TABLE `pma__history` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `username` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `db` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `table` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `timevalue` timestamp NOT NULL DEFAULT current_timestamp(),
  `sqlquery` text COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='SQL history for phpMyAdmin';

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `pma__navigationhiding`
--

CREATE TABLE `pma__navigationhiding` (
  `username` varchar(64) COLLATE utf8_bin NOT NULL,
  `item_name` varchar(64) COLLATE utf8_bin NOT NULL,
  `item_type` varchar(64) COLLATE utf8_bin NOT NULL,
  `db_name` varchar(64) COLLATE utf8_bin NOT NULL,
  `table_name` varchar(64) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Hidden items of navigation tree';

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `pma__pdf_pages`
--

CREATE TABLE `pma__pdf_pages` (
  `db_name` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `page_nr` int(10) UNSIGNED NOT NULL,
  `page_descr` varchar(50) CHARACTER SET utf8 NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='PDF relation pages for phpMyAdmin';

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `pma__recent`
--

CREATE TABLE `pma__recent` (
  `username` varchar(64) COLLATE utf8_bin NOT NULL,
  `tables` text COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Recently accessed tables';

--
-- Data dump for tabellen `pma__recent`
--

INSERT INTO `pma__recent` (`username`, `tables`) VALUES
('root', '[{\"db\":\"steensoft_dk_flickclick\",\"table\":\"users\"},{\"db\":\"steensoft_dk_flickclick\",\"table\":\"movies\"},{\"db\":\"steensoft_dk_flickclick\",\"table\":\"streetnames\"},{\"db\":\"steensoft_dk_flickclick\",\"table\":\"stars\"},{\"db\":\"steensoft_dk_flickclick\",\"table\":\"addressjunction\"},{\"db\":\"steensoft_dk_flickclick\",\"table\":\"citycodes\"},{\"db\":\"steensoft_dk_flickclick\",\"table\":\"commentjunction\"},{\"db\":\"steensoft_dk_flickclick\",\"table\":\"comments\"},{\"db\":\"steensoft_dk_flickclick\",\"table\":\"emailusers\"},{\"db\":\"steensoft_dk_flickclick\",\"table\":\"firstnames\"}]');

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `pma__relation`
--

CREATE TABLE `pma__relation` (
  `master_db` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `master_table` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `master_field` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `foreign_db` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `foreign_table` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `foreign_field` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Relation table';

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `pma__savedsearches`
--

CREATE TABLE `pma__savedsearches` (
  `id` int(5) UNSIGNED NOT NULL,
  `username` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `db_name` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `search_name` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `search_data` text COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Saved searches';

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `pma__table_coords`
--

CREATE TABLE `pma__table_coords` (
  `db_name` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `table_name` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `pdf_page_number` int(11) NOT NULL DEFAULT 0,
  `x` float UNSIGNED NOT NULL DEFAULT 0,
  `y` float UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Table coordinates for phpMyAdmin PDF output';

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `pma__table_info`
--

CREATE TABLE `pma__table_info` (
  `db_name` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `table_name` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `display_field` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Table information for phpMyAdmin';

--
-- Data dump for tabellen `pma__table_info`
--

INSERT INTO `pma__table_info` (`db_name`, `table_name`, `display_field`) VALUES
('steensoft_dk_flickclick', 'comments', 'text'),
('steensoft_dk_flickclick', 'emailusers', 'email');

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `pma__table_uiprefs`
--

CREATE TABLE `pma__table_uiprefs` (
  `username` varchar(64) COLLATE utf8_bin NOT NULL,
  `db_name` varchar(64) COLLATE utf8_bin NOT NULL,
  `table_name` varchar(64) COLLATE utf8_bin NOT NULL,
  `prefs` text COLLATE utf8_bin NOT NULL,
  `last_update` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Tables'' UI preferences';

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `pma__tracking`
--

CREATE TABLE `pma__tracking` (
  `db_name` varchar(64) COLLATE utf8_bin NOT NULL,
  `table_name` varchar(64) COLLATE utf8_bin NOT NULL,
  `version` int(10) UNSIGNED NOT NULL,
  `date_created` datetime NOT NULL,
  `date_updated` datetime NOT NULL,
  `schema_snapshot` text COLLATE utf8_bin NOT NULL,
  `schema_sql` text COLLATE utf8_bin DEFAULT NULL,
  `data_sql` longtext COLLATE utf8_bin DEFAULT NULL,
  `tracking` set('UPDATE','REPLACE','INSERT','DELETE','TRUNCATE','CREATE DATABASE','ALTER DATABASE','DROP DATABASE','CREATE TABLE','ALTER TABLE','RENAME TABLE','DROP TABLE','CREATE INDEX','DROP INDEX','CREATE VIEW','ALTER VIEW','DROP VIEW') COLLATE utf8_bin DEFAULT NULL,
  `tracking_active` int(1) UNSIGNED NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Database changes tracking for phpMyAdmin';

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `pma__userconfig`
--

CREATE TABLE `pma__userconfig` (
  `username` varchar(64) COLLATE utf8_bin NOT NULL,
  `timevalue` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `config_data` text COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='User preferences storage for phpMyAdmin';

--
-- Data dump for tabellen `pma__userconfig`
--

INSERT INTO `pma__userconfig` (`username`, `timevalue`, `config_data`) VALUES
('root', '2021-04-15 19:08:10', '{\"Console\\/Mode\":\"collapse\",\"lang\":\"da\"}');

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `pma__usergroups`
--

CREATE TABLE `pma__usergroups` (
  `usergroup` varchar(64) COLLATE utf8_bin NOT NULL,
  `tab` varchar(64) COLLATE utf8_bin NOT NULL,
  `allowed` enum('Y','N') COLLATE utf8_bin NOT NULL DEFAULT 'N'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='User groups with configured menu items';

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `pma__users`
--

CREATE TABLE `pma__users` (
  `username` varchar(64) COLLATE utf8_bin NOT NULL,
  `usergroup` varchar(64) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin COMMENT='Users and their assignments to user groups';

--
-- Begrænsninger for dumpede tabeller
--

--
-- Indeks for tabel `pma__bookmark`
--
ALTER TABLE `pma__bookmark`
  ADD PRIMARY KEY (`id`);

--
-- Indeks for tabel `pma__central_columns`
--
ALTER TABLE `pma__central_columns`
  ADD PRIMARY KEY (`db_name`,`col_name`);

--
-- Indeks for tabel `pma__column_info`
--
ALTER TABLE `pma__column_info`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `db_name` (`db_name`,`table_name`,`column_name`);

--
-- Indeks for tabel `pma__designer_settings`
--
ALTER TABLE `pma__designer_settings`
  ADD PRIMARY KEY (`username`);

--
-- Indeks for tabel `pma__export_templates`
--
ALTER TABLE `pma__export_templates`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `u_user_type_template` (`username`,`export_type`,`template_name`);

--
-- Indeks for tabel `pma__favorite`
--
ALTER TABLE `pma__favorite`
  ADD PRIMARY KEY (`username`);

--
-- Indeks for tabel `pma__history`
--
ALTER TABLE `pma__history`
  ADD PRIMARY KEY (`id`),
  ADD KEY `username` (`username`,`db`,`table`,`timevalue`);

--
-- Indeks for tabel `pma__navigationhiding`
--
ALTER TABLE `pma__navigationhiding`
  ADD PRIMARY KEY (`username`,`item_name`,`item_type`,`db_name`,`table_name`);

--
-- Indeks for tabel `pma__pdf_pages`
--
ALTER TABLE `pma__pdf_pages`
  ADD PRIMARY KEY (`page_nr`),
  ADD KEY `db_name` (`db_name`);

--
-- Indeks for tabel `pma__recent`
--
ALTER TABLE `pma__recent`
  ADD PRIMARY KEY (`username`);

--
-- Indeks for tabel `pma__relation`
--
ALTER TABLE `pma__relation`
  ADD PRIMARY KEY (`master_db`,`master_table`,`master_field`),
  ADD KEY `foreign_field` (`foreign_db`,`foreign_table`);

--
-- Indeks for tabel `pma__savedsearches`
--
ALTER TABLE `pma__savedsearches`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `u_savedsearches_username_dbname` (`username`,`db_name`,`search_name`);

--
-- Indeks for tabel `pma__table_coords`
--
ALTER TABLE `pma__table_coords`
  ADD PRIMARY KEY (`db_name`,`table_name`,`pdf_page_number`);

--
-- Indeks for tabel `pma__table_info`
--
ALTER TABLE `pma__table_info`
  ADD PRIMARY KEY (`db_name`,`table_name`);

--
-- Indeks for tabel `pma__table_uiprefs`
--
ALTER TABLE `pma__table_uiprefs`
  ADD PRIMARY KEY (`username`,`db_name`,`table_name`);

--
-- Indeks for tabel `pma__tracking`
--
ALTER TABLE `pma__tracking`
  ADD PRIMARY KEY (`db_name`,`table_name`,`version`);

--
-- Indeks for tabel `pma__userconfig`
--
ALTER TABLE `pma__userconfig`
  ADD PRIMARY KEY (`username`);

--
-- Indeks for tabel `pma__usergroups`
--
ALTER TABLE `pma__usergroups`
  ADD PRIMARY KEY (`usergroup`,`tab`,`allowed`);

--
-- Indeks for tabel `pma__users`
--
ALTER TABLE `pma__users`
  ADD PRIMARY KEY (`username`,`usergroup`);

--
-- Brug ikke AUTO_INCREMENT for slettede tabeller
--

--
-- Tilføj AUTO_INCREMENT i tabel `pma__bookmark`
--
ALTER TABLE `pma__bookmark`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- Tilføj AUTO_INCREMENT i tabel `pma__column_info`
--
ALTER TABLE `pma__column_info`
  MODIFY `id` int(5) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- Tilføj AUTO_INCREMENT i tabel `pma__export_templates`
--
ALTER TABLE `pma__export_templates`
  MODIFY `id` int(5) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- Tilføj AUTO_INCREMENT i tabel `pma__history`
--
ALTER TABLE `pma__history`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- Tilføj AUTO_INCREMENT i tabel `pma__pdf_pages`
--
ALTER TABLE `pma__pdf_pages`
  MODIFY `page_nr` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;

--
-- Tilføj AUTO_INCREMENT i tabel `pma__savedsearches`
--
ALTER TABLE `pma__savedsearches`
  MODIFY `id` int(5) UNSIGNED NOT NULL AUTO_INCREMENT;
--
-- Database: `steensoft_dk_flickclick`
--
CREATE DATABASE IF NOT EXISTS `steensoft_dk_flickclick` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `steensoft_dk_flickclick`;

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `addressjunction`
--

CREATE TABLE `addressjunction` (
  `ID` int(11) NOT NULL,
  `cityID` int(11) NOT NULL,
  `streetID` int(11) NOT NULL,
  `houseNumber` varchar(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Data dump for tabellen `addressjunction`
--

INSERT INTO `addressjunction` (`ID`, `cityID`, `streetID`, `houseNumber`) VALUES
(1, 1, 1, '2'),
(2, 3, 2, '21'),
(3, 4, 3, '23');

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `admins`
--

CREATE TABLE `admins` (
  `adminID` int(11) NOT NULL,
  `password` varchar(64) NOT NULL,
  `passwordSalt` varchar(24) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Data dump for tabellen `admins`
--

INSERT INTO `admins` (`adminID`, `password`, `passwordSalt`) VALUES
(1, 'a312a00fcc5371b96e1fa66cd1cbf7c887fd2864129feb07420019eec9719fce', 'lSbyt6097Iq86rSjNkkZuw==');

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `citycodes`
--

CREATE TABLE `citycodes` (
  `cityID` int(11) NOT NULL,
  `postalCode` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Data dump for tabellen `citycodes`
--

INSERT INTO `citycodes` (`cityID`, `postalCode`) VALUES
(1, 0),
(2, 2333),
(3, 21),
(4, 5221);

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `commentjunction`
--

CREATE TABLE `commentjunction` (
  `ID` int(11) NOT NULL,
  `movieID` int(11) NOT NULL,
  `commentID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Data dump for tabellen `commentjunction`
--

INSERT INTO `commentjunction` (`ID`, `movieID`, `commentID`) VALUES
(8, 10, 8),
(9, 12, 9);

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `comments`
--

CREATE TABLE `comments` (
  `commentID` int(11) NOT NULL,
  `userID` int(11) NOT NULL,
  `text` text NOT NULL,
  `postDate` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Data dump for tabellen `comments`
--

INSERT INTO `comments` (`commentID`, `userID`, `text`, `postDate`) VALUES
(8, 4, 'Meget cool', '2021-04-14 09:19:24'),
(9, 4, 'Meget god film!!\n', '2021-04-14 12:07:42');

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `contact`
--

CREATE TABLE `contact` (
  `ID` int(11) NOT NULL,
  `contactName` varchar(48) NOT NULL,
  `contactMail` varchar(48) NOT NULL,
  `message` varchar(1024) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Data dump for tabellen `contact`
--

INSERT INTO `contact` (`ID`, `contactName`, `contactMail`, `message`) VALUES
(1, 'xd', 'nikolaim@ail.com', 'xd'),
(2, 'Nikolai', 'mail@com.com', 'Hej med dig  ;)');

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `directors`
--

CREATE TABLE `directors` (
  `directorID` int(11) NOT NULL,
  `firstName` varchar(32) NOT NULL,
  `lastName` varchar(32) NOT NULL,
  `dateOfBirth` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Data dump for tabellen `directors`
--

INSERT INTO `directors` (`directorID`, `firstName`, `lastName`, `dateOfBirth`) VALUES
(1, 'Director', 'Template', '0001-01-01'),
(2, 'Irvin', 'Kershner', '1923-04-29'),
(3, 'Richard', 'Marquand', '1987-09-04'),
(4, 'Jeffrey Jacob', 'Arbams', '1966-06-27'),
(5, 'Rian', 'Johnson', '1973-12-17'),
(6, 'Dave', 'Filoni', '1974-06-07'),
(10, 'George', 'Lucas', '1944-05-14'),
(12, 'Robert', 'Zemeckis', '1952-05-14');

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `emailadmins`
--

CREATE TABLE `emailadmins` (
  `emailID` int(11) NOT NULL,
  `adminID` int(11) NOT NULL,
  `email` varchar(64) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Data dump for tabellen `emailadmins`
--

INSERT INTO `emailadmins` (`emailID`, `adminID`, `email`) VALUES
(1, 1, 'ceo@flickclick.dk');

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `emailusers`
--

CREATE TABLE `emailusers` (
  `emailID` int(11) NOT NULL,
  `userID` int(11) NOT NULL,
  `email` varchar(64) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Data dump for tabellen `emailusers`
--

INSERT INTO `emailusers` (`emailID`, `userID`, `email`) VALUES
(2, 4, 'joe@nuts.dk');

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `firstnames`
--

CREATE TABLE `firstnames` (
  `firstNameID` int(11) NOT NULL,
  `firstName` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Data dump for tabellen `firstnames`
--

INSERT INTO `firstnames` (`firstNameID`, `firstName`) VALUES
(1, 'Nikolai'),
(2, 'xd'),
(3, 'Joe');

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `genrejunction`
--

CREATE TABLE `genrejunction` (
  `ID` int(11) NOT NULL,
  `movieID` int(11) NOT NULL,
  `genreID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Data dump for tabellen `genrejunction`
--

INSERT INTO `genrejunction` (`ID`, `movieID`, `genreID`) VALUES
(10, 3, 1),
(11, 12, 2),
(12, 12, 1),
(13, 18, 3);

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `genres`
--

CREATE TABLE `genres` (
  `genreID` int(11) NOT NULL,
  `genreName` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Data dump for tabellen `genres`
--

INSERT INTO `genres` (`genreID`, `genreName`) VALUES
(1, 'Action'),
(2, 'Sci-Fi'),
(3, 'Drama');

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `lastnames`
--

CREATE TABLE `lastnames` (
  `lastNameID` int(11) NOT NULL,
  `lastName` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Data dump for tabellen `lastnames`
--

INSERT INTO `lastnames` (`lastNameID`, `lastName`) VALUES
(1, 'Larsen'),
(2, 'xd'),
(3, 'Nuts');

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `movies`
--

CREATE TABLE `movies` (
  `movieID` int(11) NOT NULL,
  `title` varchar(64) NOT NULL,
  `releaseDate` date NOT NULL,
  `description` varchar(512) NOT NULL,
  `directorID` int(11) NOT NULL,
  `duration` time NOT NULL,
  `postDate` datetime NOT NULL,
  `ageRating` int(3) NOT NULL,
  `comingSoon` tinyint(1) NOT NULL,
  `picturePath` varchar(128) NOT NULL,
  `trailerPath` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Data dump for tabellen `movies`
--

INSERT INTO `movies` (`movieID`, `title`, `releaseDate`, `description`, `directorID`, `duration`, `postDate`, `ageRating`, `comingSoon`, `picturePath`, `trailerPath`) VALUES
(3, 'Star Wars: Episode I – The Phantom Menace', '1999-05-19', 'Le star wars', 10, '12:32:22', '0001-01-01 00:00:00', 11, 0, '/assets/movie-banners/Star_Wars-_Episode_I_–_The_Phantom_Menace.jpg', ''),
(4, 'Star Wars: Episode II – Attack of the Clones', '2002-05-12', 'Le sequel', 10, '02:22:00', '0001-01-01 00:00:00', 11, 0, '/assets/movie-banners/Star_Wars-_Episode_II_–_Attack_of_the_Clones.jpg', ''),
(5, 'Star Wars: Episode III – Revenge of the Sith', '2005-05-19', 'Le third', 10, '02:20:00', '0001-01-01 00:00:00', 11, 0, '/assets/movie-banners/Star_Wars-_Episode_III_–_Revenge_of_the_Sith.jpg', ''),
(6, 'Star Wars: Episode IV – A New Hope', '1977-05-25', 'NoOOOO le vader is herez', 10, '02:01:00', '0001-01-01 00:00:00', 11, 0, '/assets/movie-banners/Star_Wars-_Episode_IV_–_A_New_Hope.jpg', ''),
(7, 'Star Wars: Episode V – The Empire Strikes Back', '1980-05-17', 'Get fugged', 2, '02:04:00', '0001-01-01 00:00:00', 11, 0, '/assets/movie-banners/Star_Wars-_Episode_V_–_The_Empire_Strikes_Back.jpg', ''),
(8, 'Star Wars: Episode VI – Return of the Jedi', '1983-05-25', 'Get fugged part 2', 3, '02:12:00', '0001-01-01 00:00:00', 11, 0, '/assets/movie-banners/Star_Wars-_Episode_VI_–_Return_of_the_Jedi.jpg', ''),
(9, 'Star Wars: Episode VII – The Force Awakens', '2015-12-18', 'New one???', 4, '02:15:00', '0001-01-01 00:00:00', 11, 0, '/assets/movie-banners/Star_Wars-_Episode_VII_–_The_Force_Awakens.jpg', ''),
(10, 'Star Wars: Episode VIII – The Last Jedi', '2017-12-15', 'Poggers new hope??', 5, '02:32:00', '0001-01-01 00:00:00', 11, 0, '/assets/movie-banners/Star_Wars-_Episode_VIII_–_The_Last_Jedi.jpg', ''),
(11, 'Star Wars: Episode IX – The Rise of Skywalker', '2019-12-20', 'Le pog champ epic win', 4, '02:22:00', '0001-01-01 00:00:00', 11, 0, '/assets/movie-banners/Star_Wars-_Episode_IX_–_The_Rise_of_Skywalker.png', 'https://www.youtube.com/embed/adzYW5DZoWs'),
(12, 'Star Wars: The Clone Wars', '2008-09-15', 'Anime???', 6, '01:36:00', '0001-01-01 00:00:00', 7, 0, '/assets/movie-banners/Star_Wars-_The_Clone_Wars.jpg', 'https://www.youtube.com/embed/c3t2f7KpL4Y'),
(18, 'Forest Gump', '2021-04-19', 'A movie about a special boy. He then goes to Nam', 12, '02:22:00', '0001-01-01 00:00:00', 7, 1, '/assets/movie-banners/Forest_Gump.jpg', 'https://www.youtube.com/embed/XHhAG-YLdk8');

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `news`
--

CREATE TABLE `news` (
  `ID` int(11) NOT NULL,
  `title` varchar(64) NOT NULL,
  `text` varchar(1024) NOT NULL,
  `postDate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Data dump for tabellen `news`
--

INSERT INTO `news` (`ID`, `title`, `text`, `postDate`) VALUES
(1, 'Test 123', 'Lorem Ipsum Lorem IpsumLorem IpsumLorem IpsumLorem IpsumLorem IpsumLorem IpsumLorem Ipsum', '2025-02-21'),
(2, 'Så skal vi snart fremlægge ;)', 'Det skal nok gå godt, jeg ved det. Kaj han er ej skrap.', '2021-04-15');

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `starjunction`
--

CREATE TABLE `starjunction` (
  `ID` int(11) NOT NULL,
  `movieID` int(11) NOT NULL,
  `starID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Data dump for tabellen `starjunction`
--

INSERT INTO `starjunction` (`ID`, `movieID`, `starID`) VALUES
(3, 3, 1),
(4, 12, 2),
(5, 18, 3);

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `stars`
--

CREATE TABLE `stars` (
  `starID` int(11) NOT NULL,
  `firstName` varchar(32) NOT NULL,
  `lastName` varchar(32) NOT NULL,
  `dateOfBirth` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Data dump for tabellen `stars`
--

INSERT INTO `stars` (`starID`, `firstName`, `lastName`, `dateOfBirth`) VALUES
(1, 'Bratt', 'Pitt', '1968-10-04'),
(2, 'Matt', 'Lanter', '1983-04-01'),
(3, 'Tom', 'Hanks', '1956-07-09');

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `streetnames`
--

CREATE TABLE `streetnames` (
  `streetID` int(11) NOT NULL,
  `streetName` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Data dump for tabellen `streetnames`
--

INSERT INTO `streetnames` (`streetID`, `streetName`) VALUES
(1, 'Din mor vej'),
(2, 'xd'),
(3, 'A. sasd');

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `users`
--

CREATE TABLE `users` (
  `userID` int(11) NOT NULL,
  `firstNameID` int(11) NOT NULL,
  `lastNameID` int(11) NOT NULL,
  `addressID` int(11) NOT NULL,
  `password` varchar(64) NOT NULL,
  `passwordSalt` varchar(24) NOT NULL,
  `phoneNumber` int(11) NOT NULL,
  `profilePicPath` varchar(128) NOT NULL,
  `userSince` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Data dump for tabellen `users`
--

INSERT INTO `users` (`userID`, `firstNameID`, `lastNameID`, `addressID`, `password`, `passwordSalt`, `phoneNumber`, `profilePicPath`, `userSince`) VALUES
(4, 3, 3, 3, '25ab1c8cd067d059b8ff5ffdae2e3c8065d65697254bf4c2dc1e1320be134b48', 'ySfriVqJzj8RundRjFRXdg==', 21212121, 'assets/profile-pictures/pictureforuser4.png', '2021-04-13');

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `writerjunction`
--

CREATE TABLE `writerjunction` (
  `ID` int(11) NOT NULL,
  `movieID` int(11) NOT NULL,
  `writerID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Data dump for tabellen `writerjunction`
--

INSERT INTO `writerjunction` (`ID`, `movieID`, `writerID`) VALUES
(1, 12, 1),
(2, 18, 2);

-- --------------------------------------------------------

--
-- Struktur-dump for tabellen `writers`
--

CREATE TABLE `writers` (
  `writerID` int(11) NOT NULL,
  `firstName` varchar(32) NOT NULL,
  `lastName` varchar(32) NOT NULL,
  `dateOfBirth` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Data dump for tabellen `writers`
--

INSERT INTO `writers` (`writerID`, `firstName`, `lastName`, `dateOfBirth`) VALUES
(1, 'Henry', 'Gilroy', '1976-11-01'),
(2, 'Winston', 'Groom', '1943-03-23');

--
-- Begrænsninger for dumpede tabeller
--

--
-- Indeks for tabel `addressjunction`
--
ALTER TABLE `addressjunction`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `cityID` (`cityID`),
  ADD KEY `streetID` (`streetID`);

--
-- Indeks for tabel `admins`
--
ALTER TABLE `admins`
  ADD PRIMARY KEY (`adminID`);

--
-- Indeks for tabel `citycodes`
--
ALTER TABLE `citycodes`
  ADD PRIMARY KEY (`cityID`);

--
-- Indeks for tabel `commentjunction`
--
ALTER TABLE `commentjunction`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `movieID` (`movieID`),
  ADD KEY `commentID` (`commentID`);

--
-- Indeks for tabel `comments`
--
ALTER TABLE `comments`
  ADD PRIMARY KEY (`commentID`),
  ADD KEY `userID` (`userID`);

--
-- Indeks for tabel `contact`
--
ALTER TABLE `contact`
  ADD PRIMARY KEY (`ID`);

--
-- Indeks for tabel `directors`
--
ALTER TABLE `directors`
  ADD PRIMARY KEY (`directorID`);

--
-- Indeks for tabel `emailadmins`
--
ALTER TABLE `emailadmins`
  ADD PRIMARY KEY (`emailID`),
  ADD KEY `adminID` (`adminID`);

--
-- Indeks for tabel `emailusers`
--
ALTER TABLE `emailusers`
  ADD PRIMARY KEY (`emailID`),
  ADD KEY `userID` (`userID`);

--
-- Indeks for tabel `firstnames`
--
ALTER TABLE `firstnames`
  ADD PRIMARY KEY (`firstNameID`);

--
-- Indeks for tabel `genrejunction`
--
ALTER TABLE `genrejunction`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `movieID` (`movieID`),
  ADD KEY `genreID` (`genreID`);

--
-- Indeks for tabel `genres`
--
ALTER TABLE `genres`
  ADD PRIMARY KEY (`genreID`);

--
-- Indeks for tabel `lastnames`
--
ALTER TABLE `lastnames`
  ADD PRIMARY KEY (`lastNameID`);

--
-- Indeks for tabel `movies`
--
ALTER TABLE `movies`
  ADD PRIMARY KEY (`movieID`),
  ADD KEY `directorID` (`directorID`);

--
-- Indeks for tabel `news`
--
ALTER TABLE `news`
  ADD PRIMARY KEY (`ID`);

--
-- Indeks for tabel `starjunction`
--
ALTER TABLE `starjunction`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `movieID` (`movieID`),
  ADD KEY `starID` (`starID`);

--
-- Indeks for tabel `stars`
--
ALTER TABLE `stars`
  ADD PRIMARY KEY (`starID`);

--
-- Indeks for tabel `streetnames`
--
ALTER TABLE `streetnames`
  ADD PRIMARY KEY (`streetID`);

--
-- Indeks for tabel `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`userID`),
  ADD KEY `firstNameID` (`firstNameID`),
  ADD KEY `lastNameID` (`lastNameID`),
  ADD KEY `addressID` (`addressID`);

--
-- Indeks for tabel `writerjunction`
--
ALTER TABLE `writerjunction`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `movieID` (`movieID`),
  ADD KEY `writerID` (`writerID`);

--
-- Indeks for tabel `writers`
--
ALTER TABLE `writers`
  ADD PRIMARY KEY (`writerID`);

--
-- Brug ikke AUTO_INCREMENT for slettede tabeller
--

--
-- Tilføj AUTO_INCREMENT i tabel `addressjunction`
--
ALTER TABLE `addressjunction`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Tilføj AUTO_INCREMENT i tabel `admins`
--
ALTER TABLE `admins`
  MODIFY `adminID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tilføj AUTO_INCREMENT i tabel `citycodes`
--
ALTER TABLE `citycodes`
  MODIFY `cityID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Tilføj AUTO_INCREMENT i tabel `commentjunction`
--
ALTER TABLE `commentjunction`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- Tilføj AUTO_INCREMENT i tabel `comments`
--
ALTER TABLE `comments`
  MODIFY `commentID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- Tilføj AUTO_INCREMENT i tabel `contact`
--
ALTER TABLE `contact`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Tilføj AUTO_INCREMENT i tabel `directors`
--
ALTER TABLE `directors`
  MODIFY `directorID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- Tilføj AUTO_INCREMENT i tabel `emailadmins`
--
ALTER TABLE `emailadmins`
  MODIFY `emailID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Tilføj AUTO_INCREMENT i tabel `emailusers`
--
ALTER TABLE `emailusers`
  MODIFY `emailID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Tilføj AUTO_INCREMENT i tabel `firstnames`
--
ALTER TABLE `firstnames`
  MODIFY `firstNameID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Tilføj AUTO_INCREMENT i tabel `genrejunction`
--
ALTER TABLE `genrejunction`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- Tilføj AUTO_INCREMENT i tabel `genres`
--
ALTER TABLE `genres`
  MODIFY `genreID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Tilføj AUTO_INCREMENT i tabel `lastnames`
--
ALTER TABLE `lastnames`
  MODIFY `lastNameID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Tilføj AUTO_INCREMENT i tabel `movies`
--
ALTER TABLE `movies`
  MODIFY `movieID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- Tilføj AUTO_INCREMENT i tabel `news`
--
ALTER TABLE `news`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Tilføj AUTO_INCREMENT i tabel `starjunction`
--
ALTER TABLE `starjunction`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Tilføj AUTO_INCREMENT i tabel `stars`
--
ALTER TABLE `stars`
  MODIFY `starID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Tilføj AUTO_INCREMENT i tabel `streetnames`
--
ALTER TABLE `streetnames`
  MODIFY `streetID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Tilføj AUTO_INCREMENT i tabel `users`
--
ALTER TABLE `users`
  MODIFY `userID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Tilføj AUTO_INCREMENT i tabel `writerjunction`
--
ALTER TABLE `writerjunction`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Tilføj AUTO_INCREMENT i tabel `writers`
--
ALTER TABLE `writers`
  MODIFY `writerID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Begrænsninger for dumpede tabeller
--

--
-- Begrænsninger for tabel `addressjunction`
--
ALTER TABLE `addressjunction`
  ADD CONSTRAINT `AddressJunction_ibfk_1` FOREIGN KEY (`cityID`) REFERENCES `citycodes` (`cityID`),
  ADD CONSTRAINT `AddressJunction_ibfk_2` FOREIGN KEY (`streetID`) REFERENCES `streetnames` (`streetID`);

--
-- Begrænsninger for tabel `commentjunction`
--
ALTER TABLE `commentjunction`
  ADD CONSTRAINT `CommentJunction_ibfk_1` FOREIGN KEY (`commentID`) REFERENCES `comments` (`commentID`) ON DELETE CASCADE,
  ADD CONSTRAINT `CommentJunction_ibfk_2` FOREIGN KEY (`movieID`) REFERENCES `movies` (`movieID`) ON DELETE CASCADE;

--
-- Begrænsninger for tabel `comments`
--
ALTER TABLE `comments`
  ADD CONSTRAINT `Comments_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`) ON DELETE CASCADE;

--
-- Begrænsninger for tabel `emailadmins`
--
ALTER TABLE `emailadmins`
  ADD CONSTRAINT `emailadmins_ibfk_1` FOREIGN KEY (`adminID`) REFERENCES `admins` (`adminID`);

--
-- Begrænsninger for tabel `emailusers`
--
ALTER TABLE `emailusers`
  ADD CONSTRAINT `emailusers_ibfk_1` FOREIGN KEY (`userID`) REFERENCES `users` (`userID`) ON DELETE CASCADE;

--
-- Begrænsninger for tabel `genrejunction`
--
ALTER TABLE `genrejunction`
  ADD CONSTRAINT `GenreJunction_ibfk_1` FOREIGN KEY (`genreID`) REFERENCES `genres` (`genreID`),
  ADD CONSTRAINT `GenreJunction_ibfk_2` FOREIGN KEY (`movieID`) REFERENCES `movies` (`movieID`);

--
-- Begrænsninger for tabel `movies`
--
ALTER TABLE `movies`
  ADD CONSTRAINT `Movies_ibfk_1` FOREIGN KEY (`directorID`) REFERENCES `directors` (`directorID`);

--
-- Begrænsninger for tabel `starjunction`
--
ALTER TABLE `starjunction`
  ADD CONSTRAINT `StarJunction_ibfk_1` FOREIGN KEY (`movieID`) REFERENCES `movies` (`movieID`),
  ADD CONSTRAINT `StarJunction_ibfk_2` FOREIGN KEY (`starID`) REFERENCES `stars` (`starID`);

--
-- Begrænsninger for tabel `users`
--
ALTER TABLE `users`
  ADD CONSTRAINT `Users_ibfk_1` FOREIGN KEY (`firstNameID`) REFERENCES `firstnames` (`firstNameID`),
  ADD CONSTRAINT `Users_ibfk_2` FOREIGN KEY (`lastNameID`) REFERENCES `lastnames` (`lastNameID`),
  ADD CONSTRAINT `Users_ibfk_3` FOREIGN KEY (`addressID`) REFERENCES `addressjunction` (`ID`);

--
-- Begrænsninger for tabel `writerjunction`
--
ALTER TABLE `writerjunction`
  ADD CONSTRAINT `WriterJunction_ibfk_1` FOREIGN KEY (`movieID`) REFERENCES `movies` (`movieID`),
  ADD CONSTRAINT `WriterJunction_ibfk_2` FOREIGN KEY (`writerID`) REFERENCES `writers` (`writerID`);
--
-- Database: `test`
--
CREATE DATABASE IF NOT EXISTS `test` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `test`;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
