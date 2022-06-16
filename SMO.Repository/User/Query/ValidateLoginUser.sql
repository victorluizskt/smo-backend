SELECT id_user 
FROM dbo.usuario 
WHERE email_user = @email_user 
AND password_user = @password_user