CREATE TABLE ToDoList (
    Serial INT IDENTITY(1,1) PRIMARY KEY,
    Task NVARCHAR(500) NOT NULL,
    TaskDate DATETIME2 NOT NULL,
    Status NVARCHAR(50) NOT NULL DEFAULT 'Pending'
);

SELECT * FROM ToDoList;

INSERT INTO ToDoList (Task, TaskDate, Status) 
VALUES 
    ('Review code changes', '2026-08-04', 'Pending'),
    ('Update documentation', '2026-08-06', 'Pending'),
    ('Fix bug #1234', '2026-08-04', 'Completed'),
    ('Send weekly status email', '2026-08-07', 'Pending');