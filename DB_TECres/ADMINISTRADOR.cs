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
    
    public partial class ADMINISTRADOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ADMINISTRADOR()
        {
            this.ANUNCIO = new HashSet<ANUNCIO>();
            this.VENDEDOR = new HashSet<VENDEDOR>();
        }
    
        public int ID { get; set; }
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public System.DateTime Fecha_Nacimiento { get; set; }
        public System.DateTime Fecha_Ingreso_TECres { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<ANUNCIO> ANUNCIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<VENDEDOR> VENDEDOR { get; set; }
    }
}
