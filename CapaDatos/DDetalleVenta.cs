using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalleVenta
    {
        private int _iddetalle_venta;
        public int Iddetalle_venta { get => _iddetalle_venta; set => _iddetalle_venta = value; }

        private int _idventa;
        public int Idventa { get => _idventa; set => _idventa = value; }

        private int _iddetalleingreso;
        public int Iddetalleingreso { get => _iddetalleingreso; set => _iddetalleingreso = value; }

        private int _cantidad;
        public int Cantidad { get => _cantidad; set => _cantidad = value; }

        private decimal _precio_venta;
        public decimal Precio_venta { get => _precio_venta; set => _precio_venta = value; }

        private decimal _descuento;
        public decimal Descuento { get => _descuento; set => _descuento = value; }

        //Constructor vacío
        public DDetalleVenta()
        {

        }

        //Constructor
        public DDetalleVenta(int iddetalle_venta, int idventa, int iddetalleingreso, int cantidad, decimal precio_venta, decimal descuento)
        {
            Iddetalle_venta = iddetalle_venta;
            Idventa = idventa;
            Iddetalleingreso = iddetalleingreso;
            Cantidad = cantidad;
            Precio_venta = precio_venta;
            Descuento = descuento;
        }

        //Método Insertar
        public string Insertar(DDetalleVenta DetalleVenta, ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {
                //Establecer el Comando

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spventa_detalle_insertar";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIDDetalleVenta = new SqlParameter();
                ParIDDetalleVenta.ParameterName = "@iddetalle_venta";
                ParIDDetalleVenta.SqlDbType = SqlDbType.Int;
                ParIDDetalleVenta.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIDDetalleVenta);

                SqlParameter ParIdventa = new SqlParameter();
                ParIdventa.ParameterName = "@idventa";
                ParIdventa.SqlDbType = SqlDbType.Int;
                ParIdventa.Value = DetalleVenta.Idventa;
                SqlCmd.Parameters.Add(ParIdventa);

                SqlParameter ParIddetalleingreso = new SqlParameter();
                ParIddetalleingreso.ParameterName = "@iddetalle_ingreso";
                ParIddetalleingreso.SqlDbType = SqlDbType.Int;
                ParIddetalleingreso.Value = DetalleVenta.Iddetalleingreso;
                SqlCmd.Parameters.Add(ParIddetalleingreso);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = DetalleVenta.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                SqlParameter ParPrecioVenta = new SqlParameter();
                ParPrecioVenta.ParameterName = "@precio_venta";
                ParPrecioVenta.SqlDbType = SqlDbType.Money;
                ParPrecioVenta.Value = DetalleVenta.Precio_venta;
                SqlCmd.Parameters.Add(ParPrecioVenta);

                SqlParameter ParDescuento = new SqlParameter();
                ParDescuento.ParameterName = "@descuento";
                ParDescuento.SqlDbType = SqlDbType.Money;
                ParDescuento.Value = DetalleVenta.Descuento;
                SqlCmd.Parameters.Add(ParDescuento);

                //Ejecutar comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingresó el Registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            return rpta;
        }
    }
}