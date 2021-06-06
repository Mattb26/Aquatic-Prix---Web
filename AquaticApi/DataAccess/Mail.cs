using System;
using System.Data;
using System.Data.SqlClient;

namespace AquaticApi.DataAccess
{
    public class Mail
    {
        public bool ExisteMail(string mail)
        {
            Models.PersonaUsuario personaUsuario;

            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.StringConexion()))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_l_validar_mail", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        try
                        {

                            cmd.Parameters.Add(new SqlParameter("@correoElectronico", mail));

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    personaUsuario = new Models.PersonaUsuario();
                                    reader.Read();

                                    if (bool.Parse(reader["estado"].ToString()))
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }

                                }
                                else
                                {
                                    return false;
                                }
                            }


                        }
                        catch (SqlException)
                        {
                            //transaction.Rollback();
                            throw;
                        }
                        catch (Exception)
                        {
                            //transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
