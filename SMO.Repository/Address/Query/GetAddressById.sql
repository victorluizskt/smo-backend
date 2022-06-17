SELECT 
	id_address AS IdAddress, 
	street_address AS Street, 
	city_address AS City, 
	state_address AS State, 
	postal_code_address AS PostalCode,
	number_house_address AS NumberHouse, 
	flag_address AS Flag, 
	complemento AS Complement, 
	pais AS Country 
FROM dbo.endereco 
WHERE id_user = @idUser