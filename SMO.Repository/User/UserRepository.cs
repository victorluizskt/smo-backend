using Dapper;
using SMO.Frontier.DTO.User;
using SMO.Frontier.Entities.User;
using SMO.Frontier.Model.UserLogin;
using SMO.Frontier.Repository.User;
using SMO.Utils.Data;
using System.Data;

namespace SMO.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSession userSession;
        public UserRepository(DbSession dbSession)
        {
            userSession = dbSession;
        }

        #region SQL
        private static readonly string INSERT_USER = DatabaseUtils.DatabaseUtils.LoadSqlStatement(
            "InsertUser.sql", typeof(UserRepository).Namespace
        );

        private readonly string UPDATE_USER = "UPDATE " +
            "dbo.usuario SET " +
            "name_user = @Name, " +
            "email_user = @Email, " +
            "password_user = @Password, " +
            "number_phone_user = @NumberPhone " +
            "WHERE id_user = @IdUser";

        private readonly string GET_USER_BY_ID = "SELECT " +
            "id_user AS IdUser, " +
            "name_user AS Name, " +
            "email_user AS Email," +
            "password_user AS Password," +
            "cpf_user AS CPF, " +
            "number_phone_user AS NumberPhone " +
            "FROM dbo.usuario " +
            "WHERE id_user = @IdUser";

        private readonly string DELETE_USER = "DELETE dbo.usuario " +
            "WHERE id_user = @IdUser";

        private readonly string VALIDATE_USER = "SELECT id_user " +
            "FROM dbo.usuario " +
            "WHERE email_user = @email_user " +
            "AND password_user = @password_user";

        private readonly string GET_USER_BY_CPF = 
            "SELECT cpf_user " +
            "FROM dbo.usuario " +
            "WHERE cpf_user = @CPF";
        #endregion

        public async Task<int> CreateUser(UserDto userDto)
        {
            var userEntity = new UserEntity(userDto);

            using var connection = userSession.CreateConnection();
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Name", userEntity.Name, DbType.String);
            dynamicParameters.Add("@Email", userEntity.Email, DbType.String);
            dynamicParameters.Add("@Password", userEntity.Password, DbType.String);
            dynamicParameters.Add("@Cpf", userEntity.CPF, DbType.String);
            dynamicParameters.Add("@NumberPhone", userEntity.NumberPhone, DbType.String);

            var idUser = await connection.QueryFirstAsync<int>(INSERT_USER, dynamicParameters);
            return idUser;
        }

        public async Task<bool> UpdateUser(UserDto userDto, int idUser)
        {
            var userEntity = new UserEntity(userDto);
            var userEdit = await GetUserById(userEntity.IdUser);
            if(userEdit is not null)
            {
                using var connection = userSession.CreateConnection();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@IdUser", idUser, DbType.Int32);
                dynamicParameters.Add("@Name", userEntity.Name, DbType.String);
                dynamicParameters.Add("@Email", userEntity.Email, DbType.String);
                dynamicParameters.Add("@Password", userEntity.Password, DbType.String);
                dynamicParameters.Add("@NumberPhone", userEntity.NumberPhone, DbType.String);

                await connection.ExecuteAsync(UPDATE_USER, dynamicParameters);
                return true;
            }

            return false;
        }

        public async Task<UserEntity> GetUserById(int idUser)
        {
            if(idUser > 0)
            {
                using var connection = userSession.CreateConnection();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@IdUser", idUser, DbType.Int32);
                var userModel = await connection.QueryFirstAsync<UserEntity>(GET_USER_BY_ID, dynamicParameters);
                return userModel;
            }

            return new UserEntity();
        }

        public async Task<bool> DeleteUserById(int id)
        {
            var userExists = await GetUserById(id);
            if (userExists is not null)
            {
                using var connection = userSession.CreateConnection();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@IdUser", id, DbType.Int32);
                await connection.ExecuteAsync(DELETE_USER, dynamicParameters);

                return true;
            }

            return false;
        }

        public async Task<int> ValidateUser(UserLogin userLogin)
        {
            using var connection = userSession.CreateConnection();
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@email_user", userLogin.Email, DbType.String);
            dynamicParameters.Add("@password_user", userLogin.Password, DbType.String);

            var idUser = await connection.QueryFirstOrDefaultAsync<int>(VALIDATE_USER, dynamicParameters);

            return idUser;
        }

        public async Task<string> GetUserByCpf(string CpfUser)
        {
            using var connection = userSession.CreateConnection();
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CPF", CpfUser, DbType.String);
            return await connection.QueryFirstAsync<string>(GET_USER_BY_CPF, dynamicParameters);
        }
    }
}
