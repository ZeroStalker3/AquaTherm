//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AquaTherm.Base
{
    using System;
    using System.Collections.Generic;
    
    public partial class Счетчики
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Счетчики()
        {
            this.ПоказанияСчетчиков = new HashSet<ПоказанияСчетчиков>();
        }
    
        public int ID { get; set; }
        public string НомерСчетчика { get; set; }
        public Nullable<int> idType { get; set; }
        public Nullable<System.DateTime> ДатаУстановки { get; set; }
        public string Состояние { get; set; }
        public Nullable<int> idClient { get; set; }
    
        public virtual Клиенты Клиенты { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ПоказанияСчетчиков> ПоказанияСчетчиков { get; set; }
        public virtual ТипыСчетчиков ТипыСчетчиков { get; set; }
    }
}
