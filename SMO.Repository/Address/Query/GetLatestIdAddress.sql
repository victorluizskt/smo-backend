SELECT id_address
FROM dbo.endereco
WHERE id_user = @idUser
ORDER BY id_address DESC