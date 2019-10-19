using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TECres_Web.Models
{
    public class spMensajesClienteModel
    {
        public System.Data.Entity.Core.Objects.ObjectResult<DB_TECres.MensajesCliente_Result> Mensajes_Cliente { get; set; }

    }
}