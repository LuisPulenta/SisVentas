using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocios
{
    public class NIngreso
    {
        //Método Insertar
        public static string Insertar(int idtrabajador, int idproveedor, DateTime fecha, string tipo_comprobante, string serie, string correlativo, decimal igv, string estado, DataTable dtDetalles)
        {
            DIngreso Obj = new DIngreso();
            Obj.Idtrabajador = idtrabajador;
            Obj.Idproveedor = idproveedor;
            Obj.Fecha = fecha;
            Obj.Tipo_comprobante = tipo_comprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Igv = igv;
            Obj.Estado = estado;
            List <DDetalleIngreso> detalles = new List<DDetalleIngreso>();
            foreach(DataRow row in dtDetalles.Rows)
            {
                DDetalleIngreso detalle = new DDetalleIngreso();
                detalle.Idarticulo = Convert.ToInt32(row["idarticulo"].ToString());
                detalle.Precio_compra = Convert.ToDecimal(row["precio_compra"].ToString());
                detalle.Precio_venta = Convert.ToDecimal(row["precio_venta"].ToString());
                detalle.Stock_inicial = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.Stock_actual = Convert.ToInt32(row["stock_actual"].ToString());
                detalle.Fecha_produccion = Convert.ToDateTime(row["fecha_produccion"].ToString());
                detalle.Fecha_vencimiento = Convert.ToDateTime(row["fecha_vencimiento"].ToString());
                detalles.Add(detalle);
            }
            return Obj.Insertar(Obj,detalles);
        }

        //Método Anular
        public static string Anular(int idingreso)
        {
            DIngreso Obj = new DIngreso();
            Obj.Idingreso = idingreso;
            return Obj.Anular(Obj);
        }

        //Método Mostrar
        public static DataTable Mostrar()
        {
            return new DIngreso().Mostrar();
        }

        //Método BuscarFecha
        public static DataTable BuscarFecha(string textobuscar, string textobuscar2)
        {
            DIngreso Obj = new DIngreso();
            return Obj.BuscarFecha(textobuscar, textobuscar2);
        }

        //Método BuscarDetalle
        public static DataTable BuscarDetalle(string textobuscar)
        {
            DIngreso Obj = new DIngreso();
            return Obj.MostrarDetalle(textobuscar);
        }
    }
}