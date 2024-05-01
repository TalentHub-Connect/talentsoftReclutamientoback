using System;
using System.Collections.Generic;

namespace talentsoftReclutamiento.Models;

public partial class Offer
{
    public int Id { get; set; }

    public string TittleOffer { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Experience { get; set; }

    public DateOnly PublishDate { get; set; } = new DateOnly();

    public string Requeriments { get; set; } = null!;

    public bool Status { get; set; }

    public int Candidate_id { get; set; }

}
