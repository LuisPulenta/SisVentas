using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class NTrabajador
    {
        //Método Insertar
        public static string Insertar(
            string nombre,
            string apellidos,
            string sexo,
            DateTime fechanac,
            string tipo_documento,
            string num_documento,
            string direccion,
            string telefono,
            string email,
            string acceso,
            string usuario,
            string password
            )
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_nac = fechanac;
            Obj.Tipo_documento = tipo_documento;
            Obj.Num_documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Insertar(Obj);
        }

        //Método Editar
        public static string Editar(
            int iDTrabajador,
            string nombre,
            string apellidos,
            string sexo,
            DateTime fechanac,
            string tipo_documento,
            string num_documento,
            string direccion,
            string telefono,
            string email,
            string acceso,
            string usuario,
            string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.IDTrabajador = iDTrabajador;
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_nac = fechanac;
            Obj.Tipo_documento = tipo_documento;
            Obj.Num_documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Editar(Obj);
        }

        //Método Eliminar
        public static string Eliminar(int iDTrabajador)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.IDTrabajador = iDTrabajador;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar
        public static DataTable Mostrar()
        {
            return new DTrabajador().Mostrar();
        }

        //Método Buscar_Apellido
        public static DataTable Buscar_Apellido(string textobuscar)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarApellido(Obj);
        }

        //Método Buscar_Num_Documento
        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNum_Documento(Obj);
        }
    }
}