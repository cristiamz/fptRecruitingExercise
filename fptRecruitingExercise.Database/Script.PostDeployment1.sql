
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

--DELETE FROM dbo.RandomNames;

--INSERT INTO dbo.RandomNames(name)
--VALUES('Tom'), ('Dick'), ('Harry'), ('Jughead'), ('Archie'), ('Mike'), ('Phil'), ('Sarah'), ('Ann'), ('Marie'), ('Liz'), ('Sally'), ('Sue'), ('Peggy'), ('Betty'), ('Veronica'), ('Bill'), ('John'), ('Steve'), ('Stephanie');

--DECLARE @Counter INT;
--SET @Counter = 1;

--WHILE @Counter <= 100
--    BEGIN
--        INSERT INTO dbo.Customer
--        (Name, 
--         Phone, 
--         Email, 
--         Notes
--        )
--               SELECT Name, 
--                      Id, 
--                      Name + '+' + CAST(Id AS NVARCHAR) + '@gmail.com', 
--                      Name + '+' + CAST(Id AS NVARCHAR) + ' as notes'
--               FROM   dbo.RandomNames
--               WHERE  Id = ABS(CHECKSUM(NEWID()) % 20);

--        SET @Counter = @Counter + 1;
--    END;