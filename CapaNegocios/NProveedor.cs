using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NProveedor
    {
        //Método Insertar
        public static string Insertar(
            string razon_social,
            string sector_comercial,
            string tipo_documento,
            string num_documento,
            string direccion,
            string telefono,
            string email,
            string url
            )
        {
            DProveedor Obj = new DProveedor();
            Obj.Razon_social = razon_social;
            Obj.Sector_comercial = sector_comercial;
            Obj.Tipo_documento = tipo_documento;
            Obj.Num_documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Url = url;
            return Obj.Insertar(Obj);
        }

        //Método Editar
        public static string Editar(
            int iDProveedor,
            string razon_social,
            string sector_comercial,
            string tipo_documento,
            string num_documento,
            string direccion,
            string telefono,
            string email,
            string url)
        {
            DProveedor Obj = new DProveedor();
            Obj.IDProveedor = iDProveedor;
            Obj.Razon_social = razon_social;
            Obj.Sector_comercial = sector_comercial;
            Obj.Tipo_documento = tipo_documento;
            Obj.Num_documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Url = url;
            return Obj.Editar(Obj);
        }

        //Método Eliminar
        public static string Eliminar(int iDProveedor)
        {
            DProveedor Obj = new DProveedor();
            Obj.IDProveedor = iDProveedor;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar
        public static DataTable Mostrar()
        {
            return new DProveedor().Mostrar();
        }

        //Método Buscar_Razon_Social
        public static DataTable Buscar_Razon_Social(string textobuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarRazon_Social(Obj);
        }

        //Método Buscar_Num_Documento
        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNum_Documento(Obj);
        }
    }
}