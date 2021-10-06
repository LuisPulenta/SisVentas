using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalleIngreso
    {
        private int _iddetalle_ingreso;
        public int Iddetalle_ingreso { get => _iddetalle_ingreso; set => _iddetalle_ingreso = value; }

        private int _idingreso;
        public int Idingreso { get => _idingreso; set => _idingreso = value; }

        private int _idarticulo;
        public int Idarticulo { get => _idarticulo; set => _idarticulo = value; }

        private decimal _precio_compra;
        public decimal Precio_compra { get => _precio_compra; set => _precio_compra = value; }

        private decimal _precio_venta;
        public decimal Precio_venta { get => _precio_venta; set => _precio_venta = value; }

        private int _stock_inicial;
        public int Stock_inicial { get => _stock_inicial; set => _stock_inicial = value; }

        private int _stock_actual;
        public int Stock_actual { get => _stock_actual; set => _stock_actual = value; }

        private DateTime _fecha_produccion;
        public DateTime Fecha_produccion { get => _fecha_produccion; set => _fecha_produccion = value; }

        private DateTime _fecha_vencimiento;
        public DateTime Fecha_vencimiento { get => _fecha_vencimiento; set => _fecha_vencimiento = value; }

        //Constructor vacío
        public DDetalleIngreso()
        {

        }

        //Constructor
        public DDetalleIngreso(int iddetalle_ingreso, int idingreso, int idarticulo, decimal precio_compra, decimal precio_venta, int stock_inicial, int stock_actual, DateTime fecha_produccion, DateTime fecha_vencimiento)
        {
            Iddetalle_ingreso = iddetalle_ingreso;
            Idingreso = idingreso;
            Idarticulo = idarticulo;
            Precio_compra = precio_compra;
            Precio_venta = precio_venta;
            Stock_inicial = stock_inicial;
            Stock_actual = stock_actual;
            Fecha_produccion = fecha_produccion;
            Fecha_vencimiento = fecha_vencimiento;
        }

        //Método Insertar
        public string Insertar(DDetalleIngreso DetalleIngreso,ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string rpta = "";
            try
            {
                 //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "spingreso_detalle_insertar";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalleingreso = new SqlParameter();
                ParIddetalleingreso.ParameterName = "@@iddetalle_ingreso";
                ParIddetalleingreso.SqlDbType = SqlDbType.Int;
                ParIddetalleingreso.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIddetalleingreso);

                SqlParameter ParIdingreso = new SqlParameter();
                ParIdingreso.ParameterName = "@idingreso";
                ParIdingreso.SqlDbType = SqlDbType.Int;
                ParIdingreso.Value = DetalleIngreso.Idingreso;
                SqlCmd.Parameters.Add(ParIdingreso);

                SqlParameter ParIdarticulo = new SqlParameter();
                ParIdarticulo.ParameterName = "@idarticulo";
                ParIdarticulo.SqlDbType = SqlDbType.Int;
                ParIdarticulo.Value = DetalleIngreso.Idarticulo;
                SqlCmd.Parameters.Add(ParIdarticulo);

                SqlParameter ParPrecioCompra = new SqlParameter();
                ParPrecioCompra.ParameterName = "@precio_compra";
                ParPrecioCompra.SqlDbType = SqlDbType.Money;
                ParPrecioCompra.Value = DetalleIngreso.Precio_compra;
                SqlCmd.Parameters.Add(ParPrecioCompra);

                SqlParameter ParPrecioVenta = new SqlParameter();
                ParPrecioVenta.ParameterName = "@precio_venta";
                ParPrecioVenta.SqlDbType = SqlDbType.Money;
                ParPrecioVenta.Value = DetalleIngreso.Precio_venta;
                SqlCmd.Parameters.Add(ParPrecioVenta);

                SqlParameter ParStockinicial = new SqlParameter();
                ParStockinicial.ParameterName = "@stock_inicial";
                ParStockinicial.SqlDbType = SqlDbType.Int;
                ParStockinicial.Value = DetalleIngreso.Stock_inicial;
                SqlCmd.Parameters.Add(ParStockinicial);

                SqlParameter ParStockactual = new SqlParameter();
                ParStockactual.ParameterName = "@stock_actual";
                ParStockactual.SqlDbType = SqlDbType.Int;
                ParStockactual.Value = DetalleIngreso.Stock_actual;
                SqlCmd.Parameters.Add(ParStockactual);

                SqlParameter ParFechaproduccion = new SqlParameter();
                ParFechaproduccion.ParameterName = "@fecha_produccion";
                ParFechaproduccion.SqlDbType = SqlDbType.Date;
                ParFechaproduccion.Value = DetalleIngreso.Fecha_produccion;
                SqlCmd.Parameters.Add(ParFechaproduccion);

                SqlParameter ParFechavencimiento = new SqlParameter();
                ParFechavencimiento.ParameterName = "@fecha_vencimiento";
                ParFechavencimiento.SqlDbType = SqlDbType.Date;
                ParFechavencimiento.Value = DetalleIngreso.Fecha_vencimiento;
                SqlCmd.Parameters.Add(ParFechavencimiento);

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