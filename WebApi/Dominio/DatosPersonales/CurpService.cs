using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dominio.DatosPersonales
{
    public class CurpService : ICurpService
    {
        private readonly IConfiguration _configuration;

        public CurpService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<string> ValidateCurp(DatosPersonales datosPersonales)
        {
            Dictionary<string, string?> entidades = new();
            var appSettingsSection = _configuration.GetSection("Entidades");
            foreach (var child in appSettingsSection.GetChildren())
            {
                entidades[child.Key] = child.Value;
            }

            List<string> resp = new();
            string curpAux = "";

            var nombres = datosPersonales.Nombre.Valor!.Split(" ");
            var nombre = nombres.First().ToUpper();
            if (nombre.Trim().ToUpper() == "MARIA" || nombre.Trim().ToUpper() == "MARÍA" || nombre.Trim().ToUpper() == "JOSE" || nombre.Trim().ToUpper() == "JOSÉ")
            {
                nombre = nombres.Last().ToUpper();
            }

            var vocalesPrimerApellido = RemoveConsonants(datosPersonales.ApellidoPaterno.Valor!.ToUpper());
            var consonantesPrimerApellido = RemoveVowels(datosPersonales.ApellidoPaterno.Valor.ToUpper());
            var consonantesSegundoApellido = RemoveVowels(datosPersonales.ApellidoMaterno.Valor!.ToUpper());
            var consonantesNombre = RemoveVowels(nombre);

            //Validar
            curpAux += datosPersonales.ApellidoPaterno.Valor![0].ToString() +
                (vocalesPrimerApellido[0] == datosPersonales.ApellidoPaterno.Valor![0] ? vocalesPrimerApellido[1].ToString() : vocalesPrimerApellido[0].ToString()) +
                datosPersonales.ApellidoMaterno.Valor![0].ToString() +
                nombre[0].ToString() +
                datosPersonales.FechaNacimiento.ToString("yy/MM/dd").Replace("/", "") +
                (datosPersonales.Sexo == Sexo.Masculino ? "H" : "M") +
                entidades[datosPersonales.EntidadFederativa.Valor!.ToUpper()] +
                (consonantesPrimerApellido[0] == datosPersonales.ApellidoPaterno.Valor![0] ? consonantesPrimerApellido[1].ToString() : consonantesPrimerApellido[0].ToString()) +
                (consonantesSegundoApellido[0] == datosPersonales.ApellidoMaterno.Valor![0] ? consonantesSegundoApellido[1].ToString() : consonantesSegundoApellido[0].ToString()) +
                (consonantesNombre[0] == nombre[0] ? consonantesNombre[1].ToString() : consonantesNombre[0].ToString());

            if (curpAux[0] != datosPersonales.Curp.Valor![0] || curpAux[1] != datosPersonales.Curp.Valor![1] || curpAux[13] != datosPersonales.Curp.Valor![13])
                resp.Add("Error en el apellido paterno");
            if (curpAux[2] != datosPersonales.Curp.Valor![2] || curpAux[14] != datosPersonales.Curp.Valor![14])
                resp.Add("Error en el apellido materno");
            if (curpAux[3] != datosPersonales.Curp.Valor![3] || curpAux[15] != datosPersonales.Curp.Valor![15])
                resp.Add("Error en el nombre");
            if (curpAux.Substring(4, 6) != datosPersonales.Curp.Valor!.Substring(4, 6))
                resp.Add("Error en la fecha de nacimiento");
            if (curpAux[10] != datosPersonales.Curp.Valor![10])
                resp.Add("Error en el sexo");
            if (curpAux.Substring(11, 2) != datosPersonales.Curp.Valor!.Substring(11, 2))
                resp.Add("Error en la entidad federativa");

            return resp;
        }

        private string RemoveConsonants(string input)
        {
            char[] consonants = "bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ".ToCharArray();
            return new string(input.Where(c => !consonants.Contains(c)).ToArray());
        }

        private string RemoveVowels(string input)
        {
            char[] consonants = "aeiouAEIOU".ToCharArray();
            return new string(input.Where(c => !consonants.Contains(c)).ToArray());
        }

    }
}
