using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectofinalwebII.Modelos
{
    public class MVentas
    {
        public String fecha { get; set; }
        public Double total { get; set; }
        public String id { get; set; }
        public String descripccion { get; set; }

        public List<MDetalles> Detalles = new List<MDetalles>();

    }
}