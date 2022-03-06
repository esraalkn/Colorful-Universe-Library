//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Colorful_Universe_Library.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TBLUYELER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLUYELER()
        {
            this.TBLCEZA = new HashSet<TBLCEZA>();
            this.TBLHAREKET = new HashSet<TBLHAREKET>();
        }
    
        public int ID { get; set; }

        [Required(ErrorMessage ="You must enter user's name!")]
        public string AD { get; set; }

        [Required(ErrorMessage = "You must enter user's Surname!")]
        public string SOYAD { get; set; }

        [Required(ErrorMessage = "You must enter user's mail!")]
        public string MAIL { get; set; }

        [Required(ErrorMessage = "You must enter user's nickname!")]
        public string KULLANICIADI { get; set; }

        [Required(ErrorMessage = "You must enter user's password!")]
        [StringLength(6,ErrorMessage ="You can enter up to 6 character!")]
        public string SIFRE { get; set; }
        public string FOTOGRAF { get; set; }

        [Required(ErrorMessage = "You must enter user's telephone number!")]
        public string TELEFON { get; set; }
        public string OKUL { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLCEZA> TBLCEZA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLHAREKET> TBLHAREKET { get; set; }
    }
}
