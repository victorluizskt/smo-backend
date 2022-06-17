UPDATE dbo.endereco SET 
	street_address = @Street, 
	city_address = @City, 
	state_address = @State, 
	postal_code_address = @PostalCode, 
	number_house_address = @NumberHouse, 
	flag_address = @Flag, 
	complemento = @Complement,
	pais = @Country 
WHERE id_address = @IdAddress