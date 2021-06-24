using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AquaticApi.DataAccess
{
    public class Estadisticas
    {
        public IList<Models.Estadisticas> Listado()
        {
            Models.Estadisticas estadisticas;
            IList<Models.Estadisticas> listEstadisticas = new List<Models.Estadisticas>();
            try
            {
                using (SqlConnection cn = new SqlConnection(Conexion.StringConexion()))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_l_estadisticas", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        try
                        {

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {


                                    while (reader.Read())
                                    {
                                        estadisticas = new Models.Estadisticas();
                                        estadisticas.NombreUsuario = reader["nombreUsuario"].ToString();
                                        estadisticas.Perdido = Int32.Parse(reader["perdido"].ToString());
                                        estadisticas.Posicion = Int32.Parse(reader["posicion"].ToString());
                                        estadisticas.Promediobaja = Int32.Parse(reader["promediobaja"].ToString());
                                        estadisticas.PromedioCaidas = Int32.Parse(reader["promedioCaidas"].ToString());
                                        estadisticas.PromedioPartidas = Int32.Parse(reader["promedioPartidas"].ToString());
                                        estadisticas.Fecha = DateTime.Parse(reader["fecha"].ToString());

                                        listEstadisticas.Add(estadisticas);
                                    }

                                    return listEstadisticas;
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
    }
}
