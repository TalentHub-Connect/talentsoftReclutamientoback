using System;
using System.Collections.Generic;

namespace talentsoftReclutamiento.Models;

public partial class Curriculum
{
    public int Id { get; set; }

    public string? Address { get; set; }

    public string? Personalobjetive { get; set; }

    public int? Workexperience { get; set; }

    public string? Educationalhistory { get; set; }

    public string? Language { get; set; }

    public string? Certification { get; set; }

    public string? Personalreference { get; set; }

    public string? University { get; set; }

    public string? Career { get; set; }
}
