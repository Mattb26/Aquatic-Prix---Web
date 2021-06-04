using System;
using System.Data;
using System.Data.SqlClient;

namespace AquaticApi.DataAccess
{
    public class Persona
    {
        public bool Agregar(Models.PersonaUsuario personaUsuario)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.StringConexion()))
                {
                    cn.Open();
                    using (SqlTransaction transaction = cn.BeginTransaction())
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_a_persona", cn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            try
                            {

                                cmd.Parameters.Add(new SqlParameter("@nombre", personaUsuario.Nombre));
                                cmd.Parameters.Add(new SqlParameter("@apellido", personaUsuario.Apellido));
                                cmd.Parameters.Add(new SqlParameter("@correoElectronico", personaUsuario.CorreoElectronico));
                                cmd.Parameters.Add(new SqlParameter("@fechaNacimiento ", personaUsuario.FechaNacimiento));

                                cmd.ExecuteNonQuery();


                                transaction.Commit();
                                return true;
                            }
                            catch (SqlException)
                            {
                                transaction.Rollback();
                                throw;
                            }
                            catch (Exception)
                            {
                                transaction.Rollback();
                                throw;
                            }
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
