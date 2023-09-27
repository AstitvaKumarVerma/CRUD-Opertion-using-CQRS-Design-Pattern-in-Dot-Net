 create table AstitvaEmp308(
	EmpId int Not Null Identity(1,1) Primary Key,
	EmpName varchar(30) Not Null,
	EmpEmail varchar(50) Not Null,
	EmpDOB date Not Null,
	EmpAddress varchar(100) Not Null,
	IsActive bit Default 1,
	IsDeleted bit Default 0
 )

 select * from AstitvaEmp308

 truncate table AstitvaEmp308

 update AstitvaEmp308 Set IsActive = 1 where EmpId=2;
 update AstitvaEmp308 Set IsDeleted = 0 where EmpId=2;


 Insert Into AstitvaEmp308 values('Astitva','astitva@gmail.com','2002-07-29','Pilibhit',1,0)
 Insert Into AstitvaEmp308 values('Anushka','anushka@gmail.com','2002-08-31','Bareilly',1,0)
 Insert Into AstitvaEmp308 values('Satyam','satyam@gmail.com','2002-02-28','Dehradun',1,0)

--------------------------------------------------------------------------------------------------------------------------------
Create Procedure SP_AstitvaEmp308_Save
	@empName varchar(30),
	@empEmail varchar(50),
	@empDOB date,
	@empAddress varchar(100)
AS
Begin
	Insert into AstitvaEmp308 values (@empName, @empEmail, @empDOB, @empAddress, 1, 0)
End

---------------------------------------------------------------------------------------------------------------------------------------
Create Procedure SP_AstitvaEmp308_Update
	@empId int,
	@empName varchar(30),
	@empEmail varchar(50),
	@empDOB date,
	@empAddress varchar(100)
AS
Begin
	Update AstitvaEmp308 
	Set
		EmpName =  @empName,
		EmpEmail =  @empEmail, 
		EmpDOB = @empDOB, 
		EmpAddress = @empAddress
	Where EmpId = @empId
End
