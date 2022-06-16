SELECT 
	id_user AS IdUser, 
	name_user AS Name, 
	email_user AS Email,
	password_user AS Password,
	cpf_user AS CPF, 
	number_phone_user AS NumberPhone 
FROM dbo.usuario 
WHERE id_user = @IdUser