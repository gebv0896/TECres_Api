using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TECres_Web.Models
{
    public class spAnunciosClienteModel
    {
        public System.Data.Entity.Core.Objects.ObjectResult<DB_TECres.AnunciosCliente_Result> Anuncios_Cliente { get; set; }
   
    }
}