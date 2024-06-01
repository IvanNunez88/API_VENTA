using DAL;
using MODELS.AUTENTICACION.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AUTENTICACION
{
    public class BL_AUTENTICACION
    {

        public static async Task<IEnumerable<string>> ValidaInfoComponente(string PCadena, DtoAutenticComponente PAutenticComponente)
        {
            List<string> lstValidaciones = [];

            //VALIDACIONES DE FLUENT

            if (!await ValidaInfoDB(PCadena, PAutenticComponente))
            {
                lstValidaciones.Add("Los datos de autenticación, no son correctos");
            }

            return await Task.FromResult(lstValidaciones);
        }

        private static async Task<bool> ValidaInfoDB(string PCadena, DtoAutenticComponente PAutenticComponente)
        {
            bool Validacion = true;
            string SQLScript = "SELECT 1 AS resultado\r\nFROM COMPONENTE\r\nWHERE Usuario = @P_Usuario AND\r\n\t  Contra = @P_Contra AND\r\n\t  [GUID] = @P_GUID";

            var dpParametros = new
            {
                @P_Usuario = PAutenticComponente.Usuario,
                @P_Contra = PAutenticComponente.Contraseña,
                @P_GUID = PAutenticComponente.Guid
            };

            DataTable Dt = await Contexto.Funcion_ScriptDB(PCadena, SQLScript, dpParametros);

            if (Dt.Rows.Count <= 0)
            {
                Validacion = false;
            }

            return await Task.FromResult(Validacion);
        }


    }
}
