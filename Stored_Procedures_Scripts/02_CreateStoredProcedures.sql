CREATE PROCEDURE usp_UpdateCustomerJson
    @Id INT,
    @CustomerData NVARCHAR(MAX)
AS
BEGIN
    UPDATE CustomersJson
    SET CustomerData = @CustomerData
    WHERE Id = @Id;

    SELECT @@ROWCOUNT AS RowsAffected;
END;
GO

CREATE PROCEDURE usp_DeleteCustomerJson
    @Id INT
AS
BEGIN
    DELETE FROM CustomersJson WHERE Id = @Id;

    SELECT @@ROWCOUNT AS RowsAffected;
END;
GO

IF OBJECT_ID('usp_GetCustomersJson', 'P') IS NOT NULL
    DROP PROCEDURE usp_GetCustomersJson;
GO

CREATE PROCEDURE usp_GetCustomersJson
AS
BEGIN
    SELECT 
         c.Id,
         c.CreatedDate,
         JSON_VALUE(c.CustomerData, '$.Name') AS Name,
         JSON_VALUE(c.CustomerData, '$.Email') AS Email
    FROM CustomersJson AS c
    FOR JSON PATH;
END;
GO

IF OBJECT_ID('usp_GetCustomerByIdJson', 'P') IS NOT NULL
    DROP PROCEDURE usp_GetCustomerByIdJson;
GO

CREATE PROCEDURE usp_GetCustomerByIdJson
    @Id INT
AS
BEGIN
    SELECT 
         c.Id,
         c.CreatedDate,
         JSON_VALUE(c.CustomerData, '$.Name') AS Name,
         JSON_VALUE(c.CustomerData, '$.Email') AS Email
    FROM CustomersJson AS c
    WHERE c.Id = @Id
    FOR JSON PATH, WITHOUT_ARRAY_WRAPPER;
END;
GO
