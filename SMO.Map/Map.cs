using Microsoft.Extensions.DependencyInjection;
using SMO.Business.Address;
using SMO.Business.Login;
using SMO.Business.User;
using SMO.Frontier.Interfaces.Business.Address;
using SMO.Frontier.Interfaces.Business.Login;
using SMO.Frontier.Interfaces.Business.User;
using SMO.Frontier.Repository.Address;
using SMO.Frontier.Repository.User;
using SMO.Repository.Address;
using SMO.Repository.User;
using SMO.Utils.Data;
using System.Data;

namespace SMO.Map
{
    public static class Map
    {
        public static void SetupDependenceInjection(IServiceCollection services)
        {
            #region Business
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IAddressBusiness, AddressBusiness>();
            services.AddScoped<ILoginBusiness, LoginBusiness>();
            #endregion

            #region Repository
            services.AddScoped<DbSession>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            #endregion
        }
    }
}