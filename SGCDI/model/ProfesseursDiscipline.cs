using System;
using System.Collections.Generic;

#nullable disable

namespace SGCDI.model
{
    public partial class ProfesseursDiscipline
    {
        public int IdDiscipline { get; set; }
        public int IdProfesseur { get; set; }

        public virtual Discipline IdDisciplineNavigation { get; set; }
        public virtual Professeur IdProfesseurNavigation { get; set; }
    }
}
