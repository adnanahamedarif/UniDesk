CREATE TABLE classes (
    ClassId INT IDENTITY(1,1) PRIMARY KEY,
    CourseName VARCHAR(100) NOT NULL,
    InstructorName VARCHAR(100) NOT NULL ,
    RoomNumber VARCHAR(50) NOT NULL,
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    Day VARCHAR(20) NOT NULL,
    ClassType VARCHAR(20) NOT NULL,
);



INSERT INTO Classes
(CourseName, InstructorName, RoomNumber, StartTime, EndTime, Day, ClassType)
VALUES
('Object Oriented Programming 1', 'Dr. Rahman', 'Room 402', '09:40', '11:10', 'Sunday', 'Lecture'),

('Database Management System', 'Mr. Karim', 'Room 305', '11:20', '12:50', 'Monday', 'Lecture'),

('OOP 2 Lab', 'Mr. Hasan', 'Lab 3', '01:00', '03:30', 'Tuesday', 'Lab');


SELECT 
    ClassID,
    CourseName,
    InstructorName,
    RoomNumber,
    CONVERT(VARCHAR(5), StartTime, 108) AS StartTime,
    CONVERT(VARCHAR(5), EndTime, 108) AS EndTime,
    Day,
    ClassType
FROM Classes;


select * from classes;