using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class NCliente
    {
        //Método Insertar
        public static string Insertar(
            string nombre,
            string apellidos,
            string sexo,
            DateTime fechanacimiento,
            string tipo_documento,
            string num_documento,
            string direccion,
            string telefono,
            string email
            )
        {
            DCliente Obj = new DCliente();
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_nacimiento = fechanacimiento;
            Obj.Tipo_documento = tipo_documento;
            Obj.Num_documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            return Obj.Insertar(Obj);
        }

        //Método Editar
        public static string Editar(
            int iDCliente,
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
            DCliente Obj = new DCliente();
            Obj.IDCliente = iDCliente;
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_nacimiento = fechanacimiento;
            Obj.Tipo_documento = tipo_documento;
            Obj.Num_documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            return Obj.Editar(Obj);
        }

        //Método Eliminar
        public static string Eliminar(int iDCliente)
        {
            DCliente Obj = new DCliente();
            Obj.IDCliente = iDCliente;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar
        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar();
        }

        //Método Buscar_Apellido
        public static DataTable Buscar_Apellido(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarApellido(Obj);
        }

        //Método Buscar_Num_Documento
        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNum_Documento(Obj);
        }
    }
}