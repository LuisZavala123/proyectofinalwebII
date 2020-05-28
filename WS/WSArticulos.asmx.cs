using proyectofinalwebII.DAOS;
using proyectofinalwebII.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Text.RegularExpressions;

namespace proyectofinalwebII.WS
{
    /// <summary>
    /// Descripción breve de WSArticulos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class WSArticulos : System.Web.Services.WebService
    {

        private ArticuloDAO DAO = new ArticuloDAO();


        [WebMethod(EnableSession = true)]
        public void Agregar(string nom, String costo, String Descripcion, String Tipo)
        {
            //Aqui
            String ExpresionNom = @"[A-ZÁÉÍÓÚ][a-z]+";
            String ExpresionCos = @"[0-9]+[\.][0-9][0-9]?";
            if (Regex.IsMatch(nom,ExpresionNom) && Regex.IsMatch(costo, ExpresionCos))
            {
                DAO.Agregar(new MArticulos(Tipo,nom,Double.Parse(costo),"",Descripcion)); 
            }
            

        }

        [WebMethod]
        public List<MArticulos> GetAll()
        {

            return DAO.GetAll();
        }


        [WebMethod(EnableSession = true)]
        public MArticulos Getbyid(String id)
        {
            return DAO.Getbyid(id);
        }

        [WebMethod(EnableSession = true)]
        public MArticulos GetbyNombre(String Nombre)
        {
            return DAO.GetbyNombre(Nombre);
        }

        [WebMethod(EnableSession = true)]
        public List<String> GetNombres()
        {
            return DAO.GetNombres();
        }


        [WebMethod(EnableSession = true)]
        public void Eliminar(string id)
        {
            DAO.Eliminar(id);
        }

        
    }
}
