
namespace Api.Infrastucture.Repositories.Orders;

public static class OrdersStoreProcedures
{
	public const string SP_GET_ORDER = "sp_Read_Order";
	public const string SP_GET_ORDERS = "sp_Get_Orders";
	public const string SP_CREATE_ORDER = "sp_Create_Order";
	public const string SP_UPDATE_ORDER = "sp_Update_Order";
	public const string SP_DELETE_ORDER = "sp_Delete_Order";
    public static string GetOrder()
    {
        return $@"
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = '{SP_GET_ORDER}')
    DROP PROCEDURE dbo.{SP_GET_ORDER}
GO

CREATE PROCEDURE dbo.{SP_GET_ORDER}
    @OrderId INT
AS
BEGIN
    SELECT [OrderId] ,[CustomerId] ,[Freight] ,[ShipCountry] FROM [KnowladgeTestDb].[dbo].[Orders] WHERE OrderId = @OrderId  
END";
    }
    public static string GetOrders()
    {
        return $@"
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = '{SP_GET_ORDERS}')
    DROP PROCEDURE dbo.{SP_GET_ORDERS}
GO

CREATE PROCEDURE dbo.{SP_GET_ORDERS}
    @OrderId NVARCHAR(10) = NULL,
    @CustomerId NVARCHAR(250) = NULL,
    @ShipCountry NVARCHAR(528) = NULL,
    @Operator NVARCHAR(3) = 'AND'
AS
BEGIN
    DECLARE @sql NVARCHAR(MAX)
    SET @sql = 'SELECT [OrderId] ,[CustomerId] ,[Freight] ,[ShipCountry] FROM [KnowladgeTestDb].[dbo].[Orders]'

    DECLARE @where NVARCHAR(MAX) = ''
    IF @OrderId IS NOT NULL
    BEGIN
        SET @where = @where + ' CAST(OrderId AS NVARCHAR(10)) LIKE ''%' + @OrderId + '%'''
    END

    IF @CustomerId IS NOT NULL
    BEGIN
        IF LEN(@where) > 0 SET @where = @where + ' ' + @Operator
        SET @where = @where + ' CustomerId = @CustomerId'
    END

    IF @ShipCountry IS NOT NULL
    BEGIN
        IF LEN(@where) > 0 SET @where = @where + ' ' + @Operator
        SET @where = @where + ' ShipCountry = @ShipCountry'
    END

    IF LEN(@where) > 0 SET @sql = @sql + ' WHERE' + @where

    EXEC sp_executesql @sql, N'@OrderId NVARCHAR(10), @CustomerId NVARCHAR(250), @ShipCountry NVARCHAR(528)', @OrderId = @OrderId, @CustomerId = @CustomerId, @ShipCountry = @ShipCountry
END";
    }
    public static string CreateOrder() {
        return $@"IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = '{SP_CREATE_ORDER}')
    DROP PROCEDURE dbo.{SP_CREATE_ORDER}
GO

CREATE PROCEDURE dbo.{SP_CREATE_ORDER}
    @OrderId [int] ,
    @CustomerId [nvarchar](250) ,
    @Freight [decimal](18, 2) ,
    @ShipCountry [nvarchar](528) 
AS
BEGIN
   
    INSERT INTO [KnowladgeTestDb].[dbo].[Orders] (OrderId, CustomerId, Freight, ShipCountry)
    VALUES (@OrderId, @CustomerId, @Freight, @ShipCountry)
END
GO";
    }
    public static string UpdateOrder() {
        return $@"IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = '{SP_UPDATE_ORDER}')
    DROP PROCEDURE dbo.{SP_UPDATE_ORDER}
GO

CREATE PROCEDURE dbo.{SP_UPDATE_ORDER}
    @OrderId INT,
    @CustomerId NVARCHAR(250),
    @Freight DECIMAL(18, 2),
    @ShipCountry NVARCHAR(528)
AS
BEGIN
    UPDATE [KnowladgeTestDb].[dbo].[Orders]
    SET CustomerId = @CustomerId, Freight = @Freight, ShipCountry = @ShipCountry
    WHERE OrderId = @OrderId
END
GO";
    }
    public static string DeleteOrder()
    {
        return
$@"IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = '{SP_DELETE_ORDER}')
    DROP PROCEDURE dbo.{SP_DELETE_ORDER}
GO

CREATE PROCEDURE dbo.{SP_DELETE_ORDER}
    @OrderId INT
AS
BEGIN
    DELETE FROM [KnowladgeTestDb].[dbo].[Orders] WHERE OrderId = @OrderId  
END
GO";

    }

}

