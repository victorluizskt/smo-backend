DECLARE @var1 INT;
SELECT @var1 = id_user
FROM dbo.endereco
WHERE id_address = @idAddress;

SELECT id_address
FROM dbo.endereco
WHERE id_user = @var1
ORDER BY id_address DESC