CREATE TABLE dbo.CGPA
(
    cgpa_id INT IDENTITY(1,1) PRIMARY KEY,
    student_id VARCHAR(100) NOT NULL, -- users টেবিলের মতো একই datatype
    course_name NVARCHAR(150) NOT NULL,
    credit INT NOT NULL,
    grade VARCHAR(2) NOT NULL,
    grade_point DECIMAL(3,2) NOT NULL,

    CONSTRAINT FK_CGPA_users
        FOREIGN KEY (student_id)
        REFERENCES dbo.users(student_id),

    CONSTRAINT CK_CGPA_credit
        CHECK (credit > 0),

    CONSTRAINT CK_CGPA_grade
        CHECK (grade IN
        ('A+', 'A', 'B+', 'B', 'C+', 'C', 'D+', 'D', 'F')),

    CONSTRAINT CK_CGPA_grade_point
        CHECK
        (
            (grade = 'A+' AND grade_point = 4.00) OR
            (grade = 'A'  AND grade_point = 3.75) OR
            (grade = 'B+' AND grade_point = 3.50) OR
            (grade = 'B'  AND grade_point = 3.25) OR
            (grade = 'C+' AND grade_point = 3.00) OR
            (grade = 'C'  AND grade_point = 2.75) OR
            (grade = 'D+' AND grade_point = 2.50) OR
            (grade = 'D'  AND grade_point = 2.25) OR
            (grade = 'F'  AND grade_point = 0.00)
        )
);


INSERT INTO dbo.CGPA
    (student_id, course_name, credit, grade, grade_point)
VALUES
    ('24-58051-2', 'Object Oriented Programming', 3, 'A+', 4.00),
    ('24-58051-2', 'Database Management System', 3, 'A', 3.75),
    ('24-58051-2', 'Data Structures', 3, 'B+', 3.50),
    ('24-58051-2', 'Mathematics', 2, 'B', 3.25);

    SELECT *
FROM dbo.CGPA;