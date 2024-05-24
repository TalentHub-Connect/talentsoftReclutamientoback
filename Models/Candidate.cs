using System;
using System.Collections.Generic;

namespace talentsoftReclutamiento.Models;

public partial class Candidate
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int OfferId { get; set; }

    public string? Surname { get; set; }

    public int? Phonenumber { get; set; }

    public int? CvId { get; set; }

    public int Candidatestatusid { get; set; }
}
