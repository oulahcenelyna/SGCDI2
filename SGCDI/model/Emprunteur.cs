using System;
using System.Collections.Generic;

#nullable disable

namespace SGCDI.model
{
    public partial class Emprunteur
    {
        public Emprunteur()
        {
            EmprunteursExemplaires = new HashSet<EmprunteursExemplaire>();
        }

        public int IdEmprunteur { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string AdresseMail { get; set; }
        public string MotDePasse { get; set; }

        public virtual Elefe Elefe { get; set; }
        public virtual Professeur Professeur { get; set; }
        public virtual ICollection<EmprunteursExemplaire> EmprunteursExemplaires { get; set; }
    }
}
