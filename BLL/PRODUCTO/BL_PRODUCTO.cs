using BLL.PRODUCTO.Validator;
using BLL.PROVEEDOR.Validator;
using DAL;
using MODELS.PRODUCTO.DTO;
using MODELS.PROVEEDOR.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BLL.PRODUCTO;

public class BL_PRODUCTO
{

    public static async Task<IEnumerable<string>> ValidarProducto(DtoAltaProducto PAltaProducto)
    {
        List<string> lstValidacion = [];

        ValidacionAltaProducto ValidationRules = new();
        var Resultado = ValidationRules.Validate(PAltaProducto);

        if (!Resultado.IsValid)
        {
            lstValidacion = Resultado.Errors.Select(x => x.ErrorMessage).ToList();
        }

        return await Task.FromResult(lstValidacion.AsEnumerable());

    }

    public static async Task<IEnumerable<string>> GuardarProducto(string PCadena, DtoAltaProducto PAltaProducto)
    {
        List<string> lstDatos = [];

        string SQLScript = "INSERT INTO PRODUCTO (Descrip,SKU,CB,IdProveedor,IVA,PVenta) VALUES (@P_Descrip,@P_SKU,@P_CB,@P_IdProveedor,@P_IVA,@P_PVenta)";

        try
        {
            var dpParametros = new
            {
                P_Descrip = PAltaProducto.Descrip,
                P_SKU = PAltaProducto.SKU,
                P_CB = PAltaProducto.CB,
                P_IdProveedor = PAltaProducto.IdProveedor,
                P_IVA = PAltaProducto.IVA,
                P_PVenta = PAltaProducto.PVenta
            };

            Contexto.Procedimiento_ScriptDB(PCadena, SQLScript, dpParametros);

            lstDatos.Add("00");
            lstDatos.Add("El producto se guardo con éxito");

        }

        catch (Exception ex)
        {

            lstDatos.Add("14");
            lstDatos.Add(ex.Message);

        }

        return await Task.FromResult(lstDatos.AsEnumerable());
    }

    public static async Task<IEnumerable<DtoConsulProducto>> ConsultaProducto(string PCadena)
    {
        IEnumerable<DtoConsulProducto> enuConsulProducto = Enumerable.Empty<DtoConsulProducto>();

        string SQLScript = "SELECT PRD.IdProducto,\r\n\t   PRD.Descrip as Nombre,\r\n\t   ISNULL(PRD.SKU,'--') AS SKU,\r\n\t   ISNULL(PRD.CB,'--') AS CB,\r\n\t   PRO.Proveedor,\r\n\t   PRD.IVA,\r\n\t   PRD.PVenta,\r\n\t   IIF(PRD.IsActivo = 1, 'Activo', 'InActivo') AS Estatus,\r\n\t   FORMAT(PRD.FecAlta,'dd/MM/yyyy HH:mm') AS FecAlta\r\nFROM [dbo].[PRODUCTO] AS PRD\r\n\tINNER JOIN (SELECT IdProveedor,\r\n\t\t\t\t\t   Nombre AS Proveedor\r\n\t\t\t\tFROM PROVEEDOR) AS PRO ON PRD.IdProveedor = PRO.IdProveedor";

        var dpParametros = new { };

        DataTable Dt = await Contexto.Funcion_ScriptDB(PCadena, SQLScript, dpParametros);

        if (Dt.Rows.Count > 0)
        {
            enuConsulProducto = Dt.AsEnumerable().Select(item => new DtoConsulProducto(
                IdProducto: item.Field<int>("IdProducto"),
                Nombre: item.Field<string>("Nombre"),
                SKU: item.Field<string>("SKU"),
                CB: item.Field<string>("CB"),
                Proveedor: item.Field<string>("Proveedor"),
                IVA: item.Field<decimal>("IVA"),
                PVenta: item.Field<decimal>("PVenta"),
                Estatus: item.Field<string>("Estatus"),
                FecAlta: item.Field<string>("FecAlta")
                ));
        }

        return await Task.FromResult(enuConsulProducto.OrderBy(x => x.Nombre));
    }

    public static async Task<IEnumerable<DtoConsulProducto>> ConsultaProductoTexto(string PCadena, string PTexto)
    {
        IEnumerable<DtoConsulProducto> enuConsulProducto = Enumerable.Empty<DtoConsulProducto>();

        string SQLScript = "SELECT PRD.IdProducto,\r\n\t   PRD.Descrip AS Nombre,\r\n\t   ISNULL(PRD.SKU,'--') AS SKU,\r\n\t   ISNULL(PRD.CB,'--') AS CB,\r\n\t   PRO.Proveedor,\r\n\t   PRD.IVA,\r\n\t   PRD.PVenta,\r\n\t   IIF(PRD.IsActivo = 1, 'Activo', 'InActivo') AS Estatus,\r\n\t   FORMAT(PRD.FecAlta,'dd/MM/yyyy HH:mm') AS FecAlta\r\nFROM [dbo].[PRODUCTO] AS PRD\r\n\tINNER JOIN (SELECT IdProveedor,\r\n\t\t\t\t\t   Nombre AS Proveedor\r\n\t\t\t\tFROM PROVEEDOR) AS PRO ON PRD.IdProveedor = PRO.IdProveedor\r\nWHERE PRD.Descrip LIKE '%'+ @P_Descrip + '%'";

        var dpParametros = new
        {
            P_Descrip = PTexto
        };

        DataTable Dt = await Contexto.Funcion_ScriptDB(PCadena, SQLScript, dpParametros);

        if (Dt.Rows.Count > 0)
        {
            enuConsulProducto = Dt.AsEnumerable().Select(item => new DtoConsulProducto(
                IdProducto: item.Field<int>("IdProducto"),
                Nombre: item.Field<string>("Nombre"),
                SKU: item.Field<string>("SKU"),
                CB: item.Field<string>("CB"),
                Proveedor: item.Field<string>("Proveedor"),
                IVA: item.Field<decimal>("IVA"),
                PVenta: item.Field<decimal>("PVenta"),
                Estatus: item.Field<string>("Estatus"),
                FecAlta: item.Field<string>("FecAlta")
                ));
        }

        return await Task.FromResult(enuConsulProducto.OrderBy(x => x.Nombre));
    }

    public static async Task<IEnumerable<string>> ActualizarProducto(string PCadena, DtoAltaProducto PAltaProducto)
    {
        List<string> lstDatos = [];

        string SQLScript = "UPDATE PRODUCTO SET Descrip = @P_Descrip,\r\n\t\t\t\t\tSKU = @P_SKU,\r\n\t\t\t\t\tCB = @P_CB,\r\n\t\t\t\t\tIdProveedor = @P_IdProveedor,\r\n\t\t\t\t\tIVA = @P_IVA,\r\n\t\t\t\t\tPVenta = @P_PVenta,\r\n\t\t\t\t\tIsActivo = @P_IsActivo\r\nWHERE IdProducto = @P_IdProducto";

        try
        {
            var dpParametros = new
            {
                P_Descrip = PAltaProducto.Descrip,
                P_SKU = PAltaProducto.SKU,
                P_CB = PAltaProducto.CB,
                P_IdProveedor = PAltaProducto.IdProveedor,
                P_IVA= PAltaProducto.IVA,
                P_PVenta = PAltaProducto.PVenta,
                P_IsActivo = PAltaProducto.IsActivo,
                P_IdProducto = PAltaProducto.IdProducto
            };

            Contexto.Procedimiento_ScriptDB(PCadena, SQLScript, dpParametros);

            lstDatos.Add("00");
            lstDatos.Add("El producto se modifico con éxito");
        }

        catch (Exception ex)
        {

            lstDatos.Add("14");
            lstDatos.Add(ex.Message);

        }

        return await Task.FromResult(lstDatos.AsEnumerable());
    }


}
