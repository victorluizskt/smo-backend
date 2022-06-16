using SMO.Frontier.Model.User;

namespace SMO.Utils.Validations
{
    public static class ValidationUser
    {
        public static bool ValidateUser(UserCreateModel userModel)
        {
            if (!string.IsNullOrWhiteSpace(userModel.Name)
               && !string.IsNullOrWhiteSpace(userModel.Email)
               && !string.IsNullOrWhiteSpace(userModel.CPF)
               && !string.IsNullOrWhiteSpace(userModel.Password)
               && !string.IsNullOrWhiteSpace(userModel.NumberPhone)) return true;

            return false;
        }
    }
}
