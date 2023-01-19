using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Medicamento
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Connection.GetConnectionString()))
                {
                    using (SqlCommand com = new SqlCommand())
                    {
                        com.CommandText = "MedicamentoGetAll";
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Connection = context;

                        com.Connection.Open();

                        DataTable tableMedicamento = new DataTable();

                        SqlDataAdapter adapter = new SqlDataAdapter(com);

                        adapter.Fill(tableMedicamento);

                        if (tableMedicamento.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableMedicamento.Rows)
                            {
                                ML.Medicamento medicamento = new ML.Medicamento();

                                medicamento.IdMedicamento = (int)row[0];
                                medicamento.Nombre = row[1].ToString();
                                medicamento.Descripcion= row[2].ToString();
                                medicamento.FechaCaducidad= row[3].ToString().Substring(0,9);
                                medicamento.PrecioUnitario = (decimal)row[4];
                                medicamento.Stock = (int)row[5];

                                medicamento.Proveedor = new ML.Proveedor();
                                medicamento.Proveedor.IdProveedor = (int)row[6];
                                medicamento.Proveedor.Nombre = row[7].ToString();

                                result.Objects.Add(medicamento);
                            }

                            result.Status = true;
                        }
                        else
                        {
                            result.Status = false;
                            result.Message = "Error al obtener registros de la base de datos.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
                result.Exception = ex;
            }

            return result;
        }

        public static ML.Result GetById(int idMedicamento)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Connection.GetConnectionString()))
                {
                    using (SqlCommand com = new SqlCommand())
                    {
                        com.CommandText = "MedicamentoGetById";
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Connection = context;

                        com.Connection.Open();

                        SqlParameter parameter = new SqlParameter("@IdMedicamento", SqlDbType.Int);
                        parameter.Value = idMedicamento;
                        com.Parameters.Add(parameter);

                        DataTable tableMedicamento = new DataTable();

                        SqlDataAdapter adapter = new SqlDataAdapter(com);

                        adapter.Fill(tableMedicamento);

                        if (tableMedicamento.Rows.Count > 0)
                        {
                            DataRow row = tableMedicamento.Rows[0];

                            ML.Medicamento medicamento = new ML.Medicamento();

                            medicamento.IdMedicamento = (int)row[0];
                            medicamento.Nombre = row[1].ToString();
                            medicamento.Descripcion = row[2].ToString();
                            medicamento.FechaCaducidad = row[3].ToString().Substring(0, 9);
                            medicamento.PrecioUnitario = (decimal)row[4];
                            medicamento.Stock = (int)row[5];

                            medicamento.Proveedor = new ML.Proveedor();
                            medicamento.Proveedor.IdProveedor = (int)row[6];
                            medicamento.Proveedor.Nombre = row[7].ToString();

                            result.Object = medicamento;

                            result.Status = true;
                        }
                        else
                        {
                            result.Status = false;
                            result.Message = "Error al obtener registros de la base de datos.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
                result.Exception = ex;
            }

            return result;
        }

        public static ML.Result Add(ML.Medicamento medicamento)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Connection.GetConnectionString()))
                {
                    using (SqlCommand com = new SqlCommand())
                    {
                        com.CommandText = "MedicamentoAdd";
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Connection = context;

                        com.Connection.Open();

                        SqlParameter[] parameter = new SqlParameter[6];

                        parameter[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                        parameter[0].Value = medicamento.Nombre;

                        parameter[1] = new SqlParameter("@Descripcion", SqlDbType.VarChar);
                        parameter[1].Value = medicamento.Descripcion;

                        parameter[2] = new SqlParameter("@FechaCaducidad", SqlDbType.VarChar);
                        parameter[2].Value = medicamento.FechaCaducidad;

                        parameter[3] = new SqlParameter("@PrecioUnitario", SqlDbType.Decimal);
                        parameter[3].Value = medicamento.PrecioUnitario;

                        parameter[4] = new SqlParameter("@Stock", SqlDbType.Int);
                        parameter[4].Value = medicamento.Stock;

                        parameter[5] = new SqlParameter("@IdProveedor", SqlDbType.Int);
                        parameter[5].Value = medicamento.Proveedor.IdProveedor;

                        com.Parameters.AddRange(parameter);

                        int rowsAffected = com.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Status = true;
                        }
                        else
                        {
                            result.Status = false;
                            result.Message = "Error al añadir registros de la base de datos.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
                result.Exception = ex;
            }

            return result;
        }

        public static ML.Result Update(ML.Medicamento medicamento)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Connection.GetConnectionString()))
                {
                    using (SqlCommand com = new SqlCommand())
                    {
                        com.CommandText = "MedicamentoUpdate";
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Connection = context;

                        com.Connection.Open();

                        SqlParameter[] parameter = new SqlParameter[7];

                        parameter[0] = new SqlParameter("@IdMedicamento", SqlDbType.Int);
                        parameter[0].Value = medicamento.IdMedicamento;

                        parameter[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                        parameter[1].Value = medicamento.Nombre;

                        parameter[2] = new SqlParameter("@Descripcion", SqlDbType.VarChar);
                        parameter[2].Value = medicamento.Descripcion;

                        parameter[3] = new SqlParameter("@FechaCaducidad", SqlDbType.VarChar);
                        parameter[3].Value = medicamento.FechaCaducidad;

                        parameter[4] = new SqlParameter("@PrecioUnitario", SqlDbType.Decimal);
                        parameter[4].Value = medicamento.PrecioUnitario;

                        parameter[5] = new SqlParameter("@Stock", SqlDbType.Int);
                        parameter[5].Value = medicamento.Stock;

                        parameter[6] = new SqlParameter("@IdProveedor", SqlDbType.Int);
                        parameter[6].Value = medicamento.Proveedor.IdProveedor;

                        com.Parameters.AddRange(parameter);

                        int rowsAffected = com.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Status = true;
                        }
                        else
                        {
                            result.Status = false;
                            result.Message = "Error al modificar registros de la base de datos.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
                result.Exception = ex;
            }

            return result;
        }

        public static ML.Result Delete(int idMedicamento)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Connection.GetConnectionString()))
                {
                    using (SqlCommand com = new SqlCommand())
                    {
                        com.CommandText = "MedicamentoDelete";
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Connection = context;

                        com.Connection.Open();

                        SqlParameter parameter = new SqlParameter("@IdMedicamento", SqlDbType.Int);
                        parameter.Value = idMedicamento;

                        com.Parameters.Add(parameter);

                        int rowsAffected = com.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            result.Status = true;
                        }
                        else
                        {
                            result.Status = false;
                            result.Message = "Error al añadir eliminar registros de la base de datos.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
                result.Exception = ex;
            }

            return result;
        }
    }
}
