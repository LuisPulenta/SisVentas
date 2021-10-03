using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DPresentacion
    {
        private int _IdPresentacion;
        public int IdPresentacion { get => _IdPresentacion; set => _IdPresentacion = value; }

        private string _Nombre;
        public string Nombre { get => _Nombre; set => _Nombre = value; }

        private string _Descripcion;
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }

        private string _TextoBuscar;
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructor vacío
        public DPresentacion()
        {

        }

        //Constructor
        public DPresentacion(int idpresentacion, string nombre, string descripcion, string textbuscar)
        {
            IdPresentacion = idpresentacion;
            Nombre = nombre;
            Descripcion = descripcion;
            TextoBuscar = textbuscar;
        }

        //Método Insertar
        public string Insertar(DPresentacion Presentacion)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Establecer la conexión
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sppresentacion_insertar";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdpresentacion = new SqlParameter();
                ParIdpresentacion.ParameterName = "@idpresentacion";
                ParIdpresentacion.SqlDbType = SqlDbType.Int;
                ParIdpresentacion.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdpresentacion);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Presentacion.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Presentacion.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Ejecutar comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingresó el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        //Método Editar
        public string Editar(DPresentacion Presentacion)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Establecer la conexión
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sppresentacion_editar";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdpresentacion = new SqlParameter();
                ParIdpresentacion.ParameterName = "@idpresentacion";
                ParIdpresentacion.SqlDbType = SqlDbType.Int;
                ParIdpresentacion.Value = Presentacion.IdPresentacion;
                SqlCmd.Parameters.Add(ParIdpresentacion);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Presentacion.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 256;
                ParDescripcion.Value = Presentacion.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Ejecutar comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se actualizó el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        //Método Eliminar
        public string Eliminar(DPresentacion Presentacion)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Establecer la conexión
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sppresentacion_eliminar";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdpresentacion = new SqlParameter();
                ParIdpresentacion.ParameterName = "@idpresentacion";
                ParIdpresentacion.SqlDbType = SqlDbType.Int;
                ParIdpresentacion.Value = Presentacion.IdPresentacion;
                SqlCmd.Parameters.Add(ParIdpresentacion);

                //Ejecutar comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se eliminó el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        //Método Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("presentacion");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Establecer la conexión
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sppresentacion_mostrar";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Ejecutar comando
                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return DtResultado;
        }

        //Método BuscarNombre
        public DataTable BuscarNombre(DPresentacion Presentacion)
        {
            DataTable DtResultado = new DataTable("presentacion");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Establecer la conexión
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sppresentacion_buscar";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Presentacion.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                //Ejecutar comando
                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return DtResultado;
        }
    }
}