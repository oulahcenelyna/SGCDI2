using System;
using System.Collections.Generic;

#nullable disable

namespace SGCDI.model
{
    public partial class Discipline
    {
        public Discipline()
        {
            DisciplinesClasses = new HashSet<DisciplinesClass>();
            DisciplinesOuvrages = new HashSet<DisciplinesOuvrage>();
            ProfesseursDisciplines = new HashSet<ProfesseursDiscipline>();
        }

        public int IdDiscipline { get; set; }
        public string Libelle { get; set; }
        public string ImageCat { get; set; }
        public int IdDocumentaliste { get; set; }

        public virtual Documentaliste IdDocumentalisteNavigation { get; set; }
        public virtual ICollection<DisciplinesClass> DisciplinesClasses { get; set; }
        public virtual ICollection<DisciplinesOuvrage> DisciplinesOuvrages { get; set; }
        public virtual ICollection<ProfesseursDiscipline> ProfesseursDisciplines { get; set; }
    }
}
