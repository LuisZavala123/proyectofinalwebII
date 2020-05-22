using proyectofinalwebII.DAOS;
using proyectofinalwebII.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace proyectofinalwebII.WS
{
    /// <summary>
    /// Descripción breve de WSVenta
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class WSVenta : System.Web.Services.WebService
    {


        private VentaDAO DAO = new VentaDAO();



        [WebMethod]
        public void Agregar( string Fecha, double Total, String Descripcion, List<MDetalles> detalles)
        {
            DAO.Agregar(new MVentas(Fecha,Total,"",Descripcion));
            foreach (var item in detalles)
            {
                DAO.Agregar_Detalles(new MDetalles("",item.producto,item.Tipo,item.cantidad,item.total));
            }
            
        }

        [WebMethod]
        public List<MVentas> GetAll()
        {
            return DAO.GetAll();
        }

        [WebMethod]
        public List<MDetalles> GetDetalles(String id)
        {
            return DAO.GetDetalles(id);
        }

        [WebMethod]
        public MVentas Getbyid(String id)
        {
            return DAO.Getbyid(id);
        }

        [WebMethod]
        public void Eliminar(string id)
        {
            DAO.Eliminar(id);
        }

        [WebMethod]
        public void EliminarDetalles(string id)
        {
            DAO.EliminarDetalles(id);
        }
    }
}
