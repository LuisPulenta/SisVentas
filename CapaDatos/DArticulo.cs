using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DArticulo
    {
        private int _IDArticulo;
        public int IDArticulo { get => _IDArticulo; set => _IDArticulo = value; }

        private string _Codigo;
        public string Codigo { get => _Codigo; set => _Codigo = value; }

        private string _Nombre;
        public string Nombre { get => _Nombre; set => _Nombre = value; }

        private string _Descripcion;
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }

        private byte[] _Imagen;
        public byte[] Imagen { get => _Imagen; set => _Imagen = value; }

        private int _Idcategoria;
        public int Idcategoria { get => _Idcategoria; set => _Idcategoria = value; }

        private int _Idpresentacion;
        public int Idpresentacion { get => _Idpresentacion; set => _Idpresentacion = value; }

        private string _TextoBuscar;
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructor vacío
        public DArticulo()
        {

        }

        //Constructor
        public DArticulo(int iDArticulo, string codigo, string nombre, string descripcion, byte[] imagen, int idcategoria, int idpresentacion, string textbuscar)
        {
            IDArticulo = iDArticulo;
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
            Imagen = imagen;
            Idcategoria = idcategoria;
            Idpresentacion = idpresentacion;
            TextoBuscar = textbuscar;
        }

        //Método Insertar
        public string Insertar(DArticulo Articulo)
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
                SqlCmd.CommandText = "sparticulo_insertar";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                
                SqlParameter ParIDArticulo = new SqlParameter();
                ParIDArticulo.ParameterName = "@idarticulo";
                ParIDArticulo.SqlDbType = SqlDbType.Int;
                ParIDArticulo.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIDArticulo);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 50;
                ParCodigo.Value = Articulo.Codigo;
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Articulo.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 1024;
                ParDescripcion.Value = Articulo.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Articulo.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idcategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Articulo.Idcategoria;
                SqlCmd.Parameters.Add(ParIdCategoria);

                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idpresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Value = Articulo.Idpresentacion;
                SqlCmd.Parameters.Add(ParIdPresentacion);

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
        public string Editar(DArticulo Articulo)
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
                SqlCmd.CommandText = "sparticulo_editar";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIDArticulo = new SqlParameter();
                ParIDArticulo.ParameterName = "@idarticulo";
                ParIDArticulo.SqlDbType = SqlDbType.Int;
                ParIDArticulo.Value = Articulo.IDArticulo;
                SqlCmd.Parameters.Add(ParIDArticulo);

                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 50;
                ParCodigo.Value = Articulo.Codigo;
                SqlCmd.Parameters.Add(ParCodigo);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Articulo.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 1024;
                ParDescripcion.Value = Articulo.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Articulo.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@idcategoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;
                ParIdCategoria.Value = Articulo.Idcategoria;
                SqlCmd.Parameters.Add(ParIdCategoria);

                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@idpresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Value = Articulo.Idpresentacion;
                SqlCmd.Parameters.Add(ParIdPresentacion);

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
        public string Eliminar(DArticulo Articulo)
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
                SqlCmd.CommandText = "sparticulo_eliminar";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIDArticulo = new SqlParameter();
                ParIDArticulo.ParameterName = "@idarticulo";
                ParIDArticulo.SqlDbType = SqlDbType.Int;
                ParIDArticulo.Value = Articulo.IDArticulo;
                SqlCmd.Parameters.Add(ParIDArticulo);

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
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Establecer la conexión
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sparticulo_mostrar";
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
        public DataTable BuscarNombre(DArticulo Articulo)
        {
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Establecer la conexión
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sparticulo_buscar";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Articulo.TextoBuscar;
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

        //Método Stock_Articulos
        public DataTable Stock_Articulos()
        {
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Establecer la conexión
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spstock_articulos";
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
    }
}