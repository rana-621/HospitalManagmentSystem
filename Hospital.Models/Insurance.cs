﻿namespace Hospital.Models;

public class Insurance
{
    public int Id { get; set; }
    public string PolicyNumber { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public ICollection<Bill> Bills { get; set; }
}
