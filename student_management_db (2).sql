-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 09, 2024 at 12:37 AM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `student_management_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `ledger_entries`
--

CREATE TABLE `ledger_entries` (
  `ID` int(11) NOT NULL,
  `UserID` int(11) NOT NULL,
  `SchoolYear` varchar(50) NOT NULL,
  `Term` varchar(50) NOT NULL,
  `DatePaid` date NOT NULL,
  `Particulars` varchar(255) DEFAULT NULL,
  `Credit` decimal(10,2) NOT NULL,
  `Balance` decimal(10,2) NOT NULL,
  `OldAccounts` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `payment_schedules`
--

CREATE TABLE `payment_schedules` (
  `ID` int(11) NOT NULL,
  `UserID` int(11) NOT NULL,
  `SchoolYear` varchar(50) NOT NULL,
  `Term` varchar(50) NOT NULL,
  `PaymentSchedule` varchar(50) NOT NULL,
  `RequiredAmount` decimal(10,2) NOT NULL,
  `CumulativeBalance` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbladmins`
--

CREATE TABLE `tbladmins` (
  `ID` int(11) NOT NULL,
  `Firstname` varchar(100) NOT NULL,
  `Lastname` varchar(100) NOT NULL,
  `Email` varchar(150) NOT NULL,
  `ContactNo` varchar(20) DEFAULT NULL,
  `Password` varchar(255) NOT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT current_timestamp(),
  `UpdatedAt` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tblstudents`
--

CREATE TABLE `tblstudents` (
  `ID` int(10) NOT NULL,
  `Firstname` varchar(100) NOT NULL,
  `Lastname` varchar(100) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `ContactNo` varchar(100) NOT NULL,
  `Course` varchar(100) DEFAULT NULL,
  `PresentCount` int(11) DEFAULT 0,
  `AbsentCount` int(11) DEFAULT 0,
  `status` varchar(255) DEFAULT NULL,
  `LastEnrolledTerm` varchar(100) DEFAULT NULL,
  `CourseYear` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tblstudents`
--

INSERT INTO `tblstudents` (`ID`, `Firstname`, `Lastname`, `Email`, `ContactNo`, `Course`, `PresentCount`, `AbsentCount`, `status`, `LastEnrolledTerm`, `CourseYear`) VALUES
(17, 'Mark', 'Anthony', 'mark@gmail.com', '0972174617', 'BSCS', 1, 2, NULL, NULL, NULL),
(19, 'drei', 'jaba', 'test1@gmail.com', '89772732821', 'BSIT', 0, 0, NULL, NULL, NULL),
(22, 'Lorinzu', 'loren', 'ooouavjanj', 'zkjbjnlk', 'BMMA', 0, 0, NULL, NULL, NULL),
(24, 'Derick', 'love', 'Angel', 'heart ehart', 'BSIT', 2, 0, NULL, NULL, NULL),
(25, 'Joshua', 'Daguio', 'daguio@gmail.com', '134252542141', 'BSIT', 0, 0, NULL, NULL, NULL),
(26, 'Nathalia', 'Arizo', 'Arizo@gmail.com', '124111', 'BSCS', 0, 0, NULL, NULL, NULL),
(27, 'Cristan', 'Nuguid', 'nuguid@gmail.com', '414351141', 'BSIT', 0, 0, NULL, NULL, NULL),
(28, 'Mark', 'Soberano', 'hjkadhinakl121', 'ad54121', 'BSIT', 1, 0, NULL, NULL, NULL),
(29, 'yuji', 'megumi', 'yuji@gmail.com', '01389214141', 'BSIT', 0, 0, NULL, NULL, NULL),
(30, 'Derick', 'Mark', 'loren', 'cristan', 'BSIT', 0, 0, NULL, NULL, NULL),
(32, 'Nuguid', 'Mark', '2131`22', '`2131`23435', 'BSCS', 0, 0, NULL, NULL, NULL),
(35, 'Popoytubero', 'Mark', 'markushighway@gmail.com', '0941627141', 'BMMA', 0, 0, NULL, NULL, NULL),
(36, 'kiffy', 'sgefadf', '233rezsdab', '2313234', 'BSIT', 0, 0, NULL, NULL, NULL),
(37, 'kiff2', 'makrjakjnf', 'sgahjoidsuhjgfcv ', '987653456', 'BSCS', 0, 0, NULL, NULL, NULL),
(38, 'kiff3', 'jadkajvabhja', 'fasfsagas', '241141', 'BSCS', 0, 0, NULL, NULL, NULL),
(39, 'kiff4', 'hgadkjchjasnfa', 'dvasgagvs', '241414141', 'BSCS', 0, 0, NULL, NULL, NULL),
(40, 'kiff5', 'sfsaga', 'gasdsas', 'asdgaa', 'BSCS', 0, 0, NULL, NULL, NULL),
(41, 'kiff6', 'sgagea', 'fsgafs', 'fSSge', 'BSIT', 0, 0, NULL, NULL, NULL),
(42, 'Elon', 'musk', 'musk@gmail.com', '84161731141', 'BSCS', 0, 0, NULL, NULL, NULL),
(43, 'Jonathan', 'Morana', 'jojo@gmail.com', '0123141421312', 'BSIT', 0, 0, NULL, NULL, NULL),
(44, 'Satoruo1', 'Gojo1', 'gojo12@gmail.com', '09621631413', 'BSIT', 0, 0, NULL, NULL, NULL);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `ledger_entries`
--
ALTER TABLE `ledger_entries`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `UserID` (`UserID`);

--
-- Indexes for table `payment_schedules`
--
ALTER TABLE `payment_schedules`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `UserID` (`UserID`);

--
-- Indexes for table `tbladmins`
--
ALTER TABLE `tbladmins`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `Email` (`Email`);

--
-- Indexes for table `tblstudents`
--
ALTER TABLE `tblstudents`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `ledger_entries`
--
ALTER TABLE `ledger_entries`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `payment_schedules`
--
ALTER TABLE `payment_schedules`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tbladmins`
--
ALTER TABLE `tbladmins`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `tblstudents`
--
ALTER TABLE `tblstudents`
  MODIFY `ID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=45;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `ledger_entries`
--
ALTER TABLE `ledger_entries`
  ADD CONSTRAINT `ledger_entries_ibfk_1` FOREIGN KEY (`UserID`) REFERENCES `tblstudents` (`ID`);

--
-- Constraints for table `payment_schedules`
--
ALTER TABLE `payment_schedules`
  ADD CONSTRAINT `payment_schedules_ibfk_1` FOREIGN KEY (`UserID`) REFERENCES `tblstudents` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
