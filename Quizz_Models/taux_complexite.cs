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
    
    public partial class taux_complexite
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public taux_complexite()
        {
            this.question = new HashSet<question>();
            this.quizz = new HashSet<quizz>();
        }
    
        public int pk_complexite { get; set; }
        public string niveau { get; set; }
        public Nullable<int> question_junior { get; set; }
        public Nullable<int> quest_confirme { get; set; }
        public Nullable<int> question_experimente { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<question> question { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<quizz> quizz { get; set; }
    }
}
