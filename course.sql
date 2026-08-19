CREATE TABLE course (
    course_id INT PRIMARY KEY IDENTITY(1,1),
    course_name VARCHAR(100) NOT NULL,
    Credits INT CHECK (Credits > 0 AND Credits <= 6),
    Instructor VARCHAR(100),
    Room VARCHAR(20),
    Semester VARCHAR(20),
    student_id VARCHAR(100),  -- Foreign key from users table
    CONSTRAINT FK_Course_Users FOREIGN KEY (student_id) 
        REFERENCES users(student_id) 
        ON DELETE CASCADE 
        ON UPDATE CASCADE
);

INSERT INTO course (course_name, Credits, Instructor, Room, Semester, student_id) VALUES
('Introduction to Database', 3, 'Dr. Smith', 'Room 101', 'Fall 2026', 'admin'),
('Data Structures', 4, 'Prof. Johnson', 'Room 202', 'Fall 2026', 'admin'),
('Algorithms', 4, 'Dr. Williams', 'Room 203', 'Spring 2027', 'admin'),
('Operating Systems', 3, 'Prof. Brown', 'Room 105', 'Spring 2027', 'admin'),
('Computer Networks', 3, 'Dr. Davis', 'Room 201', 'Fall 2026', '24-58051-2'),
('Software Engineering', 3, 'Prof. Miller', 'Room 204', 'Spring 2027', '24-58051-2'),
('Machine Learning', 4, 'Dr. Wilson', 'Room 302', 'Fall 2026', '24-58051-2'),
('Artificial Intelligence', 4, 'Prof. Taylor', 'Room 303', 'Spring 2027', '24-58051-2'),
('Web Development', 3, 'Dr. Anderson', 'Room 205', 'Fall 2026', 'admin'),
('Cyber Security', 3, 'Prof. Martinez', 'Room 304', 'Spring 2027', 'admin');


