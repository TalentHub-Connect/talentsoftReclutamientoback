using System;
using System.Collections.Generic;

namespace talentsoftReclutamiento.Models;

public partial class Service
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int RolId { get; set; }

}
