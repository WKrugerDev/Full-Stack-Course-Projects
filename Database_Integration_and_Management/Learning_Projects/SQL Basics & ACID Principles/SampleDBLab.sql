CREATE DATABASE SampleDB;

CREATE TABLE Users (
    UserID SERIAL PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Email VARCHAR(100),
    Age INT
);

INSERT INTO Users (firstname, lastname, email, age) VALUES
    ('Aisha','Khan','aisha.khan@example.com', 29),
    ('Carlos','Garcia','carlos.garcia@example.com', 35),
    ('Mei','Chen','mei.chen@example.com', 24);

INSERT INTO Users (firstname, lastname, email, age) VALUES ('Arjun','Patel','arjun.patel@example.com',41);

UPDATE Users SET Age = 26 WHERE firstname = 'Mei';

SELECT * FROM Users;

DELETE FROM Users WHERE lastname = 'Garcia';

SELECT * FROM Users;

Begin;

UPDATE Users
SET age = 30
WHERE firstname = 'Aisha';

COMMIT;

ROLLBACK;