using System.ComponentModel.DataAnnotations;

namespace ustaVideosB.Models{
    public class Actor{
        [Key]
        public int Id { get; set; }

        [Display(Name="Image")]
        [Required]
        public string ProfilePictureURL { get; set; }

        [Display(Name="Actor")]
        [Required]
        [StringLength(40, ErrorMessage = "Full Name lenght can't more than 40 characters.")]
        public string FullName { get; set; }

        [Display(Name="Biography")]
        [Required]
        public string Bio { get; set; }
        /************************************Relationships*************************************/
        public List<Actor_Movies> Actor_Movies { get; set; } // one Actor have many ids
    }
}