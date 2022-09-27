using System.Text;

namespace MC.Repository.DatabaseUtils
{
    public class DatabaseUtil
    {
        private const char PATH_SEPARATOR = '.';

        public static string LoadResourceFile(string resourcePath, string resourceName)
        {
            var executingAssembly = typeof(DatabaseUtil).Assembly;
            var sqlStatement = string.Empty;
            var pathBuilder = new StringBuilder();

            pathBuilder.Append(resourcePath);
            pathBuilder.Append(PATH_SEPARATOR);
            pathBuilder.Append(resourceName);

            var sqlResourcePath = pathBuilder.ToString();

            using var stream = executingAssembly.GetManifestResourceStream(sqlResourcePath);
            if (stream != null)
            {
                sqlStatement = new StreamReader(stream).ReadToEnd();
            }

            return sqlStatement;
        }

        public static string LoadSqlStatement(string statementName, string controllerNamespace)
        {
            return DatabaseUtil.LoadResourceFile(string.Format("{0}.Query", controllerNamespace ?? string.Empty), statementName);
        }
    }
}
