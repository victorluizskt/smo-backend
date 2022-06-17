INSERT INTO
dbo.endereco (
id_user, 
street_address,
city_address, 
state_address, 
postal_code_address, 
number_house_address, 
flag_address, 
complemento, 
pais,
date_create_address) 
VALUES (@Id_User, @Street, @City, @State, @PostalCode, @NumberHouse, @Flag, @Country, @Complement, @DateCreateAddress)