//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Quizz_Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class question
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public question()
        {
            this.proposition_reponse = new HashSet<proposition_reponse>();
            this.reponse_candidat = new HashSet<reponse_candidat>();
            this.quizz = new HashSet<quizz>();
        }
    
        public int pk_question { get; set; }
        public string nv_complexite { get; set; }
        public string enonce { get; set; }
        public Nullable<sbyte> a_repondu { get; set; }
        public int fk_theme { get; set; }
        public int fk_complexite { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<proposition_reponse> proposition_reponse { get; set; }
        public virtual taux_complexite taux_complexite { get; set; }
        public virtual theme theme { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reponse_candidat> reponse_candidat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<quizz> quizz { get; set; }
    }
}
