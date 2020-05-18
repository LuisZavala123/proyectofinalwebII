﻿using proyectofinalwebII.DAOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyectofinalwebII
{
    public partial class Reportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                actualizar();
            }
        }
        protected void actualizar()
        {
            var nu = new VentaDAO();
            grvLista.AutoGenerateColumns = false;
            List<MReporte> reportes = new List<MReporte>();
            reportes.Add(new MReporte("Hamburgesa",0,0));
            reportes.Add(new MReporte("Pizza", 0, 0));
            reportes.Add(new MReporte("Bebida", 0, 0));

            foreach (var item in nu.GetAll())
            {
                foreach (var item2 in item.Detalles)
                {


                    foreach (var item3 in reportes)
                    {
                        if (item3.Tipo.Equals(item2.Tipo))
                        {
                            item3.Cantidad += item2.cantidad;
                            item3.Total += item2.total;
                        }
                    }
                }
            }

            grvLista.DataSource = reportes;
            grvLista.DataBind();
        }
    }
}