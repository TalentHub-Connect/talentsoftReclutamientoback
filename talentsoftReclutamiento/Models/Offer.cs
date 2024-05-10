using System;
using System.Collections.Generic;

namespace talentsoftReclutamiento.Models;

public partial class Offer
{
    public int Id { get; set; }

    public string? Tittleoffer { get; set; }

    public string? Description { get; set; }

    public int? Experience { get; set; }

    public string? Publishdate { get; set; }

    public string? Requeriments { get; set; }

    public string? Status { get; set; }
}
