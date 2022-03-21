using System;
using System.Collections.Generic;

#nullable disable

namespace SGCDI.model
{
    public partial class Exemplaire
    {
        public int IdExemplaire { get; set; }
        public int CodeBarreExemplaire { get; set; }
        public int IdOuvrage { get; set; }
        public bool? Reserve { get; set; }
        public int IdDocumentaliste { get; set; }

        public virtual Documentaliste IdDocumentalisteNavigation { get; set; }
        public virtual Ouvrage IdOuvrageNavigation { get; set; }
        public virtual EmprunteursExemplaire EmprunteursExemplaire { get; set; }
    }
}
