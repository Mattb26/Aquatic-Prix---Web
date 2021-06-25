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


                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        reader.Read();
                                        personaUsuario.IdPersona = Int32.Parse(reader["idPesona"].ToString());
                                    }
                                }


                                if (personaUsuario.IdPersona > 0)
                                {
                                    personaUsuario.Usuario.IdUsuario = AgregarUsuario(personaUsuario.Usuario, transaction);
                                }

                                if ((personaUsuario.IdPersona > 0) && (personaUsuario.Usuario.IdUsuario > 0))
                                {
                                    if (AgregarPersonaUsuario(personaUsuario.IdPersona, personaUsuario.Usuario.IdUsuario, transaction))
                                    {
                                        transaction.Commit();
                                        return true;
                                    }
                                    else
                                    {
                                        transaction.Rollback();
                                        return false;
                                    }
                                }
                                else
                                {
                                    transaction.Rollback();
                                    return false;
                                }

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

        private Int32 AgregarUsuario(Models.Usuario usuario, SqlTransaction sqlTransaction)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_a_usuario", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = sqlTransaction;
                        cmd.Connection = sqlTransaction.Connection;

                        cmd.Parameters.Clear();

                        cmd.Parameters.Add(new SqlParameter("@nombreUsuario", usuario.NombreUsuario));
                        cmd.Parameters.Add(new SqlParameter("@clave", usuario.Clave));
                        cmd.Parameters.Add(new SqlParameter("@estado", usuario.Estado));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                return Int32.Parse(reader["idUsuario"].ToString());
                            }
                            else 
                            {
                                return 0;
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

        private bool AgregarPersonaUsuario(Int32 idPersona, Int32 idUsuario, SqlTransaction sqlTransaction)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_a_personausuario", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = sqlTransaction;
                        cmd.Connection = sqlTransaction.Connection;

                        cmd.Parameters.Clear();

                        cmd.Parameters.Add(new SqlParameter("@idPersona", idPersona));
                        cmd.Parameters.Add(new SqlParameter("@idUsuario", idUsuario));

                        int operacion = cmd.ExecuteNonQuery();
                        if (operacion > 0) return true;
                        else return false;

                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Models.PersonaUsuario Login(Models.Usuario usuario)
        {
            Models.PersonaUsuario personaUsuario;

            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.StringConexion()))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_l_validarLogin", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        try
                        {

                            cmd.Parameters.Add(new SqlParameter("@nombreUsuario", usuario.NombreUsuario));
                            cmd.Parameters.Add(new SqlParameter("@clave", usuario.Clave));


                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    personaUsuario = new Models.PersonaUsuario();
                                    reader.Read();
                                    personaUsuario.IdPersona = Int32.Parse(reader["id"].ToString());
                                    personaUsuario.Nombre = reader["nombre"].ToString();
                                    personaUsuario.Apellido = reader["apellido"].ToString();
                                    personaUsuario.CorreoElectronico = reader["correoElectronico"].ToString();
                                    personaUsuario.FechaNacimiento = DateTime.Parse(reader["fechaNacimiento"].ToString());

                                    personaUsuario.Usuario = new Models.Usuario();
                                    personaUsuario.Usuario.IdUsuario = Int32.Parse(reader["idUsuario"].ToString());
                                    personaUsuario.Usuario.Estado = Int32.Parse(reader["estado"].ToString());
                                    personaUsuario.Usuario.Clave = string.Empty;
                                    personaUsuario.Usuario.NombreUsuario = usuario.NombreUsuario;

                                    return personaUsuario;
                                }
                                else
                                {
                                    return null;
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

        public bool ExisteUsuario(string usuario)
        {
            Models.PersonaUsuario personaUsuario;

            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.StringConexion()))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_l_validar_usuario", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        try
                        {

                            cmd.Parameters.Add(new SqlParameter("@nombreUsuario ", usuario));

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
