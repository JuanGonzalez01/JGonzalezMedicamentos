using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Proveedor
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
                        com.CommandText = "ProveedorGetAll";
                        com.CommandType = System.Data.CommandType.StoredProcedure;
                        com.Connection = context;

                        com.Connection.Open();

                        DataTable tableProveedor= new DataTable();

                        SqlDataAdapter adapter = new SqlDataAdapter(com);

                        adapter.Fill(tableProveedor);

                        if (tableProveedor.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableProveedor.Rows)
                            {
                                ML.Proveedor proveedor= new ML.Proveedor();

                                proveedor.IdProveedor = (int)row[0];
                                proveedor.Nombre = row[1].ToString();

                                result.Objects.Add(proveedor);
                            }

                            result.Status = true;
                        }
                        else
                        {
                            result.Status=false;
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
    }
}
