UPDATE dbo.usuario SET 
	name_user = @Name, 
	email_user = @Email, 
	password_user = @Password,
	number_phone_user = @NumberPhone 
WHERE id_user = @IdUser