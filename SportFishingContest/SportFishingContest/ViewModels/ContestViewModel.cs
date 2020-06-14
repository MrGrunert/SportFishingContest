using SportFishingContest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportFishingContest.ViewModels
{
    public class ContestViewModel
    {
        public Guid Id { get; set; }

        public Participant Participant { get; set; } 
        public Fish Fish { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Tävlingsdatum")]
        public DateTime Date { get; set; } = DateTime.Now.Date;

        [Required]
        [MaxLength(512)]
        [Display(Name = "Namn på tävling")]
        public string ContestName { get; set; }

        public List<Participant> Participants { get; set; }
        public List<Fish> Fishes { get; set; }
    }
}
