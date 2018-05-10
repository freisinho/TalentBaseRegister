using System.ComponentModel.DataAnnotations;

namespace TesteEasy.Models.Enums
{
    public enum TimeToWorkOptions
    {
        [Display(Name = "Morning (from 08:00 to 12:00)")]
        Morning = 1,

        [Display(Name = "Afternoon (from 1:00 p.m. to 6:00 p.m.)")]
        Afternoon = 2,

        [Display(Name = "Night (7:00 p.m. to 10:00 p.m.)")]
        Night = 3,

        [Display(Name = "Dawn (from 10 p.m. onwards)")]
        Dawn = 4,

        [Display(Name = "Business (from 08:00 a.m. to 06:00 p.m.)")]
        Business = 5
    }
}