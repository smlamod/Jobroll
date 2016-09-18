USE master
IF exists(SELECT * FROM sys.databases WHERE name='JB')
DROP DATABASE JB
GO
CREATE DATABASE JB
GO
USE JB

CREATE TABLE [Users]
(
	[UserId]			UNIQUEIDENTIFIER NOT NULL,
	[Role]			bit not null,

	[UserName]		nvarchar(max) not null,
	[Email]			nvarchar(max) not null,
	[PasswordHash]	nvarchar(max) null,
	[SecurityStamp] nvarchar(max) not null,

)
go

ALTER TABLE [Users]
	ADD CONSTRAINT [PKUser] PRIMARY KEY CLUSTERED ([UserId] ASC)
go

CREATE TABLE [Members]
(
	[MemberId]		integer NOT NULL,
	[UserId]		UNIQUEIDENTIFIER NOT NULL,
	[PhoneNumber]	nvarchar(max) NULL,
	[LastName]		nvarchar(max) NULL,
	[FirstMidName]  nvarchar(max) NULL,
	[Profpic]		nvarchar(max) NULL,
	
	[Skills]		nvarchar(max) NULL,

	[Location]		nvarchar(max) NULL,
	[ExpSalary]		float NULL,
)

ALTER TABLE [Members]
	ADD CONSTRAINT [PKMembers] PRIMARY KEY CLUSTERED ([MemberId] ASC)
GO

ALTER TABLE [Members]
	ADD CONSTRAINT [FKMembers] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId])
		ON DELETE NO ACTION
GO

CREATE TABLE [Degree_Member]
(
	[DegreeId]		integer NOT NULL,
	[MemberId]		integer NOT NULL,

	[EduStart]		datetime NULL,
	[EduStop]		datetime NULL,

	[EduDegree]		nvarchar(max) NULL,
	[EduSchool]		nvarchar(max) NULL,
	[EduCity]		nvarchar(max) NULL,
	[EduState]		nvarchar(max) NULL,
	[EduDesc]		nvarchar(max) NULL,
)
GO

ALTER TABLE [Degree_Member]
	ADD CONSTRAINT [PKDegree] PRIMARY KEY CLUSTERED ([DegreeId] ASC)
GO

ALTER TABLE [Degree_Member]
	ADD CONSTRAINT [FKDegree_Member] FOREIGN KEY ([MemberId]) REFERENCES [Members]([MemberId])
		ON DELETE NO ACTION
GO

CREATE TABLE [XP_Member]
(
	[XpId]			integer NOT NULL,
	[MemberId]		integer NOT NULL,
	
	[XpStart]		datetime NULL,
	[XpStop]		datetime NULL,

	[XpPosition]	nvarchar(max) NULL,
	[XpCompany]		nvarchar(max) NULL,
	[XpCity]		nvarchar(max) NULL,
	[XpState]		nvarchar(max) NULL,

	[XpDesc]		nvarchar(max) NULL,
)
GO

ALTER TABLE [XP_Member]
	ADD CONSTRAINT [PKXP] PRIMARY KEY CLUSTERED ([XPId] ASC)
GO

ALTER TABLE [XP_Member]
		ADD CONSTRAINT [FKXP_Member] FOREIGN KEY ([MemberId]) REFERENCES [Members]([MemberId])
		ON DELETE NO ACTION
GO

CREATE TABLE [Companies]
(
	[CompanyId]		int  NOT NULL,
	[UserId]		UNIQUEIDENTIFIER NOT NULL,
	[PhoneNumber]	nvarchar(max) NULL,
	[CompanyName]	nvarchar(max) NULL,
	[CompanyAddr]	nvarchar(max) NULL,
	[CompanyDesc]	nvarchar(max) NULL,
	[CompanyLogo]	nvarchar(max) NULL,
)

ALTER TABLE [Companies]
	ADD CONSTRAINT [PKCompanies] PRIMARY KEY CLUSTERED ([CompanyId] ASC)
GO

ALTER TABLE [Companies]
	ADD CONSTRAINT [FKCompanies] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId])
		ON DELETE NO ACTION
GO

CREATE TABLE [Jobs]
(
	[JobId]			int	NOT NULL,
	[CompanyId]		int	NOT NULL,
	[JobName]		nvarchar(max) NULL,
	[JobDesc]		nvarchar(max) NULL,
	[JobReqt]		nvarchar(max) NULL,
	[JobField]		nvarchar(max) NULL,
	[JobLocation]	nvarchar(max) NULL,
	[JobExpected]	float NOT NULL,
	[JobPublished]	bit NOT NULL,
	[JobStart]		datetime NOT NULL,
	[JobEnd]		datetime NOT NULL,
)

ALTER TABLE [Jobs]
	ADD CONSTRAINT [PKJobs] PRIMARY KEY CLUSTERED ([JobId] ASC)
GO

ALTER TABLE [Jobs]
	ADD CONSTRAINT [FKJobs] FOREIGN KEY ([CompanyId]) REFERENCES [Companies]([CompanyId])
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
GO

CREATE TABLE [ExternalLogins]
(
	[ExternalLoginId]	UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [UserId]			UNIQUEIDENTIFIER NOT NULL, 
    [LoginProvider]		VARCHAR(MAX) NOT NULL, 
    [ProviderKey]		VARCHAR(MAX) NOT NULL,   
)

ALTER TABLE [ExternalLogins]
	ADD CONSTRAINT [FKEXTERNAL] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId])
GO

-- SEED

INSERT INTO [Users] values ('95e29d28-a460-4f3a-864d-52a1518a1530',0,'shawn.lamod@gmail.com','shawn.lamod@gmail.com','AM3aeoOGre9Ifs+F2AZkFAPnKnVLQqadbG01e+ZeXbXN/itQXpHkLNlaWefJ5kD1vQ==','8a217ca7-b930-4170-8afa-e021fd57c090')
INSERT INTO [Users] values ('7dd211e1-2d3f-4dfd-a646-dcbac6c4011e',1,'EliFRoush@teleworm.us','EliFRoush@teleworm.us','AAmX7ojcByehBIFmjsIbc/2THsf6xr1bivPItd6WQfvT/qTwJikfcTimtPt2WvAwtA==','00c5ca82-95b0-445f-9c52-5f3b8f1c17f2')
INSERT INTO [Members] values (
1,'95e29d28-a460-4f3a-864d-52a1518a1530'
,'+639062532889',
'Lamod','Shawn L.','',
'Bash Scripting' + CHAR(13) + 'C C# C++ Intel x86 Programming'
,'Manila',30000)

INSERT INTO [Degree_Member] values (
1,1,'2012-06-01','2017-06-1',
'Computer Engineering','Mapua Institute of Technology',
'Manila','Metro Manila',
'Emphasis in Business Analytics' + CHAR(13) + 'Top 5% in class.'
)

INSERT INTO [Degree_Member] values (
2,1,'2017-08-01','2018-06-1',
'Masters of Computer Engineering','Mapua Institute of Technology',
'Manila','Metro Manila',
'Emphasis in Business Analytics' + CHAR(13) + 'Top 5% in class.'
)

INSERT INTO [XP_Member] values (
1,1,'2017-08-01','2018-12-31',
'System Admin','Contoso Ltd',
'Bellevue','Washington',
'Promoted to Lead Analyst after just' + CHAR(13) + 'Promoted to Lead Analyst after just 11 months of employment.'
)

INSERT INTO [Companies] values (
1,'7dd211e1-2d3f-4dfd-a646-dcbac6c4011e'
,'+02452789',
'Contoso Ltd.','Ermita, Manila PH',
'Contoso Ltd. (also known as Contoso and Contoso University) is a fictional company used by Microsoft as an example company and domain.',
'')
INSERT INTO [Jobs] values (
1,1,'Data Scientist',
'Able to extract information from large sets of data',
'Graduate of Applied Mathematics, Computer Science',
'Data Mining','Ermita, Manila',20000,
1,'2016-01-01','2017-01-01'
)
INSERT INTO [ExternalLogins] VALUES
           ('b6ade1fa-aaa1-4792-8e0f-bb20412a029a'
           ,'95e29d28-a460-4f3a-864d-52a1518a1530'
           ,'LinkedIn'
           ,'fhPeWu2OhL')




GO
-- STORED PROCEDURES

CREATE PROCEDURE UserSignUp
(
	@uid  as nvarchar(max),
	@empl as bit,
	@usnm as nvarchar(max),
	@mail as nvarchar(max),
	@pash as nvarchar(max) = NULL,
	@scsp as nvarchar(max)
	
)
as
insert into [Users] values(@uid,@empl,@usnm,@mail,@pash,@scsp)
go

create procedure UserSignIn
(
@mail as nvarchar(max),
@pass as nvarchar(max)
)
as
SELECT u.UserId FROM [Users] u WHERE u.Email=@mail AND u.PasswordHash=@pass
go

create procedure UserGetbyName
(
@usnm as nvarchar(max)
)
AS
SELECT * from [Users] where lower(UserName) = lower(@usnm)
GO

create procedure UserGetbyId
(
@uid as nvarchar(max)
)
AS
select * from [Users] where UserId = @uid
GO

create procedure UserUpdate
(
	@uid as nvarchar(max),
	@usnm as nvarchar(max),
	@mail as nvarchar(max),
	@pash as nvarchar(max) = NULL,
	@scsp as nvarchar(max)
)
as
update [Users] set UserName = @usnm, PasswordHash = @pash, SecurityStamp = @scsp where UserId = @uid
GO

create procedure UserDelete
(
	@uid as nvarchar(max)
)
as
delete from [Users] where UserId = @uid
Go

create procedure UserGetLogInfo
(
	@lpr as nvarchar(max),
	@pky as nvarchar(max)
)
as
select u.* from Users u inner join ExternalLogins l on l.UserId = u.UserId where l.LoginProvider = @lpr and l.ProviderKey = @pky
go

create procedure UserGetELogInfo
(
	@uid as nvarchar(max)
)
as
select LoginProvider, ProviderKey from ExternalLogins where UserId = @uid
go


create procedure UserAddElogin
(
	@eid as nvarchar(max),
	@uid as nvarchar(max),
	@lpr as nvarchar(max),
	@pky as nvarchar(max)
)
as
INSERT INTO  ExternalLogins(ExternalLoginId, UserId, LoginProvider, ProviderKey) values(@eid, @uid, @lpr, @pky)
go

create procedure UserRemoveElogin
(
	@uid as nvarchar(max),
	@lpr as nvarchar(max),
	@pky as nvarchar(max)
)
as
delete from ExternalLogins where UserId = @uid and LoginProvider = @lpr and ProviderKey = @pky
go

create procedure MemberCheck
(
	@uid as nvarchar(max)
)
as
SELECT * FROM [Members] where UserId = @uid
Go

create procedure MemberCreate
(
	@uid as nvarchar(max),
	@pnum as nvarchar(max),
	@lname as nvarchar(max),
	@fname as nvarchar(max),
	
	@skls as nvarchar(max),

	@loc as nvarchar(max),
	@salry as float
)
as
declare @mid as int
set @mid=(select MAX(MemberId) from [Members])+1
insert into [Members] values(@mid,
(select UserId from [Users] where UserId = @uid)
,@pnum,@lname,@fname,null,@skls,@loc,@salry)
GO

create procedure MemberUpdate
(
	@uid as nvarchar(max),
	@pnum as nvarchar(max),
	@lname as nvarchar(max),
	@fname as nvarchar(max),

	@skls as nvarchar(max),

	@loc as nvarchar(max),
	@salry as float
)
as
update [Members] set PhoneNumber = @pnum,FirstMidName = @fname, LastName=@lname, Skills =@skls, 
Location = @loc, ExpSalary =@salry where UserId = @uid
GO

create procedure MemberDegreeGetInfo
(
	@uid as nvarchar(max)
)
as
SELECT *
FROM [Degree_Member] D JOIN [Members] M ON D.MemberId=M.MemberId where M.UserId = @uid
GO

create Procedure MemberDegreeCreate
(
	@mid as integer,

	@est as datetime,
	@esp as datetime,

	@edg as nvarchar(max),
	@esh as nvarchar(max),
	@ecy as nvarchar(max),
	@este as nvarchar(max),
	@edsc as nvarchar(max)
)
as
declare @did as integer
set @did=(select MAX(DegreeId) from [Degree_Member])+1
insert into [Degree_Member] values (@did,(select MemberId from [Members] where MemberId = @mid),@est,@esp,@edg,@esh,@ecy,@este,@edsc)
go

create procedure MemberDegreeUpdate
(
	@did as integer,

	@est as datetime,
	@esp as datetime,

	@edg as nvarchar(max),
	@esh as nvarchar(max),
	@ecy as nvarchar(max),
	@este as nvarchar(max),
	@edsc as nvarchar(max)

)
as
UPDATE [Degree_Member] set EduStart = @est, EduStop = @esp, EduDegree = @edg , EduSchool = @esh , EduCity = @ecy, EduState = @este, EduDesc = @edsc 
where DegreeId = @did 
GO

create procedure MemberDegreeRemove
(
	@did as integer
)
as
DELETE from [Degree_Member] where [DegreeId] = @did
GO

create procedure MemberXPGetInfo
(
	@uid as nvarchar(max)
)
as
SELECT *
FROM [XP_Member] X JOIN [Members] M ON X.MemberId=M.MemberId where M.UserId = @uid
go

create procedure MemberXPCreate
(
	@mid integer,
	
	@xst as datetime,
	@xsp as datetime,

	@xpos as nvarchar(max),
	@xcom as nvarchar(max),
	@xcy as nvarchar(max),
	@xste as nvarchar(max),
	@xdsc as nvarchar(max)
)
as
DECLARE @xid as integer
set @xid=(select MAX(XpId) from [XP_Member])+1
insert into [XP_Member] values (@xid,(select MemberId from [Members] where MemberId = @mid),@xst,@xsp,@xpos,@xcom,@xcy,@xste,@xdsc)
GO

create procedure MemberXPUpdate
(
	@xid integer,

	@xst as datetime,
	@xsp as datetime,

	@xpos as nvarchar(max),
	@xcom as nvarchar(max),
	@xcy as nvarchar(max),
	@xste as nvarchar(max),
	@xdsc as nvarchar(max)
)
as
UPDATE [XP_Member] set XpStart = @xst, XpStop = @xsp, XpPosition = @xpos, XpCompany = @xcom, XpCity = @xcy, XpState = @xste, XpDesc = @xdsc
where [XpId] = @xid
GO

create procedure MemberXPRemove
(
	@xid integer
)
as
DELETE from [XP_Member] where [XpId] = @xid
GO