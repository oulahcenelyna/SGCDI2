using System;
using System.Collections.Generic;

#nullable disable

namespace SGCDI.model
{
    public partial class Professeur
    {
        public Professeur()
        {
            ProfesseursDisciplines = new HashSet<ProfesseursDiscipline>();
        }

        public int IdEmprunteur { get; set; }
        public int IdProfesseur { get; set; }

        public virtual Emprunteur IdEmprunteurNavigation { get; set; }
        public virtual ICollection<ProfesseursDiscipline> ProfesseursDisciplines { get; set; }
    }
}
