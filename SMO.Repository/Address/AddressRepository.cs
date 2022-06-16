using Dapper;
using SMO.Frontier.DTO.Address;
using SMO.Frontier.Entities.Address;
using SMO.Frontier.Repository.Address;
using SMO.Utils.Data;
using System.Data;

namespace SMO.Repository.Address
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DbSession userSession;
        public AddressRepository(DbSession dbSession)
        {
            userSession = dbSession;
        }

        #region SQL
        private readonly string INSERT_ADDRESS_BY_ID = 
            "INSERT INTO " +
            "dbo.endereco (" +
            "id_user, " +
            "street_address, " +
            "city_address, " +
            "state_address, " +
            "postal_code_address, " +
            "number_house_address, " +
            "flag_address, " +
            "complemento, " +
            "pais ) " +
            "VALUES (@Id_User, @Street, @City, @State, @PostalCode, @NumberHouse, @Flag, @Complement, @Country)";

        private readonly string UPDATE_FLAG_USER = 
           "UPDATE dbo.endereco " +
           "SET flag_address = 0 " +
           "WHERE id_user = @idUser";

        private readonly string GET_ADDRESS_BY_ID = 
            "SELECT " +
            "id_address AS IdAddress, " +
            "street_address AS Street, " +
            "city_address AS City, " +
            "state_address AS State, " +
            "postal_code_address AS PostalCode, " +
            "number_house_address AS NumberHouse, " +
            "flag_address AS Flag, " +
            "complemento AS Complement, " +
            "pais AS Country " +
            "FROM dbo.endereco " +
            "WHERE id_user = @idUser";

        private readonly string DELETE_ADDRESS_USER = 
            "DELETE dbo.endereco " +
            "WHERE id_address = @idAddress";

        private readonly string UPDATE_ADDRESS = "UPDATE " +
            "dbo.endereco SET " +
            "street_address = @Street, " +
            "city_address = @City, " +
            "state_address = @State, " +
            "postal_code_address = @PostalCode, " +
            "number_house_address = @NumberHouse, " +
            "flag_address = @Flag, " +
            "complemento = @Complement, " +
            "pais = @Country " +
            "WHERE id_address = @IdAddress";

        private readonly string DELETE_ALL_ADDRESS_USER =
            "DELETE dbo.endereco " +
            "WHERE id_user = @idUser";
        #endregion

        public async Task<bool> CreateAddressUser(AddressDto addressDto, int idUser)
        {
            var addressEntity = new AddressEntity(addressDto);

            if(addressEntity is not null)
            {
                using var connection = userSession.CreateConnection();

                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@Id_User", idUser, DbType.Int32);
                dynamicParameters.Add("@Street", addressEntity.Street, DbType.String);
                dynamicParameters.Add("@City", addressEntity.City, DbType.String);
                dynamicParameters.Add("@State", addressEntity.State, DbType.String);
                dynamicParameters.Add("@PostalCode", addressEntity.PostalCode, DbType.String);
                dynamicParameters.Add("@NumberHouse", addressEntity.NumberHouse, DbType.String);
                dynamicParameters.Add("@Flag", addressEntity.Flag, DbType.Int32);
                dynamicParameters.Add("@Country", addressEntity.Country, DbType.String);
                dynamicParameters.Add("@Complement", addressEntity.Complement, DbType.String);

                await connection.ExecuteAsync(INSERT_ADDRESS_BY_ID, dynamicParameters);
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<AddressEntity>> GetAddressById(int idUser)
        {
            using var connection = userSession.CreateConnection();
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@idUser", idUser, DbType.Int32);

            var addressModels = await connection.QueryAsync<AddressEntity>(GET_ADDRESS_BY_ID, dynamicParameters);
            if (addressModels.Any())
            {
                return addressModels;
            }

            return new List<AddressEntity> { };
        }

        public async Task UpdateFlagAddress(int idUser)
        {
            using var connection = userSession.CreateConnection();
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@IdUser", idUser, DbType.Int32);
            await connection.ExecuteAsync(UPDATE_FLAG_USER, dynamicParameters);
        }

        public async Task<bool> DeleteAddressUser(int idAddress)
        {

            using var connection = userSession.CreateConnection();
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@idAddress", idAddress, DbType.Int32);
            var deleted = await connection.ExecuteAsync(DELETE_ADDRESS_USER, dynamicParameters);
            return true;
        }

        public async Task<bool> UpdateAddress(AddressDto addressDto, int idAddress)
        {
            var addressEntity = new AddressEntity(addressDto);
            using var connection = userSession.CreateConnection();
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@IdAddress", idAddress, DbType.Int32);
            dynamicParameters.Add("@Street", addressEntity.Street, DbType.String);
            dynamicParameters.Add("@City", addressEntity.City, DbType.String);
            dynamicParameters.Add("@State", addressEntity.State, DbType.String);
            dynamicParameters.Add("@PostalCode", addressEntity.PostalCode, DbType.String);
            dynamicParameters.Add("@NumberHouse", addressEntity.NumberHouse, DbType.String);
            dynamicParameters.Add("@Flag", addressEntity.Flag, DbType.Int32);
            dynamicParameters.Add("@Country", addressEntity.Country, DbType.String);
            dynamicParameters.Add("@Complement", addressEntity.Complement, DbType.String);

            await connection.ExecuteAsync(UPDATE_ADDRESS, dynamicParameters);
            return true;
        }

        public async Task<bool> DeleteAllAddressUser(int idUser)
        {
            using var connection = userSession.CreateConnection();
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@idUser", idUser, DbType.Int32);
            var deleted = await connection.ExecuteAsync(DELETE_ALL_ADDRESS_USER, dynamicParameters);
            return true;
        }
    }
}
