using System;
using System.Collections.Generic;

#nullable disable

namespace SGCDI.model
{
    public partial class DisciplinesClass
    {
        public int IdDiscipline { get; set; }
        public int IdClasse { get; set; }

        public virtual Classes IdClasseNavigation { get; set; }
        public virtual Discipline IdDisciplineNavigation { get; set; }
    }
}
