using System;
using System.Collections.Generic;

#nullable disable

namespace SGCDI.model
{
    public partial class DisciplinesOuvrage
    {
        public int IdDiscipline { get; set; }
        public int IdOuvrage { get; set; }

        public virtual Discipline IdDisciplineNavigation { get; set; }
        public virtual Ouvrage IdOuvrageNavigation { get; set; }
    }
}
