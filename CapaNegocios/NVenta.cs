using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocios
{
    public class NVenta
    {
        //Método Insertar
        public static string Insertar(int idtrabajador, int idcliente, DateTime fecha, string tipo_comprobante, string serie, string correlativo, decimal igv, DataTable dtDetalles)
        {
            DVenta Obj = new DVenta();
            Obj.Idtrabajador = idtrabajador;
            Obj.Idcliente = idcliente;
            Obj.Fecha = fecha;
            Obj.Tipo_comprobante = tipo_comprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Igv = igv;
            List<DDetalleVenta> detalles = new List<DDetalleVenta>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DDetalleVenta detalle = new DDetalleVenta();
                detalle.Iddetalleingreso = Convert.ToInt32(row["iddetalle_ingreso"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["cantidad"].ToString());
                detalle.Precio_venta = Convert.ToDecimal(row["precio_venta"].ToString());
                detalle.Descuento = Convert.ToDecimal(row["descuento"].ToString());
                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj, detalles);
        }

        //Método Eliminar
        public static string Eliminar(int idventa)
        {
            DVenta Obj = new DVenta();
            Obj.IDVenta = idventa;
            return Obj.Eliminar(Obj);
        }

        //Método Mostrar
        public static DataTable Mostrar()
        {
            return new DVenta().Mostrar();
        }

        //Método BuscarFecha
        public static DataTable BuscarFecha(string textobuscar, string textobuscar2)
        {
            DVenta Obj = new DVenta();
            return Obj.BuscarFecha(textobuscar, textobuscar2);
        }

        //Método MostrarDetalle
        public static DataTable MostrarDetalle(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarDetalle(textobuscar);
        }

        //Método MostrarArticulo_Venta_Nombre
        public static DataTable MostrarArticulo_Venta_Nombre(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarArticulo_Venta_Nombre(textobuscar);
        }

        //Método MostrarArticulo_Venta_Codigo
        public static DataTable MostrarArticulo_Venta_Codigo(string textobuscar)
        {
            DVenta Obj = new DVenta();
            return Obj.MostrarArticulo_Venta_Codigo(textobuscar);
        }
    }
}