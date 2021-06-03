using System;

namespace AquaticApi.DataAccess
{
    public class Conexion
    {
        public static string StringConexion()
        {


            try
            {

                string Conexion = "Server=" + Environment.GetEnvironmentVariable("SQL_SERVICE") +
                                       "; Database=" + Environment.GetEnvironmentVariable("SQL_DATABASE") +
                                       "; User id=" + Environment.GetEnvironmentVariable("USERNAME_SQL") +
                                       "; Password=" + Environment.GetEnvironmentVariable("PASSWORD_SQL") + ";";

                return Conexion;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
