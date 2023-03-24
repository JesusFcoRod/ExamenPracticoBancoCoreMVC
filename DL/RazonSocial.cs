using System;
using System.Collections.Generic;

namespace DL;

public partial class RazonSocial
{
    public int IdRazonSocial { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Banco> Bancos { get; } = new List<Banco>();
}
