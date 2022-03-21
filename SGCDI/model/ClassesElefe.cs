using System;
using System.Collections.Generic;

#nullable disable

namespace SGCDI.model
{
    public partial class ClassesElefe
    {
        public int IdClasse { get; set; }
        public int IdEleve { get; set; }

        public virtual Classes IdClasseNavigation { get; set; }
        public virtual Elefe IdEleveNavigation { get; set; }
    }
}
