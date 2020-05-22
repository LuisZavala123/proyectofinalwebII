using proyectofinalwebII.DAOS;
using proyectofinalwebII.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyectofinalwebII
{
    public partial class ventas : System.Web.UI.Page
    {
        private static List<MDetalles> detalle ;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                cargarproductos();
                detalle = new List<MDetalles>();
            }
        }
        protected void cargarproductos()
        {

            CboxProducto.DataSource = new ArticuloDAO().GetNombres();
            CboxProducto.DataBind();
        }

        protected void tabladetalles()
        {

            grvLista.DataSource = detalle;
            grvLista.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            
           
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {

            

        }

        protected void grvLista_RowCommand(object sender, GridViewCommandEventArgs e)
        {
             if (e.CommandName == "Eliminar")
            {
                Response.Write("<script>$('#mdlConfirmar').modal('show');</script>");
                for (int con =0;con<detalle.Count;con++)
                {
                    if (detalle[con].producto.Equals(grvLista.Rows[int.Parse(e.CommandArgument.ToString())].Cells[0].Text))
                    {
                        lbltotal.Text = (Double.Parse(lbltotal.Text) - detalle[con].total) + "";
                        detalle.Remove(detalle[con]);
                        tabladetalles();
                    }
                }
            }
        }
    }
}