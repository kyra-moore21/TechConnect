--CREATE DATABASE TECHCONNECTDB;
--USE TECHCONNECTDB;

--CREATE TABLE USERS (
--	ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
--	FirebaseID  NVARCHAR(255) NOT NULL,
--	Email NVARCHAR(255) NOT NULL,
--	FullName NVARCHAR(255) NOT NULL,
--	CreatedAt NVARCHAR(255) NOT NULL DEFAULT GETDATE(),
--	UpdatedAt NVARCHAR(255) NOT NULL DEFAULT GETDATE(),
--	[Status] NVARCHAR(255) NOT NULL CHECK ([Status] IN ('Active', 'Inactive', 'Pending')),
--	CONSTRAINT UQ_Email UNIQUE (Email)
--)

--ALTER TABLE USERS
--DROP CONSTRAINT DF__USERS__UpdatedAt__4BAC3F29;
--ALTER TABLE USERS
--ALTER COLUMN UpdatedAt DATETIME2 NOT NULL;



--ALTER COLUMN CreatedAt DATETIME2 NOT NULL;

--CREATE TABLE POSTS (
--	ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
--	UserID INT FOREIGN KEY REFERENCES [USERS](Id),
--	Title NVARCHAR(255),
--	[Description] NVARCHAR(MAX),
--	CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
--    UpdatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),

--)


--CREATE TABLE SKILLS (
--ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
--SkillName NVARCHAR(255) NOT NULL UNIQUE
--);

--CREATE TABLE USERSKILLS(
-- UserID INT NOT NULL FOREIGN KEY REFERENCES USERS(ID),
-- SkillID INT NOT NULL FOREIGN KEY REFERENCES SKILLS(ID),
-- PRIMARY KEY (UserID, SkillID)
--);

--CREATE TABLE POST_SKILLS(
--PostID INT NOT NULL FOREIGN KEY REFERENCES POSTS(ID),
-- SkillID INT NOT NULL FOREIGN KEY REFERENCES SKILLS(ID),
-- PRIMARY KEY (PostID, SkillID)
--);

--CREATE TABLE APPLICATION_SKILLS (
--    ApplicationID INT NOT NULL FOREIGN KEY REFERENCES APPLICATIONS(ID),
--    SkillID INT NOT NULL FOREIGN KEY REFERENCES SKILLS(ID),
--    PRIMARY KEY (ApplicationID, SkillID)
--);

--CREATE TABLE APPLICATIONS (
--ID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
--PostID INT NOT NULL FOREIGN KEY REFERENCES POSTS(ID),
--UserID INT NOT NULL FOREIGN KEY REFERENCES USERS(ID),
--AppDate DATETIME2 NOT NULL DEFAULT GETDATE(),
--[Status] NVARCHAR(255) NOT NULL DEFAULT 'Pending',
--[Message] NVARCHAR(MAX) NULL
--)

--CREATE TABLE USERPROFILES(
--USERID INT NOT NULL FOREIGN KEY REFERENCES USERS(ID),
--AboutMe NVARCHAR(MAX) NULL,
--ProfilePicture NVARCHAR(255) NULL,
--SocialLinks NVARCHAR(MAX) NULL,
--CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
--UpdatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
--PRIMARY KEY (UserID)
--)