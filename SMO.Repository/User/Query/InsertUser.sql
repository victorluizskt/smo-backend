INSERT INTO dbo.usuario 
VALUES (@Name, @Email, @Password, @Cpf, @NumberPhone, @DateCreateUser) 
SELECT scope_identity()