using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DCliente
    {
        private int _idcliente;
        public int IDCliente { get => _idcliente; set => _idcliente = value; }

        private string _nombre;
        public string Nombre { get => _nombre; set => _nombre = value; }

        private string _apellidos;
        public string Apellidos { get => _apellidos; set => _apellidos = value; }

        private string _sexo;
        public string Sexo { get => _sexo; set => _sexo = value; }

        private DateTime _fecha_nacimiento;
        public DateTime Fecha_nacimiento { get => _fecha_nacimiento; set => _fecha_nacimiento = value; }

        private string _tipo_documento;
        public string Tipo_documento { get => _tipo_documento; set => _tipo_documento = value; }

        private string _num_documento;
        public string Num_documento { get => _num_documento; set => _num_documento = value; }

        private string _direccion;
        public string Direccion { get => _direccion; set => _direccion = value; }

        private string _telefono;
        public string Telefono { get => _telefono; set => _telefono = value; }

        private string _email;
        public string Email { get => _email; set => _email = value; }

        private string _TextoBuscar;
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructor vacío
        public DCliente()
        {

        }

        //Constructor
        public DCliente(
            int idcliente,
            string nombre,
            string apellidos,
            string sexo,
            DateTime fechanacimiento,
            string tipo_documento,
            string num_documento,
            string direccion,
            string telefono,
            string email)
        {
            IDCliente = idcliente;
            Nombre = nombre;
            Apellidos = apellidos;
            Sexo = sexo;
            Fecha_nacimiento = fechanacimiento;
            Tipo_documento = tipo_documento;
            Num_documento = num_documento;
            Direccion = direccion;
            Telefono = telefono;
            Email = email;
        }

        //Método Insertar
        public string Insertar(DCliente Cliente)
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
                SqlCmd.CommandText = "spcliente_insertar";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIDCliente = new SqlParameter();
                ParIDCliente.ParameterName = "@idcliente";
                ParIDCliente.SqlDbType = SqlDbType.Int;
                ParIDCliente.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIDCliente);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Cliente.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidos = new SqlParameter();
                ParApellidos.ParameterName = "@apellidos";
                ParApellidos.SqlDbType = SqlDbType.VarChar;
                ParApellidos.Size = 40;
                ParApellidos.Value = Cliente.Apellidos;
                SqlCmd.Parameters.Add(ParApellidos);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 1;
                ParSexo.Value = Cliente.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParFechaNacimiento = new SqlParameter();
                ParFechaNacimiento.ParameterName = "@fecha_nacimiento";
                ParFechaNacimiento.SqlDbType = SqlDbType.DateTime;
                ParFechaNacimiento.Value = Cliente.Fecha_nacimiento;
                SqlCmd.Parameters.Add(ParFechaNacimiento);

                SqlParameter ParTipoDocumento = new SqlParameter();
                ParTipoDocumento.ParameterName = "@tipo_documento";
                ParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                ParTipoDocumento.Size = 20;
                ParTipoDocumento.Value = Cliente.Tipo_documento;
                SqlCmd.Parameters.Add(ParTipoDocumento);

                SqlParameter ParNumDocumento = new SqlParameter();
                ParNumDocumento.ParameterName = "@num_documento";
                ParNumDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumDocumento.Size = 11;
                ParNumDocumento.Value = Cliente.Num_documento;
                SqlCmd.Parameters.Add(ParNumDocumento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Cliente.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 10;
                ParTelefono.Value = Cliente.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Cliente.Email;
                SqlCmd.Parameters.Add(ParEmail);

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
        public string Editar(DCliente Cliente)
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
                SqlCmd.CommandText = "spcliente_editar";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIDCliente = new SqlParameter();
                ParIDCliente.ParameterName = "@idcliente";
                ParIDCliente.SqlDbType = SqlDbType.Int;
                ParIDCliente.Value = Cliente.IDCliente;
                SqlCmd.Parameters.Add(ParIDCliente);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Cliente.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidos = new SqlParameter();
                ParApellidos.ParameterName = "@apellidos";
                ParApellidos.SqlDbType = SqlDbType.VarChar;
                ParApellidos.Size = 40;
                ParApellidos.Value = Cliente.Apellidos;
                SqlCmd.Parameters.Add(ParApellidos);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 1;
                ParSexo.Value = Cliente.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParFechaNacimiento = new SqlParameter();
                ParFechaNacimiento.ParameterName = "@fecha_nacimiento";
                ParFechaNacimiento.SqlDbType = SqlDbType.DateTime;
                ParFechaNacimiento.Value = Cliente.Fecha_nacimiento;
                SqlCmd.Parameters.Add(ParFechaNacimiento);

                SqlParameter ParTipoDocumento = new SqlParameter();
                ParTipoDocumento.ParameterName = "@tipo_documento";
                ParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                ParTipoDocumento.Size = 20;
                ParTipoDocumento.Value = Cliente.Tipo_documento;
                SqlCmd.Parameters.Add(ParTipoDocumento);

                SqlParameter ParNumDocumento = new SqlParameter();
                ParNumDocumento.ParameterName = "@num_documento";
                ParNumDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumDocumento.Size = 11;
                ParNumDocumento.Value = Cliente.Num_documento;
                SqlCmd.Parameters.Add(ParNumDocumento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Cliente.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 10;
                ParTelefono.Value = Cliente.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Cliente.Email;
                SqlCmd.Parameters.Add(ParEmail);

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
        public string Eliminar(DCliente Cliente)
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
                SqlCmd.CommandText = "spcliente_eliminar";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIDCliente = new SqlParameter();
                ParIDCliente.ParameterName = "@idcliente";
                ParIDCliente.SqlDbType = SqlDbType.Int;
                ParIDCliente.Value = Cliente.IDCliente;
                SqlCmd.Parameters.Add(ParIDCliente);

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
            DataTable DtResultado = new DataTable("cliente");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Establecer la conexión
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spcliente_mostrar";
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

        //Método BuscarApellido
        public DataTable BuscarApellido(DCliente Cliente)
        {
            DataTable DtResultado = new DataTable("cliente");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Establecer la conexión
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spcliente_buscar_apellido";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Cliente.TextoBuscar;
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

        //Método BuscarNum_Documento
        public DataTable BuscarNum_Documento(DCliente Cliente)
        {
            DataTable DtResultado = new DataTable("cliente");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Establecer la conexión
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spcliente_buscar_num_documento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Cliente.TextoBuscar;
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