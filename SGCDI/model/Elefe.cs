using System;
using System.Collections.Generic;

#nullable disable

namespace SGCDI.model
{
    public partial class Elefe
    {
        public Elefe()
        {
            ClassesEleves = new HashSet<ClassesElefe>();
        }

        public int IdEmprunteur { get; set; }
        public int IdEleve { get; set; }

        public virtual Emprunteur IdEmprunteurNavigation { get; set; }
        public virtual ICollection<ClassesElefe> ClassesEleves { get; set; }
    }
}
