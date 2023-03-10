USE [Employeedb]
GO
/****** Object:  StoredProcedure [dbo].[usp_DeleteEmployeebyID]    Script Date:  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_DeleteEmployeebyID]
@EmpID int

AS
BEGIN
Delete from [Employeedb].[dbo].EmployeesData
where EmpID = @EmpID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_GetEmployeeByID]    Script Date:  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_GetEmployeeByID]
@EmpID int
AS
BEGIN
SELECT [EmpID]
	,[EmpName]
	,[Email]
	,[ContactNo]
FROM [Employeedb].[dbo].[EmployeesData]

WHERE EmpID=@EmpID
END
GO
/****** Object:  StoredProcedure [dbo].[usp_getEmployees]    Script Date:  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_getEmployees]
AS
BEGIN
select * from EmployeesData
END
GO
/****** Object:  StoredProcedure [dbo].[usp_SaveEmployees]    Script Date:  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SaveEmployees]
	@EmpID int,
	@EmpName varchar(50),
	@Email varchar(50),
	@ContactNo int
	AS
	BEGIN
	insert into EmployeesData(EmpID,EmpName,Email,ContactNo)values(@EmpID,@EmpName,@Email,@ContactNo)
	END
GO
/****** Object:  StoredProcedure [dbo].[usp_UpdateEmployee]    Script Date:  ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_UpdateEmployee]
@EmpID int,
@EmpName varchar(50),
@Email varchar(50),
@ContactNo int
AS
BEGIN
UPDATE
[Employeedb].[dbo].[EmployeesData]
SET
EmpName=@EmpName,
Email=@Email,
ContactNo=@ContactNo
WHERE
EmpID=@EmpID
END
GO
