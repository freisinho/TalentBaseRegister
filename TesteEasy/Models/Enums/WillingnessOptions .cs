using System.ComponentModel.DataAnnotations;

namespace TesteEasy.Models.Enums
{
    public enum WillingnessOptions
    {
        [Display(Name = "Up to 4 hours per day")]
        UpToFour = 1,

        [Display(Name = "4 to 6 hours per day")]
        FourToSix = 2,

        [Display(Name = "6 to 8 hours per day")]
        SixToEight = 3,

        [Display(Name = "Up to 8 hours a day (are you sure?)")]
        UpToEight = 4,
        [Display(Name = "Only weekends")] OnlyWeekends = 5
    }
}