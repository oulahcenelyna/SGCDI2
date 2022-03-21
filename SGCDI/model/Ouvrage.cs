using System;
using System.Collections.Generic;

#nullable disable

namespace SGCDI.model
{
    public partial class Ouvrage
    {
        public Ouvrage()
        {
            DisciplinesOuvrages = new HashSet<DisciplinesOuvrage>();
            Exemplaires = new HashSet<Exemplaire>();
        }

        public int IdOuvrage { get; set; }
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public string Resume { get; set; }
        public string Image { get; set; }
        public int IdDocumentaliste { get; set; }

        public virtual Documentaliste IdDocumentalisteNavigation { get; set; }
        public virtual ICollection<DisciplinesOuvrage> DisciplinesOuvrages { get; set; }
        public virtual ICollection<Exemplaire> Exemplaires { get; set; }
    }
}
