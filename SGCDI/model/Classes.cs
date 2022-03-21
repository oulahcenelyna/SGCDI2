using System;
using System.Collections.Generic;

#nullable disable

namespace SGCDI.model
{
    public partial class Classes
    {
        public Classes()
        {
            ClassesEleves = new HashSet<ClassesElefe>();
            DisciplinesClasses = new HashSet<DisciplinesClass>();
        }

        public int IdClasse { get; set; }
        public string CategorieClasse { get; set; }

        public virtual ICollection<ClassesElefe> ClassesEleves { get; set; }
        public virtual ICollection<DisciplinesClass> DisciplinesClasses { get; set; }
    }
}
