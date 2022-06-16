INSERT INTO dbo.usuario 
VALUES (@Name, @Email, @Password, @Cpf, @NumberPhone) 
SELECT scope_identity()