Alter Procedure [dbo].[SpUpdateEmployeeSalary]
@Id int,
@Month varchar(10),
@Salary int,
@EmployeeId int
As
BEGIN
SET XACT_ABORT ON;
Begin Try
Begin Transaction
Update Salary
Set EmpSalary = @Salary
Where SalaryId = @Id and SalaryMonth = @Month and EmployeeId = @EmployeeId; 
Select e.Id, e.EmpName,s.EmpSalary,s.SalaryMonth, s.SalaryId
from Employee_Payroll e inner join Salary s on e.Id = s.EmployeeId where s.SalaryId = @Id
COMMIT Transaction;
End Try
Begin Catch
	Select ERROR_NUMBER() AS ErrorNumber, ERROR_MESSAGE() as ErrorMessage;

	if(XACT_STATE()) = -1
	BEGIN
		Print N'The Transaction is in an Uncommitable state. '+'Rolling Back to Transaction.'
		ROLLBACK TRANSACTION 
	End;

	IF(XACT_STATE())=1
	BEGIN
		PRINT N'The transaction is committable. '+'Committing transaction.'
		COMMIT TRANSACTION;
	END;
END CATCH
END