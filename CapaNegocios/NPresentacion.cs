using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NPresentacion
    {
        //Método Insertar
        public static string Insertar(string nombre, string descripcion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Insertar(Obj);
        }

        //Método Editar
        public static string Editar(int idpresentacion, string nombre, string descripcion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.IdPresentacion = idpresentacion;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            return Obj.Editar(Obj);
        }

        //Método Eliminar
        public static string Eliminar(int idpresentacion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.IdPresentacion = idpresentacion;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar
        public static DataTable Mostrar()
        {
            return new DPresentacion().Mostrar();
        }

        //Método Buscar
        public static DataTable BuscarNombre(string textobuscar)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);
        }
    }
}