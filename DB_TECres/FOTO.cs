//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DB_TECres
{
    using System;
    using System.Collections.Generic;
    
    public partial class FOTO
    {
        public int ID { get; set; }
        public string Dir_URL { get; set; }
        public int ID_Propiedad { get; set; }
    
        public virtual PROPIEDAD PROPIEDAD { get; set; }
    }
}
