-- Create Citizen table
CREATE TABLE Citizens (
    CitizenID INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Phone NVARCHAR(20) NOT NULL,
    DateOfBirth DATE,
    Address NVARCHAR(255)
);

-- Create ServiceRequest table
CREATE TABLE ServiceRequests (
    RequestID INT PRIMARY KEY IDENTITY(1,1),
    CitizenID INT NOT NULL,
    RequestDate DATETIME NOT NULL DEFAULT GETDATE(),
    ServiceType NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500),
    Status NVARCHAR(50) NOT NULL DEFAULT 'Pending',
    FOREIGN KEY (CitizenID) REFERENCES Citizens(CitizenID)
);

-- Create Report table
CREATE TABLE Reports (
    ReportID INT PRIMARY KEY IDENTITY(1,1),
    CitizenID INT NOT NULL,
    ReportType NVARCHAR(100) NOT NULL,
    Details NVARCHAR(500),
    SubmissionDate DATETIME NOT NULL DEFAULT GETDATE(),
    Status NVARCHAR(50) NOT NULL DEFAULT 'Pending',
    FOREIGN KEY (CitizenID) REFERENCES Citizens(CitizenID)
);

-- Create Staff table
CREATE TABLE Staff (
    StaffID INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    Position NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Phone NVARCHAR(20) NOT NULL,
    DateOfHire DATE NOT NULL
);

-- Create User table (Optional, for authentication if using Identity)
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) NOT NULL,
    StaffID INT,
    FOREIGN KEY (StaffID) REFERENCES Staff(StaffID)
);

-- Create necessary indexes for better performance (Optional)
CREATE INDEX IX_Citizen_Email ON Citizens(Email);
CREATE INDEX IX_ServiceRequests_CitizenID ON ServiceRequests(CitizenID);
CREATE INDEX IX_Reports_CitizenID ON Reports(CitizenID);
CREATE INDEX IX_Staff_Email ON Staff(Email);
