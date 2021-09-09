using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace AquaticApi.DataAccess
{
    public class Conexion
    {
        public static string StringConexion()
        {
            string Conexion;

            try
            {

                var builder = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json");

                var configuration = builder.Build();

                Conexion = "Server=" + configuration["Servidor"] +
                            "; Database=" + configuration["BaseDatos"] +
                            "; User id=" + configuration["Usuario"] +
                            "; Password=" + configuration["Pass"] + ";";

  
                return Conexion;
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
