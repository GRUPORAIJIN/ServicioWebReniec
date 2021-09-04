using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebServisReniec
{
    /// <summary>
    /// Descripción breve de WSReniec
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WSReniec : System.Web.Services.WebService
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
        private static SqlConnection conectar = new SqlConnection(cadena);
        [WebMethod(Description ="Consultar DNI del usuario")]
        public DataTable BuscarDNI(string dni)
        {
            SqlCommand comando = new SqlCommand("spBuscarDNI", conectar);
            comando.CommandType = CommandType.StoredProcedure;
            //enviar el dni al procedimeinto almacenado
            comando.Parameters.AddWithValue("@dni", dni);
            //traer los datos del procedimiento almacenado
            SqlDataAdapter adapter = new SqlDataAdapter(comando);
            DataTable data = new DataTable("tabla");
            //volcado de datos del gestor de SQL al WEB SERVIS
            adapter.Fill(data);
            //devolver los valores la web sservis
            return data;
        }
    }
}
