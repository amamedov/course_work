USE [master]
GO
/****** Object:  Database [Course_work_Mamedov]    Script Date: 04.06.2020 20:20:21 ******/
CREATE DATABASE [Course_work_Mamedov]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Course_work_Mamedov', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Course_work_Mamedov.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Course_work_Mamedov_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Course_work_Mamedov_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Course_work_Mamedov] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Course_work_Mamedov].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Course_work_Mamedov] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Course_work_Mamedov] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Course_work_Mamedov] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Course_work_Mamedov] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Course_work_Mamedov] SET ARITHABORT OFF 
GO
ALTER DATABASE [Course_work_Mamedov] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Course_work_Mamedov] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Course_work_Mamedov] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Course_work_Mamedov] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Course_work_Mamedov] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Course_work_Mamedov] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Course_work_Mamedov] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Course_work_Mamedov] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Course_work_Mamedov] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Course_work_Mamedov] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Course_work_Mamedov] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Course_work_Mamedov] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Course_work_Mamedov] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Course_work_Mamedov] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Course_work_Mamedov] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Course_work_Mamedov] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Course_work_Mamedov] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Course_work_Mamedov] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Course_work_Mamedov] SET  MULTI_USER 
GO
ALTER DATABASE [Course_work_Mamedov] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Course_work_Mamedov] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Course_work_Mamedov] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Course_work_Mamedov] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Course_work_Mamedov] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Course_work_Mamedov] SET QUERY_STORE = OFF
GO
USE [Course_work_Mamedov]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[StudentID] [int] NOT NULL,
	[LessonID] [int] NOT NULL,
 CONSTRAINT [PK_Attendance_1] PRIMARY KEY CLUSTERED 
(
	[LessonID] ASC,
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Building]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Building](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Address] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contract]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[StudentID] [int] NOT NULL,
	[CourseID] [int] NOT NULL,
	[ManagerID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[AmountToPay] [float] NOT NULL,
	[IsPaid] [bit] NULL,
	[DTMade] [datetime] NOT NULL,
 CONSTRAINT [PK__Contract__3214EC27CD6E5E4C] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[SubjectID] [int] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Price] [float] NOT NULL,
	[ManagerID] [int] NOT NULL,
	[FollowedByExam] [bit] NOT NULL,
	[HasRequirements] [bit] NOT NULL,
	[TypeOfCourseID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK__Course__3214EC27BEABE587] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course_Requirements]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course_Requirements](
	[CourseID] [int] NOT NULL,
	[RequiredCourseID] [int] NOT NULL,
 CONSTRAINT [PK_Required_Course] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC,
	[RequiredCourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Surname] [nvarchar](30) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Gender] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee_Skill]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee_Skill](
	[EmployeeID] [int] NOT NULL,
	[SkillID] [int] NOT NULL,
 CONSTRAINT [PK_Employee_Skill] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC,
	[SkillID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Extra]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Extra](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CourseID] [date] NOT NULL,
 CONSTRAINT [PK__Extra__3214EC2716D9D049] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lecture]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lecture](
	[ExtraID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[NumberOfSlides] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[ExtraID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lesson]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lesson](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TeacherID] [int] NULL,
	[CourseID] [int] NOT NULL,
	[RoomID] [int] NULL,
	[DTStart] [datetime] NOT NULL,
	[DTEnd] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lesson_Extra]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lesson_Extra](
	[LessonID] [int] NOT NULL,
	[ExtraID] [int] NOT NULL,
 CONSTRAINT [PK_LESSON_EXTRA] PRIMARY KEY CLUSTERED 
(
	[LessonID] ASC,
	[ExtraID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manager]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manager](
	[EmployeeID] [int] NOT NULL,
	[PositionID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Salary] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PrintedMaterial]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrintedMaterial](
	[ExtraID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[NumberOfPages] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[ExtraID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](10) NOT NULL,
	[Capacity] [int] NOT NULL,
	[BuildingID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Skill]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Skill](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Description] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Surname] [nvarchar](30) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[Gender] [nvarchar](10) NULL,
 CONSTRAINT [PK__Student__3214EC278F0E7C11] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Courses_History]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Courses_History](
	[StudentID] [int] NOT NULL,
	[CourseID] [int] NOT NULL,
	[IsExamPassed] [bit] NULL,
 CONSTRAINT [PK_History] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC,
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[EmployeeID] [int] NOT NULL,
	[PositionID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeOfCourse]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeOfCourse](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Video]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Video](
	[ExtraID] [int] NOT NULL,
	[LengthSeconds] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[ExtraID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Website]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Website](
	[ExtraID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[URL] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[ExtraID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Employee]    Script Date: 04.06.2020 20:20:21 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Employee] ON [dbo].[Employee]
(
	[Name] ASC,
	[Surname] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contract] ADD  CONSTRAINT [DF__Contract__IsActi__6C190EBB]  DEFAULT ((0)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Contract] ADD  CONSTRAINT [DF__Contract__IsPaid__6D0D32F4]  DEFAULT ((0)) FOR [IsPaid]
GO
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [DF__Course__Followed__5EBF139D]  DEFAULT ((0)) FOR [FollowedByExam]
GO
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [DF__Course__HasRequi__5FB337D6]  DEFAULT ((0)) FOR [HasRequirements]
GO
ALTER TABLE [dbo].[Course] ADD  CONSTRAINT [DF_Course_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[Student_Courses_History] ADD  DEFAULT ((0)) FOR [IsExamPassed]
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD FOREIGN KEY([LessonID])
REFERENCES [dbo].[Lesson] ([ID])
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK__Attendanc__Stude__3D2915A8] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK__Attendanc__Stude__3D2915A8]
GO
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD  CONSTRAINT [FK__Contract__Course__6A30C649] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([ID])
GO
ALTER TABLE [dbo].[Contract] CHECK CONSTRAINT [FK__Contract__Course__6A30C649]
GO
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD  CONSTRAINT [FK__Contract__Manage__6B24EA82] FOREIGN KEY([ManagerID])
REFERENCES [dbo].[Manager] ([EmployeeID])
GO
ALTER TABLE [dbo].[Contract] CHECK CONSTRAINT [FK__Contract__Manage__6B24EA82]
GO
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD  CONSTRAINT [FK__Contract__Studen__693CA210] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[Contract] CHECK CONSTRAINT [FK__Contract__Studen__693CA210]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK__Course__ManagerI__5DCAEF64] FOREIGN KEY([ManagerID])
REFERENCES [dbo].[Manager] ([EmployeeID])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK__Course__ManagerI__5DCAEF64]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK__Course__SubjectI__5CD6CB2B] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subject] ([ID])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK__Course__SubjectI__5CD6CB2B]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK__Course__TypeOfCo__60A75C0F] FOREIGN KEY([TypeOfCourseID])
REFERENCES [dbo].[TypeOfCourse] ([ID])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK__Course__TypeOfCo__60A75C0F]
GO
ALTER TABLE [dbo].[Course_Requirements]  WITH CHECK ADD  CONSTRAINT [FK__Course_Re__Cours__656C112C] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([ID])
GO
ALTER TABLE [dbo].[Course_Requirements] CHECK CONSTRAINT [FK__Course_Re__Cours__656C112C]
GO
ALTER TABLE [dbo].[Course_Requirements]  WITH CHECK ADD  CONSTRAINT [FK__Course_Re__Requi__66603565] FOREIGN KEY([RequiredCourseID])
REFERENCES [dbo].[Course] ([ID])
GO
ALTER TABLE [dbo].[Course_Requirements] CHECK CONSTRAINT [FK__Course_Re__Requi__66603565]
GO
ALTER TABLE [dbo].[Employee_Skill]  WITH CHECK ADD FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[Employee_Skill]  WITH CHECK ADD FOREIGN KEY([SkillID])
REFERENCES [dbo].[Skill] ([ID])
GO
ALTER TABLE [dbo].[Lecture]  WITH CHECK ADD  CONSTRAINT [FK__Lecture__ExtraID__0E6E26BF] FOREIGN KEY([ExtraID])
REFERENCES [dbo].[Extra] ([ID])
GO
ALTER TABLE [dbo].[Lecture] CHECK CONSTRAINT [FK__Lecture__ExtraID__0E6E26BF]
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [FK__Lesson__CourseID__75A278F5] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([ID])
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [FK__Lesson__CourseID__75A278F5]
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD FOREIGN KEY([RoomID])
REFERENCES [dbo].[Room] ([ID])
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([EmployeeID])
GO
ALTER TABLE [dbo].[Lesson_Extra]  WITH CHECK ADD  CONSTRAINT [FK__Lesson_Ex__Extra__01142BA1] FOREIGN KEY([ExtraID])
REFERENCES [dbo].[Extra] ([ID])
GO
ALTER TABLE [dbo].[Lesson_Extra] CHECK CONSTRAINT [FK__Lesson_Ex__Extra__01142BA1]
GO
ALTER TABLE [dbo].[Lesson_Extra]  WITH CHECK ADD FOREIGN KEY([LessonID])
REFERENCES [dbo].[Lesson] ([ID])
GO
ALTER TABLE [dbo].[Manager]  WITH CHECK ADD FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[Manager]  WITH CHECK ADD FOREIGN KEY([PositionID])
REFERENCES [dbo].[Position] ([ID])
GO
ALTER TABLE [dbo].[PrintedMaterial]  WITH CHECK ADD  CONSTRAINT [FK__PrintedMa__Extra__07C12930] FOREIGN KEY([ExtraID])
REFERENCES [dbo].[Extra] ([ID])
GO
ALTER TABLE [dbo].[PrintedMaterial] CHECK CONSTRAINT [FK__PrintedMa__Extra__07C12930]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD FOREIGN KEY([BuildingID])
REFERENCES [dbo].[Building] ([ID])
GO
ALTER TABLE [dbo].[Student_Courses_History]  WITH CHECK ADD  CONSTRAINT [FK__Student_C__Cours__70DDC3D8] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([ID])
GO
ALTER TABLE [dbo].[Student_Courses_History] CHECK CONSTRAINT [FK__Student_C__Cours__70DDC3D8]
GO
ALTER TABLE [dbo].[Student_Courses_History]  WITH CHECK ADD  CONSTRAINT [FK__Student_C__Stude__6FE99F9F] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[Student_Courses_History] CHECK CONSTRAINT [FK__Student_C__Stude__6FE99F9F]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD FOREIGN KEY([PositionID])
REFERENCES [dbo].[Position] ([ID])
GO
ALTER TABLE [dbo].[Video]  WITH CHECK ADD  CONSTRAINT [FK__Video__ExtraID__03F0984C] FOREIGN KEY([ExtraID])
REFERENCES [dbo].[Extra] ([ID])
GO
ALTER TABLE [dbo].[Video] CHECK CONSTRAINT [FK__Video__ExtraID__03F0984C]
GO
ALTER TABLE [dbo].[Website]  WITH CHECK ADD  CONSTRAINT [FK__Website__ExtraID__0B91BA14] FOREIGN KEY([ExtraID])
REFERENCES [dbo].[Extra] ([ID])
GO
ALTER TABLE [dbo].[Website] CHECK CONSTRAINT [FK__Website__ExtraID__0B91BA14]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [CK_Dates] CHECK  (([StartDate]<[EndDate]))
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [CK_Dates]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [CK_price] CHECK  (([Price]>(0)))
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [CK_price]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [CK_DoB_Employee] CHECK  (([DateOfBirth]<getdate()))
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [CK_DoB_Employee]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [CK_gender_Employee] CHECK  (([Gender]='M' OR [Gender]='F'))
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [CK_gender_Employee]
GO
ALTER TABLE [dbo].[Lecture]  WITH CHECK ADD  CONSTRAINT [CK_NumberOfSlides] CHECK  (([NumberOfSlides]>(0)))
GO
ALTER TABLE [dbo].[Lecture] CHECK CONSTRAINT [CK_NumberOfSlides]
GO
ALTER TABLE [dbo].[Lesson]  WITH CHECK ADD  CONSTRAINT [CK_time] CHECK  (([DTStart]<[DTEnd]))
GO
ALTER TABLE [dbo].[Lesson] CHECK CONSTRAINT [CK_time]
GO
ALTER TABLE [dbo].[Position]  WITH CHECK ADD  CONSTRAINT [CK_Salary] CHECK  (([Salary]>(0)))
GO
ALTER TABLE [dbo].[Position] CHECK CONSTRAINT [CK_Salary]
GO
ALTER TABLE [dbo].[PrintedMaterial]  WITH CHECK ADD  CONSTRAINT [CK_NumberOfPages] CHECK  (([NumberOfPages]>(0)))
GO
ALTER TABLE [dbo].[PrintedMaterial] CHECK CONSTRAINT [CK_NumberOfPages]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [CK_Capacity] CHECK  (([Capacity]>(0)))
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [CK_Capacity]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [CK_DoB_Student] CHECK  (([DateOfBirth]<getdate()))
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [CK_DoB_Student]
GO
ALTER TABLE [dbo].[Video]  WITH CHECK ADD  CONSTRAINT [CK_Length] CHECK  (([LengthSeconds]>(0)))
GO
ALTER TABLE [dbo].[Video] CHECK CONSTRAINT [CK_Length]
GO
/****** Object:  StoredProcedure [dbo].[Add_building]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Add_building]
@Address nvarchar(30)
as
insert into [dbo].[Building]
values (@Address)

GO
/****** Object:  StoredProcedure [dbo].[Add_Employee]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Add_Employee]
	@Name nvarchar(30),
	@Surname nvarchar(30),
	@DoB date,
	@Gender char(1),
	@Position int
as
	begin
		insert into Employee
		values
		(@Name,@Surname, @DoB, @Gender)
	end
GO
/****** Object:  StoredProcedure [dbo].[Add_employee_skill]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Add_employee_skill]
@EmployeeID int, 
@SkillID int
as 
insert into Employee_Skill
values
	(@EmployeeID, @SkillID)
GO
/****** Object:  StoredProcedure [dbo].[Add_lecture]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Add_lecture] 
@ExtraID int,
@Name nvarchar(50),
@NumberOfSlides int, 
@Description nvarchar(500)
as
insert into Lecture
	values (@ExtraID, @Name, @NumberOfSlides, @Description)
GO
/****** Object:  StoredProcedure [dbo].[Add_lesson]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Add_lesson] 
@TeacherID int,
@CourseID int,
@RoomID int,
@DTStart datetime,
@DTEnd datetime
as
insert into Lesson
	values (@TeacherID, @CourseID, @RoomID, @DTStart, @DTEnd)
GO
/****** Object:  StoredProcedure [dbo].[Add_new_skill]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Add_new_skill]
@Name nvarchar(30),
@Description nvarchar(100)
as 
insert into	Skill
	values 
	(@Name, @Description)
GO
/****** Object:  StoredProcedure [dbo].[Add_printed_material]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Add_printed_material]
@ExtraID int,
@Name nvarchar(50),
@NumberOfPages int,
@Description nvarchar(500)
as
insert into PrintedMaterial
	values (@ExtraID, @Name, @NumberOfPages, @Description)
GO
/****** Object:  StoredProcedure [dbo].[Add_Student]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Add_Student]
	@Name nvarchar(30),
	@Surname nvarchar(30),
	@DoB date,
	@Gender char(1)
as
	insert into Student
	values
	(@Name,@Surname,@DoB,@Gender)
GO
/****** Object:  StoredProcedure [dbo].[Add_video]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Add_video]
@ExtraID int,
@LengthSeconds int,
@Description nvarchar(500)
as
	insert into Video
	values (@ExtraID, @LengthSeconds, @Description)
GO
/****** Object:  StoredProcedure [dbo].[Add_website]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Add_website]
@ExtraID int,
@Name nvarchar(50),
@url nvarchar(100),
@description nvarchar(500)
as
insert into Website
	values (@ExtraID, @Name, @url, @description)
GO
/****** Object:  StoredProcedure [dbo].[attend_lesson]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[attend_lesson]
@StudentID int,
@LessonID int,
@IsLate bit
as 
insert into Attendance
values (@StudentID, @LessonID, @IsLate)
GO
/****** Object:  StoredProcedure [dbo].[MakeContract]    Script Date: 04.06.2020 20:20:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[MakeContract]
  @StudentID int,
  @CourseID int,
  @ManagerID int
as
	insert into [dbo].[Contract]
	values 
	(@StudentID, @CourseID, @ManagerID, 0, (select Price from [dbo].[Course] where ID =@CourseID), 0, GETDATE())
GO
USE [master]
GO
ALTER DATABASE [Course_work_Mamedov] SET  READ_WRITE 
GO
