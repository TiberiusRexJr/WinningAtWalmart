
create procedure WinningAtWalmart_CRUD
@id int=0,@firstname varchar(50)=null,@lastname varchar(50)=null,@email varchar(50)=null,@password varchar(50)=null,@query int
AS
BEGIN
IF(@query=1)
BEGIN
INSERT INTO dbo.WinningAtWalmart_Workers
(
	Id,FirstName,LastName,Email,psword
)
VALUES	
(
	@id,@firstname,@lastname,@email,@password
)

IF(@@ROWCOUNT>0)
BEGIN
SELECT 'Insert'
END
END

IF(@query=2)
BEGIN
UPDATE dbo.WinningAtWalmart_Workers
SET FirstName=@firstname,LastName=@lastname,Email=@email,psword=@password

WHERE dbo.WinningAtWalmart_Workers.Id=@id
SELECT 'Update'
END

IF(@query=3)
BEGIN
DELETE FROM dbo.WinningAtWalmart_Workers WHERE dbo.WinningAtWalmart_Workers.Id=@id
SELECT 'Delte'
END

IF (@query=4)
BEGIN
SELECT * FROM dbo.WinningAtWalmart_Workers
END
END

IF(@query=5)
BEGIN
SELECT * FROM  dbo.WinningAtWalmart_Workers WHERE dbo.WinningAtWalmart_Workers.Id=@id
END


