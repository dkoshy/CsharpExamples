USE [WideWorldImporters];
Go

--Cretae an after trigger on [Sales].[Orders] for insert event

create or alter Trigger Sales.T1Orders 
on [Sales].[Orders]  AFTER Insert 
AS
Begin
	 Raiserror('T1Orders trigger was fired',1,1);
End
Go

Insert into Sales.Orders
  select * from Sales.Orders where OrderID = 0;
Go

  /*  
  Add some boiler palte code to verify that 
  data was actualy modified. 
  */

 Create or Alter Trigger Sales.T1Orders 
  On Sales.Orders After Insert As
  Begin
   Set Nocount on;

	 IF(ROWCOUNT_BIG() =0)
		  RETURN;
	 IF NOT EXISTS (select 1 From inserted)
		  RETURN;
	RAISERROR('T1Orders trigger was fired',1,1);
End



-- After triggers constaints are checkde first

INSERT INTO Sales.Orders (CustomerID, SalespersonPersonID, ContactPersonID, OrderDate, ExpectedDeliveryDate, IsUndersupplyBackordered, LastEditedBy)
	VALUES (10, 7, 1001, GETDATE(), DATEADD(DAY, 10, GETDATE()), 0, 10);
GO

/*
  Now attempt the same INSERT with a CustomerID that
  does not exist in the Sales.Customer table
*/
INSERT INTO Sales.Orders (CustomerID, SalespersonPersonID, ContactPersonID, OrderDate, ExpectedDeliveryDate, IsUndersupplyBackordered, LastEditedBy)
	VALUES (0, 7, 1001, GETDATE(), DATEADD(DAY, 10, GETDATE()), 0, 10);
GO

/*
 ALTER the Trigger to check if the Customer is 
 currently on a Credit Freeze
*/
CREATE OR ALTER TRIGGER [Sales].[TI_Orders]ON 
	[Sales].[Orders]AFTER INSERTAS
	BEGIN
		IF (ROWCOUNT_BIG() = 0)
			RETURN;

		SET NOCOUNT ON;
	
		IF NOT EXISTS (SELECT 1 FROM INSERTED)
			RETURN;
		
		-- Is this customer credit on hold?
		IF EXISTS 
		(
			SELECT 1 FROM INSERTED i 
				INNER JOIN Customers c on i.CustomerID = c.CustomerID
			WHERE c.IsOnCreditHold = 1
		)
		BEGIN
			RAISERROR('Customer is currently on a credit freeze',16,1);
			ROLLBACK TRAN;
			RETURN;
		END;
	END;
GO


/*
  Set CustomerID=10 to be on credit freeze
*/
UPDATE sales.Customers SET IsOnCreditHold = 1 WHERE CustomerID=10;


/*
  Attempt the insert.
*/
INSERT INTO Sales.Orders (CustomerID, SalespersonPersonID, ContactPersonID, OrderDate, ExpectedDeliveryDate, IsUndersupplyBackordered, LastEditedBy)
	VALUES (10, 8, 1001, GETDATE(), DATEADD(DAY, 10, GETDATE()), 0, 10);
GO


/*
  ALTER the Trigger to include a second check for SalesPerson.
*/
CREATE OR ALTER TRIGGER [Sales].[TI_Orders]ON 
	[Sales].[Orders]AFTER INSERTAS
	BEGIN
		IF (ROWCOUNT_BIG() = 0)
			RETURN;

		SET NOCOUNT ON;

		IF NOT EXISTS (SELECT 1 FROM INSERTED)
			RETURN;
		
		-- Is this customer credit on hold?
		IF EXISTS 
		(
			SELECT 1 FROM INSERTED i 
				INNER JOIN Sales.Customers c on i.CustomerID = c.CustomerID
			WHERE c.IsOnCreditHold = 1
		)
		BEGIN
			RAISERROR('Customer is currently on a credit freeze',16,1);
			ROLLBACK TRAN;
			RETURN;
		END;

		-- Is this a valid Sales Person
		IF EXISTS 
		(
			SELECT 1 FROM INSERTED i 
				INNER JOIN Application.People p on i.SalespersonPersonID = p.PersonID
			WHERE p.IsSalesperson = 0
		)
		BEGIN
			RAISERROR('The supplied user is not currently a Sales Person',16,1);
			ROLLBACK TRAN;
			RETURN;
		END;

	END;
GO


/*
	Remove the Credit Freeze from CustomerID=10
*/
UPDATE sales.Customers SET IsOnCreditHold = 0 WHERE CustomerID=10;

/*
	Attempt the INSERT. The Trigger will stop the insert on an 
	invalid SalesPersonID.
*/
INSERT INTO Sales.Orders (CustomerID, SalespersonPersonID, ContactPersonID, OrderDate, ExpectedDeliveryDate, IsUndersupplyBackordered, LastEditedBy)
	VALUES (10, 9, 1001, GETDATE(), DATEADD(DAY, 10, GETDATE()), 0, 10);
GO