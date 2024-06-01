using BLL.PROVEEDOR.Validator;
using DAL;
using MODELS.PROVEEDOR.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BLL.PROVEEDOR;

public class BL_PROVEEDOR
{

    public static async Task<IEnumerable<string>> ValidarProveedor(DtoAltaProveedor PAltaProveedor)
    {
        List<string> lstValidacion = [];

        ValidacionAltaProveedor ValidationRules = new();
        var Resultado = ValidationRules.Validate(PAltaProveedor);

        if (!Resultado.IsValid)
        {
            lstValidacion = Resultado.Errors.Select(x => x.ErrorMessage).ToList();
        }

        return await Task.FromResult(lstValidacion.AsEnumerable());

    }

    public static async Task<IEnumerable<string>> GuardarProveedor(string PCadena, DtoAltaProveedor PAltaProveedor)
    {
        List<string> lstDatos = [];

        string SQLScript = "INSERT INTO PROVEEDOR (Nombre,RFC,Contacto) VALUES (@P_Nombre,@P_RFC,@P_Contacto)";

        try
        {
            var dpParametros = new
            {
                P_Nombre = PAltaProveedor.Nombre,
                P_RFC = PAltaProveedor.RFC,
                P_Contacto = PAltaProveedor.Contacto
            };

            Contexto.Procedimiento_ScriptDB(PCadena, SQLScript, dpParametros);

            lstDatos.Add("00");
            lstDatos.Add("El proveedor se guardo con éxito");

        }

        catch (Exception ex)
        {

            lstDatos.Add("14");
            lstDatos.Add(ex.Message);

        }

        return await Task.FromResult(lstDatos.AsEnumerable());
    }

    public static async Task<IEnumerable<DtoConsuProveedor>> ConsultaProveedor(string PCadena)
    {
        IEnumerable<DtoConsuProveedor> enuConsulProveedor = Enumerable.Empty<DtoConsuProveedor>();

        string SQLScript = "SELECT IdProveedor,\r\n\t   Nombre,\r\n\t   RFC,\r\n\t   Contacto,\r\n\t   IIF(IsActivo = 1,'Activo', 'InActivo') AS Estatus,\r\n\t   FORMAT(FecAlta,'dd/MM/yyyy HH:mm') AS FecAlta\r\nFROM PROVEEDOR";

        var dpParametros = new { };

        DataTable Dt = await Contexto.Funcion_ScriptDB(PCadena, SQLScript, dpParametros);

        if (Dt.Rows.Count > 0)
        {
            enuConsulProveedor = Dt.AsEnumerable().Select(item => new DtoConsuProveedor(
                IdProveedor: item.Field<int>("IdProveedor"),
                Nombre: item.Field<string>("Nombre"),
                RFC: item.Field<string>("RFC"),
                Contacto: item.Field<string>("Contacto"),
                Estatus: item.Field<string>("Estatus"),
                FecAlta: item.Field<string>("FecAlta")
                ));
        }

        return await Task.FromResult(enuConsulProveedor);
    }

    public static async Task<IEnumerable<DtoConsulProveedorNombre>> ConsultaProveedorTexto(string PCadena, string PTexto)
    {
        IEnumerable<DtoConsulProveedorNombre> enuConsulProveedor = Enumerable.Empty<DtoConsulProveedorNombre>();

        string SQLScript = "SELECT IdProveedor,\r\n\t   Nombre,\r\n\t   RFC,\r\n\t   Contacto,\r\n\t   IIF(IsActivo = 1,'Activo', 'InActivo') AS Estatus,\r\n\t   FORMAT(FecAlta,'dd/MM/yyyy HH:mm') AS FecAlta\r\nFROM PROVEEDOR\r\nWHERE Nombre LIKE '%'+ @P_Texto +'%'";

        var dpParametros = new
        {
            P_Texto = PTexto
        };

        DataTable Dt = await Contexto.Funcion_ScriptDB(PCadena, SQLScript, dpParametros);

        if (Dt.Rows.Count > 0)
        {
            enuConsulProveedor = Dt.AsEnumerable().Select(item => new DtoConsulProveedorNombre()
            {
                IdProveedor = item.Field<int>("IdProveedor"),
                Nombre = item.Field<string>("Nombre"),
                RFC = item.Field<string>("RFC"),
                Contacto = item.Field<string>("Contacto"),
                Estatus = item.Field<string>("Estatus"),
                FecAlta = item.Field<string>("FecAlta")
            });
        }

        return await Task.FromResult(enuConsulProveedor);
    }

    public static async Task<IEnumerable<string>> ActualizarProveedor(string PCadena, DtoAltaProveedor PAltaProveedor)
    {
        List<string> lstDatos = [];

        string SQLScript = "UPDATE PROVEEDOR SET Nombre = @P_Nombre,\r\n\t\t\t\t\t RFC = @P_RFC,\r\n\t\t\t\t\t Contacto = @P_Contacto,\r\n\t\t\t\t\t IsActivo = @P_IsActivo\r\nWHERE IdProveedor = @P_IdProveedor";

        try
        {
            var dpParametros = new
            {
                P_Nombre = PAltaProveedor.Nombre,
                P_RFC = PAltaProveedor.RFC,
                P_Contacto = PAltaProveedor.Contacto,
                P_IsActivo = PAltaProveedor.IsActivo,
                P_IdProveedor = PAltaProveedor.IdProveedor
            };

            Contexto.Procedimiento_ScriptDB(PCadena, SQLScript, dpParametros);

            lstDatos.Add("00");
            lstDatos.Add("El proveedor se modifico con éxito");
        }

        catch (Exception ex)
        {

            lstDatos.Add("14");
            lstDatos.Add(ex.Message);

        }

        return await Task.FromResult(lstDatos.AsEnumerable());
    }

}