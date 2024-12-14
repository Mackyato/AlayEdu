-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 14, 2024 at 02:07 AM
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
-- Table structure for table `tblgrades`
--

CREATE TABLE `tblgrades` (
  `GradeID` int(11) NOT NULL,
  `StudentID` int(11) NOT NULL,
  `SubjectName` varchar(100) NOT NULL,
  `Term` varchar(50) NOT NULL,
  `SchoolYear` varchar(50) NOT NULL,
  `Grade` decimal(5,2) NOT NULL,
  `Remarks` varchar(50) NOT NULL,
  `DateRecorded` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tblgrades`
--

INSERT INTO `tblgrades` (`GradeID`, `StudentID`, `SubjectName`, `Term`, `SchoolYear`, `Grade`, `Remarks`, `DateRecorded`) VALUES
(1, 1, 'Programming 1', 'First Semester, Midterm', '2024-2025', 89.50, 'Passed', '2024-12-11 10:14:50'),
(2, 1, 'Data Structures', 'First Semester, Finals', '2024-2025', 92.00, 'Passed', '2024-12-11 10:14:50'),
(3, 2, 'Programming 1', 'First Semester, Midterm', '2023-2024', 75.00, 'Passed', '2024-12-11 10:14:50'),
(4, 2, 'Algorithms', 'First Semester, Finals', '2023-2024', 68.50, 'Failed', '2024-12-11 10:14:50'),
(5, 3, 'Database Systems', 'Second Semester, Midterm', '2024-2025', 80.00, 'Passed', '2024-12-11 10:14:50'),
(6, 3, 'Software Engineering', 'Second Semester, Finals', '2024-2025', 85.00, 'Passed', '2024-12-11 10:14:50'),
(7, 1, 'Object-Oriented Programming', 'Second Semester, Midterm', '2024-2025', 78.00, 'Passed', '2024-12-11 10:14:50'),
(8, 1, 'Web Development', 'Second Semester, Finals', '2024-2025', 88.50, 'Passed', '2024-12-11 10:14:50'),
(9, 2, 'Network Security', 'First Semester, Midterm', '2024-2025', 73.00, 'Failed', '2024-12-11 10:14:50'),
(10, 3, 'Operating Systems', 'Second Semester, Midterm', '2023-2024', 81.50, 'Passed', '2024-12-11 10:14:50'),
(11, 3, 'Capstone Project', 'Second Semester, Finals', '2023-2024', 95.00, 'Passed', '2024-12-11 10:14:50');

-- --------------------------------------------------------

--
-- Table structure for table `tblledger`
--

CREATE TABLE `tblledger` (
  `ID` int(11) NOT NULL,
  `UserID` int(11) NOT NULL,
  `SchoolYear` varchar(10) NOT NULL,
  `Term` varchar(20) NOT NULL,
  `DatePaid` date NOT NULL,
  `Particulars` varchar(255) DEFAULT NULL,
  `Credit` decimal(10,2) DEFAULT NULL,
  `Balance` decimal(10,2) DEFAULT NULL,
  `OldAccounts` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tblledger`
--

INSERT INTO `tblledger` (`ID`, `UserID`, `SchoolYear`, `Term`, `DatePaid`, `Particulars`, `Credit`, `Balance`, `OldAccounts`) VALUES
(1, 1, '2024-2025', 'First Term', '2024-01-15', 'Tuition Fee', 20000.00, 5000.00, 0.00),
(2, 1, '2024-2025', 'First Term', '2024-02-15', 'Laboratory Fee', 3000.00, 2000.00, 0.00),
(3, 2, '2024-2025', 'Second Term', '2024-03-10', 'Tuition Fee', 25000.00, 0.00, 500.00),
(4, 3, '2023-2024', 'Third Term', '2023-12-05', 'Miscellaneous Fee', 5000.00, 2000.00, 1000.00),
(5, 3, '2023-2024', 'Third Term', '2023-12-20', 'Tuition Fee', 30000.00, 5000.00, 0.00),
(6, 4, '2024-2025', 'First Term', '2024-01-12', 'Tuition Fee', 15000.00, 1000.00, 0.00),
(7, 5, '2024-2025', 'Second Term', '2024-02-25', 'Laboratory Fee', 4000.00, 0.00, 200.00),
(8, 6, '2023-2024', 'First Term', '2023-10-10', 'Tuition Fee', 22000.00, 5000.00, 0.00),
(9, 6, '2023-2024', 'Second Term', '2023-11-15', 'Miscellaneous Fee', 3000.00, 500.00, 0.00),
(10, 7, '2022-2023', 'Third Term', '2022-12-01', 'Tuition Fee', 25000.00, 0.00, 0.00),
(11, 8, '2024-2025', 'First Term', '2024-01-18', 'Tuition Fee', 18000.00, 1000.00, 0.00),
(12, 8, '2024-2025', 'Second Term', '2024-03-01', 'Miscellaneous Fee', 2000.00, 0.00, 500.00),
(13, 9, '2023-2024', 'Fourth Term', '2023-09-15', 'Tuition Fee', 30000.00, 5000.00, 0.00),
(14, 10, '2024-2025', 'First Term', '2024-01-05', 'Laboratory Fee', 5000.00, 200.00, 100.00),
(15, 10, '2024-2025', 'Second Term', '2024-02-10', 'Tuition Fee', 27000.00, 0.00, 0.00),
(16, 11, '2024-2025', 'First Term', '2024-01-15', 'Tuition Fee', 20000.00, 10000.00, 0.00),
(17, 11, '2024-2025', 'Second Term', '2024-02-20', 'Library Fee', 5000.00, 5000.00, 0.00),
(18, 12, '2023-2024', 'First Term', '2023-09-12', 'Tuition Fee', 25000.00, 0.00, 2000.00),
(19, 13, '2023-2024', 'Third Term', '2023-12-10', 'Laboratory Fee', 3000.00, 1000.00, 500.00),
(20, 13, '2023-2024', 'Third Term', '2023-12-25', 'Tuition Fee', 35000.00, 5000.00, 0.00),
(21, 14, '2024-2025', 'Second Term', '2024-02-15', 'Miscellaneous Fee', 4000.00, 0.00, 300.00),
(22, 15, '2024-2025', 'First Term', '2024-01-20', 'Tuition Fee', 28000.00, 7000.00, 0.00),
(23, 15, '2024-2025', 'Second Term', '2024-03-01', 'Library Fee', 2000.00, 500.00, 0.00),
(24, 16, '2022-2023', 'Fourth Term', '2022-10-15', 'Tuition Fee', 30000.00, 5000.00, 0.00),
(25, 16, '2022-2023', 'Fourth Term', '2022-10-20', 'Laboratory Fee', 5000.00, 200.00, 100.00),
(26, 17, '2023-2024', 'First Term', '2023-09-10', 'Tuition Fee', 18000.00, 3000.00, 0.00),
(27, 17, '2023-2024', 'Second Term', '2023-11-01', 'Miscellaneous Fee', 3000.00, 0.00, 500.00),
(28, 18, '2023-2024', 'Fourth Term', '2023-08-12', 'Tuition Fee', 40000.00, 5000.00, 0.00),
(29, 19, '2024-2025', 'First Term', '2024-01-18', 'Library Fee', 2000.00, 0.00, 300.00),
(30, 20, '2023-2024', 'Second Term', '2023-11-12', 'Tuition Fee', 27000.00, 0.00, 0.00),
(31, 21, '2024-2025', 'First Term', '2024-01-12', 'Tuition Fee', 15000.00, 5000.00, 1000.00),
(32, 21, '2024-2025', 'Second Term', '2024-02-25', 'Miscellaneous Fee', 3000.00, 500.00, 0.00),
(33, 22, '2023-2024', 'Third Term', '2023-12-15', 'Tuition Fee', 18000.00, 5000.00, 0.00),
(34, 23, '2024-2025', 'Second Term', '2024-03-10', 'Laboratory Fee', 4000.00, 0.00, 200.00),
(35, 24, '2023-2024', 'First Term', '2023-10-05', 'Tuition Fee', 25000.00, 1000.00, 0.00),
(36, 25, '2024-2025', 'Third Term', '2024-02-15', 'Miscellaneous Fee', 4000.00, 0.00, 300.00),
(37, 26, '2024-2025', 'First Term', '2024-01-10', 'Library Fee', 2000.00, 500.00, 0.00),
(38, 27, '2023-2024', 'Third Term', '2023-12-12', 'Tuition Fee', 35000.00, 0.00, 1000.00),
(39, 28, '2023-2024', 'First Term', '2023-09-15', 'Tuition Fee', 20000.00, 3000.00, 500.00),
(40, 29, '2023-2024', 'Fourth Term', '2023-08-10', 'Miscellaneous Fee', 5000.00, 2000.00, 0.00);

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
(1, 'John', 'Doe', 'johndoe@example.com', '09171234567', 'BSIT', 3, 1, 'Regular', '2024-2025', 'First Year'),
(2, 'Jane', 'Smith', 'janesmith@example.com', '09181234567', 'BSCS', 1, 2, 'Irregular', '2024-2025', 'Second Year'),
(3, 'Alice', 'Johnson', 'alicejohnson@example.com', '09221234567', 'BMMA', 2, 1, 'Regular', '2023-2024', 'Third Year'),
(4, 'Bob', 'Brown', 'bobbrown@example.com', '09231234567', 'BSIT', 1, 3, 'Irregular', '2024-2025', 'First Year'),
(5, 'Charlie', 'Davis', 'charliedavis@example.com', '09241234567', 'BSCS', 4, 0, 'Regular', '2023-2024', 'Fourth Year'),
(6, 'Emily', 'Clark', 'emilyclark@example.com', '09191234567', 'BMMA', 1, 2, 'Irregular', '2023-2024', 'Second Year'),
(7, 'Michael', 'Garcia', 'michaelgarcia@example.com', '09251234567', 'BSIT', 3, 1, 'Regular', '2022-2023', 'Fourth Year'),
(8, 'Sarah', 'Martinez', 'sarahmartinez@example.com', '09301234567', 'BSCS', 0, 4, 'Irregular', '2024-2025', 'First Year'),
(9, 'David', 'Lee', 'davidlee@example.com', '09311234567', 'BMMA', 5, 0, 'Regular', '2023-2024', 'Fourth Year'),
(10, 'Sophia', 'Walker', 'sophiawalker@example.com', '09321234567', 'BSIT', 1, 1, 'Irregular', '2024-2025', 'Second Year'),
(11, 'Liam', 'Harrison', 'liamharrison@example.com', '09191234568', 'BSCS', 2, 0, 'Regular', '2024-2025', 'Second Year'),
(12, 'Noah', 'Adams', 'noahadams@example.com', '09271234568', 'BSIT', 0, 3, 'Irregular', '2023-2024', 'Third Year'),
(13, 'Emma', 'Turner', 'emmaturner@example.com', '09321234568', 'BMMA', 1, 1, 'Irregular', '2022-2023', 'First Year'),
(14, 'Olivia', 'Carter', 'oliviacarter@example.com', '09431234568', 'BSCS', 4, 0, 'Regular', '2024-2025', 'Fourth Year'),
(15, 'Lucas', 'Mitchell', 'lucasmitchell@example.com', '09181234568', 'BMMA', 3, 2, 'Regular', '2023-2024', 'Second Year'),
(16, 'Ava', 'White', 'avawhite@example.com', '09251234568', 'BSIT', 1, 3, 'Irregular', '2022-2023', 'Third Year'),
(17, 'Isabella', 'Lopez', 'isabellalopez@example.com', '09361234568', 'BSCS', 5, 0, 'Regular', '2024-2025', 'First Year'),
(18, 'Ethan', 'Clarkson', 'ethanclarkson@example.com', '09191234568', 'BMMA', 0, 4, 'Irregular', '2023-2024', 'Second Year'),
(19, 'Mia', 'Sanchez', 'miasanchez@example.com', '09411234568', 'BSIT', 2, 2, 'Regular', '2022-2023', 'Fourth Year'),
(20, 'James', 'Scott', 'jamesscott@example.com', '09321234568', 'BSCS', 1, 0, 'Irregular', '2024-2025', 'Second Year'),
(21, 'William', 'Taylor', 'williamtaylor@example.com', '09381234568', 'BSIT', 2, 0, 'Regular', '2023-2024', 'First Year'),
(22, 'Sophia', 'Anderson', 'sophiaanderson@example.com', '09481234568', 'BMMA', 3, 0, 'Regular', '2024-2025', 'Third Year'),
(23, 'Benjamin', 'Jackson', 'benjaminjackson@example.com', '09171234568', 'BSCS', 1, 3, 'Irregular', '2022-2023', 'Second Year'),
(24, 'Amelia', 'Nelson', 'amelianelson@example.com', '09281234568', 'BSIT', 0, 2, 'Irregular', '2023-2024', 'First Year'),
(25, 'Elijah', 'Garcia', 'elijahgarcia@example.com', '09371234568', 'BMMA', 2, 1, 'Regular', '2024-2025', 'Fourth Year'),
(26, 'Charlotte', 'Martinez', 'charlottemartinez@example.com', '09181234569', 'BSCS', 5, 0, 'Regular', '2022-2023', 'Third Year'),
(27, 'Henry', 'Brown', 'henrybrown@example.com', '09291234569', 'BSIT', 1, 0, 'Irregular', '2023-2024', 'Second Year'),
(28, 'Evelyn', 'Hernandez', 'evelynhernandez@example.com', '09381234569', 'BMMA', 3, 1, 'Regular', '2024-2025', 'Third Year'),
(29, 'Alexander', 'Ramirez', 'alexanderramirez@example.com', '09491234569', 'BSCS', 4, 0, 'Regular', '2023-2024', 'First Year'),
(30, 'Harper', 'Moore', 'harpermoore@example.com', '09171234569', 'BSIT', 2, 2, 'Regular', '2022-2023', 'Fourth Year');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tblgrades`
--
ALTER TABLE `tblgrades`
  ADD PRIMARY KEY (`GradeID`),
  ADD KEY `StudentID` (`StudentID`);

--
-- Indexes for table `tblledger`
--
ALTER TABLE `tblledger`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `fk_userid` (`UserID`);

--
-- Indexes for table `tblstudents`
--
ALTER TABLE `tblstudents`
  ADD PRIMARY KEY (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tblgrades`
--
ALTER TABLE `tblgrades`
  MODIFY `GradeID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `tblledger`
--
ALTER TABLE `tblledger`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- AUTO_INCREMENT for table `tblstudents`
--
ALTER TABLE `tblstudents`
  MODIFY `ID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=45;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `tblgrades`
--
ALTER TABLE `tblgrades`
  ADD CONSTRAINT `tblgrades_ibfk_1` FOREIGN KEY (`StudentID`) REFERENCES `tblstudents` (`ID`);

--
-- Constraints for table `tblledger`
--
ALTER TABLE `tblledger`
  ADD CONSTRAINT `fk_userid` FOREIGN KEY (`UserID`) REFERENCES `tblstudents` (`ID`) ON DELETE CASCADE,
  ADD CONSTRAINT `tblledger_ibfk_1` FOREIGN KEY (`UserID`) REFERENCES `tblstudents` (`ID`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
