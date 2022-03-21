using System;
using System.Collections.Generic;

#nullable disable

namespace SGCDI.model
{
    public partial class Documentaliste
    {
        public Documentaliste()
        {
            Disciplines = new HashSet<Discipline>();
            Exemplaires = new HashSet<Exemplaire>();
            Ouvrages = new HashSet<Ouvrage>();
        }

        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string AdresseMail { get; set; }
        public string MotDePasse { get; set; }
        public int IdDocumentaliste { get; set; }

        public virtual ICollection<Discipline> Disciplines { get; set; }
        public virtual ICollection<Exemplaire> Exemplaires { get; set; }
        public virtual ICollection<Ouvrage> Ouvrages { get; set; }
    }
}
