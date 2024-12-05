using System.ComponentModel.DataAnnotations;

namespace mswebtechAssignment1.Models
{
    public class BPMeasurement
    {
        public int Id { get; set; }

        [Required]
        [Range(20, 400, ErrorMessage = "Systolic must be between 20 and 400.")]
        public int Systolic { get; set; }

        [Required]
        [Range(10, 300, ErrorMessage = "Diastolic must be between 10 and 300.")]
        public int Diastolic { get; set; }

        [Required]
        public DateTime DateTaken { get; set; }

        [Required]
        public string Position { get; set; } 

        public string Category
        {
            get
            {
                return GetCategory();
            }
        }

        private string GetCategory()
        {
            if (Systolic >= 180 || Diastolic >= 120)
                return "Hypertensive Crisis";
            if (Systolic >= 140 || Diastolic >= 90)
                return "Hypertension Stage 2";
            if (Systolic >= 130 || Diastolic >= 80)
                return "Hypertension Stage 1";
            if (Systolic >= 120 && Diastolic < 80)
                return "Elevated";
            return "Normal";
        }
    }
}
