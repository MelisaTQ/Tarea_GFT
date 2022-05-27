using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Tarea_GFT.Models;

namespace Tarea_GFT.Data
{
    public class EmployeeData
    {
        public static bool Registrar(Employee oEmpleado)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("emp_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@firstname", oEmpleado.FirstName);
                cmd.Parameters.AddWithValue("@lastname", oEmpleado.LastName);
                cmd.Parameters.AddWithValue("@email", oEmpleado.Email);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static bool Modificar(Employee oEmpleado)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("emp_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", oEmpleado.Id);
                cmd.Parameters.AddWithValue("@firstname", oEmpleado.FirstName);
                cmd.Parameters.AddWithValue("@lastname", oEmpleado.LastName);
                cmd.Parameters.AddWithValue("@email", oEmpleado.Email);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static List<Employee> Listar()
        {
            List<Employee> oListaEmpleado = new List<Employee>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("emp_listar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oListaEmpleado.Add(new Employee()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                FirstName = (string)dr["FirstName"],
                                LastName = (string)dr["LastName"],
                                Email = (string)dr["Email"],
                            });
                        }

                    }



                    return oListaEmpleado;
                }
                catch (Exception ex)
                {
                    return oListaEmpleado;
                }
            }
        }

        public static Employee Obtener(int id)
        {
            Employee oEmpleado = new Employee();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("emp_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oEmpleado = new Employee()
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                FirstName = (string)dr["FirstName"],
                                LastName = (string)dr["LastName"],
                                Email = (string)dr["Email"],
                            };
                        }

                    }



                    return oEmpleado;
                }
                catch (Exception ex)
                {
                    return oEmpleado;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("emp_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}