using System;
using System.Collections.Generic;

#nullable disable

namespace SGCDI.model
{
    public partial class EmprunteursExemplaire
    {
        public int IdEmprunteur { get; set; }
        public int IdExemplaire { get; set; }
        public DateTime DebutEmprunt { get; set; }
        public DateTime FinEmprunt { get; set; }

        public virtual Emprunteur IdEmprunteurNavigation { get; set; }
        public virtual Exemplaire IdExemplaireNavigation { get; set; }
    }
}
