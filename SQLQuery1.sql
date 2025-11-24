-- Bang Admin
CREATE TABLE [dbo].[Admin] (
    [ID]           INT IDENTITY(1,1) NOT NULL,
    [NameUser]     NVARCHAR(100) NOT NULL,
    [RoleUser]     NVARCHAR(50)  NULL,
    [PasswordUser] NVARCHAR(100) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

-- Bang Department (tuong tu Category)
CREATE TABLE [dbo].[Department] (
    [DeptID]     INT IDENTITY(1,1) NOT NULL,
    [DeptCode]   NVARCHAR(20) NOT NULL,
    [DeptName]   NVARCHAR(MAX) NULL,
    PRIMARY KEY CLUSTERED ([DeptCode] ASC)
);

-- Bang Student (tu Customer)
CREATE TABLE [dbo].[Student] (
    [StudentID] INT IDENTITY(1,1) NOT NULL,
    [FullName]  NVARCHAR(100) NOT NULL,
    [Phone]     NVARCHAR(15)  NULL,
    [Email]     NVARCHAR(100) NULL,
    PRIMARY KEY CLUSTERED ([StudentID] ASC)
);

-- Bang Subject (tu Products)
CREATE TABLE [dbo].[Subject] (
    [SubjectID]    INT IDENTITY(1,1) NOT NULL,
    [SubjectName]  NVARCHAR(200) NULL,
    [DeptCode]     NVARCHAR(20) NULL,
    [Credits]      INT NULL,
    [StartDate]    DATE NULL,
    [ClassTime]    NVARCHAR(50) NULL,
    [Capacity]     INT NULL,
    [Classroom]    NVARCHAR(20) NULL,
    PRIMARY KEY CLUSTERED ([SubjectID] ASC),
    CONSTRAINT [FK_Subject_Department] FOREIGN KEY ([DeptCode]) REFERENCES [dbo].[Department] ([DeptCode])
);

-- Bang Enrollment (tu OrderPro)
CREATE TABLE [dbo].[Enrollment] (
    [EnrollID]     INT IDENTITY(1,1) NOT NULL,
    [EnrollDate]   DATE DEFAULT GETDATE() NULL,
    [StudentID]    INT NULL,
    [Notes]        NVARCHAR(MAX) NULL,
    PRIMARY KEY CLUSTERED ([EnrollID] ASC),
    FOREIGN KEY ([StudentID]) REFERENCES [dbo].[Student] ([StudentID])
);

-- Bang EnrollmentDetail (tu OrderDetail)
CREATE TABLE [dbo].[EnrollmentDetail] (
    [ID]          INT IDENTITY(1,1) NOT NULL,
    [SubjectID]   INT NULL,
    [EnrollID]    INT NULL,
    [Status]      NVARCHAR(50) DEFAULT N'Đã đăng ký' NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([SubjectID]) REFERENCES [dbo].[Subject] ([SubjectID]),
    FOREIGN KEY ([EnrollID]) REFERENCES [dbo].[Enrollment] ([EnrollID])
);
