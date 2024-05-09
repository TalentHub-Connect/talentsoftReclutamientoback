using System;
using System.Collections.Generic;

namespace talentsoftReclutamiento.Models;

public partial class Candidate
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public int PhoneNumber { get; set; }

    public string EmploymentExchange { get; set; } = null!;

    public bool Status { get; set; }

    public int CurriculumId { get; set; }

    public int TalentSoftUserId { get; set; }

}
