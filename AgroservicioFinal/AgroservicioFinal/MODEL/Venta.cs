//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AgroservicioFinal.MODEL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Venta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Venta()
        {
            this.DetalleVenta = new HashSet<DetalleVenta>();
        }
    
        public int IdVenta { get; set; }
        public Nullable<int> IdDocumento { get; set; }
        public Nullable<int> IdCliente { get; set; }
        public Nullable<int> IdTrabajador { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<double> ValorVenta { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
        public virtual Documento Documento { get; set; }
        public virtual Trabajador Trabajador { get; set; }
    }
}
