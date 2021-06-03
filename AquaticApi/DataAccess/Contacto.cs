using System;
using System.Data;
using System.Data.SqlClient;

namespace AquaticApi.DataAccess
{
    public class Contacto
    {
        public bool Agregar(Models.Contacto contacto)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.StringConexion()))
                {
                    cn.Open();
                    using (SqlTransaction transaction = cn.BeginTransaction())
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_a_contacto", cn, transaction))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            try
                            {

                                cmd.Parameters.Add(new SqlParameter("@nombre", contacto.Nombre));
                                cmd.Parameters.Add(new SqlParameter("@asunto", contacto.Asunto));
                                cmd.Parameters.Add(new SqlParameter("@correoElectronico", contacto.CorreoElectronico));
                                cmd.Parameters.Add(new SqlParameter("@mensaje ", contacto.Mensaje));

                                cmd.ExecuteNonQuery();


                                transaction.Commit();
                                return true;
                            }
                            catch (SqlException ex)
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
