using BLL.PROVEEDOR.Validator;
using BLL.VENTA.Validation;
using DAL;
using MODELS.VENTA.DTO;
using MODELS.VENTA_DETALLE.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.VENTA
{
    public class BL_VENTA
    {

        public static async Task<IEnumerable<string>> ValidaCarrito(DtoCarrito PCarrito)
        {
            List<string> lstValidacion = [];

            ValidacionVenta ValidationRules = new();
            var Resultado = ValidationRules.Validate(PCarrito);

            if (!Resultado.IsValid)
            {
                lstValidacion = Resultado.Errors.Select(x => x.ErrorMessage).ToList();
            }

            if (!await ValidaPago(PCarrito))
            {
                lstValidacion.Add("Revise que el pago cubra el total de la venta");
            }

            return await Task.FromResult(lstValidacion.AsEnumerable());
        }

        private static async Task<bool> ValidaPago(DtoCarrito PCarrito)
        {
            bool Validacion = true;

            var total = PCarrito.CarritoDetalles.Sum(x => ((x.Cantidad * x.PVenta) * (1 + (x.IVA / 100))));

            if (PCarrito.Pago < total)
            {
                Validacion = false;
            }

            return Validacion;
        }

        public static async Task<IEnumerable<string>> Venta(string PCadena, DtoCarrito PCarrito)
        {
            List<string> lstDatos = [];

            var Total = PCarrito.CarritoDetalles.Sum(x => ((x.Cantidad * x.PVenta) * (1 + (x.IVA / 100))));

            try
            {
                var dpParametros = new
                {
                    P_Accion = 1,
                    P_Pago = PCarrito.Pago,
                    P_Cambio = PCarrito.Pago - Total
                };

                DataTable Dt = await Contexto.Funcion_StoreDB(PCadena, "spVenta", dpParametros);

                if (Dt.Rows.Count > 0)
                {
                    int IdVenta = (int)Dt.Rows[0][0];

                    if (await VentaDetalle(PCadena, PCarrito.CarritoDetalles, IdVenta))
                    {
                        lstDatos.Add("00");
                        lstDatos.Add("Venta realizada con éxito");
                    }

                }
                else
                {
                    lstDatos.Add("14");
                    lstDatos.Add("Venta no realizada");
                }
            }
            catch (Exception ex)
            {
                lstDatos.Add("14");
                lstDatos.Add(ex.Message);
            }

            return await Task.FromResult(lstDatos);
        }

        private static async Task<bool> VentaDetalle(string PCadena, List<DtoCarritoDetalle> PCarritoDetalle, int PIdVenta)
        {
            bool Validacion = true;

            try
            {
                foreach(DtoCarritoDetalle lst in PCarritoDetalle)
                {
                    var dpParametros = new
                    {
                        P_Accion = 2,
                        P_IdVenta = PIdVenta,
                        P_IdProducto = lst.IdProducto,
                        P_Cantidad = lst.Cantidad,
                        P_PVenta = lst.PVenta,
                        P_IVA = lst.IVA
                    };

                   Contexto.Procedimiento_StoreDB(PCadena, "spVenta", dpParametros);

                }
            }

            catch (Exception)
            {
                Validacion = false;
            }

            return await Task.FromResult(Validacion);
        }

    }

}
