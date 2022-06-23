using Dapper;
using SMO.Frontier.DTO.Address;
using SMO.Frontier.Entities.Address;
using SMO.Frontier.Repository.Address;
using SMO.Repository.DatabaseUtils;
using SMO.Utils;
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
        private readonly string INSERT_ADDRESS_BY_ID = DatabaseUtil.LoadSqlStatement(
            "InsertAddressById.sql", typeof(AddressRepository).Namespace
        );

        private readonly string UPDATE_FLAG_USER = DatabaseUtil.LoadSqlStatement(
            "UpdateFlagUser.sql", typeof(AddressRepository).Namespace
        );

        private readonly string GET_ADDRESS_BY_ID = DatabaseUtil.LoadSqlStatement(
            "GetAddressById.sql", typeof(AddressRepository).Namespace
        );

        private readonly string DELETE_ADDRESS_USER = DatabaseUtil.LoadSqlStatement(
            "DeleteAddressUser.sql", typeof(AddressRepository).Namespace
        );

        private readonly string UPDATE_ADDRESS = DatabaseUtil.LoadSqlStatement(
            "UpdateAddress.sql", typeof(AddressRepository).Namespace
        );
        
        private readonly string DELETE_ALL_ADDRESS_USER = DatabaseUtil.LoadSqlStatement(
            "DeleteAllAddressUser.sql", typeof(AddressRepository).Namespace
        );

        private readonly string GET_LATEST_ID_ADDRESS = DatabaseUtil.LoadSqlStatement(
            "GetLatestIdAddress.sql", typeof(AddressRepository).Namespace
        );

        private readonly string SET_LATEST_FLAG_ID_USER = DatabaseUtil.LoadSqlStatement(
            "SetLatestFlagIdAddress.sql", typeof(AddressRepository).Namespace
        );

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
                dynamicParameters.Add("@Flag", Constants.FLAG_USER, DbType.Int32);
                dynamicParameters.Add("@Country", addressEntity.Country, DbType.String);
                dynamicParameters.Add("@Complement", addressEntity.Complement, DbType.String);
                dynamicParameters.Add("@DateCreateAddress", DateTime.Now, DbType.DateTime);

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
            await connection.ExecuteAsync(DELETE_ADDRESS_USER, dynamicParameters);
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
            dynamicParameters.Add("@Flag", 0, DbType.Int32);
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
            await connection.ExecuteAsync(DELETE_ALL_ADDRESS_USER, dynamicParameters);
            return true;
        }

        public async Task<IEnumerable<int>> GetAddressListOrderByDesc(int idUser)
        {
            using var connection = userSession.CreateConnection();
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@idUser", idUser, DbType.Int32);
            return await connection.QueryAsync<int>(GET_LATEST_ID_ADDRESS, dynamicParameters);
        }

        public async Task SetLatestFlagIdAddress(int idAddress)
        {
            using var connection = userSession.CreateConnection();
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@idAddress", idAddress, DbType.Int32);
            await connection.ExecuteAsync(SET_LATEST_FLAG_ID_USER, dynamicParameters);
        }
    }
}
