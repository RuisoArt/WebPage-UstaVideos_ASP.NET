using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ustaVideosB.Data.Enum;

namespace ustaVideosB.Models{
    public class Movie{
        [Key]
        public int Id { get; set; }
        public string ImageUR { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }
        /************************************Relationships*************************************/
        /*Relations with others tables*/
        public List<Actor_Movies> Actor_Movies { get; set; } // one Movie many ids

        public int CinemaId { get; set; } // many Cinema have one Movie
        [ForeignKey ("CinemaId")]
        public Cinema Cinema { get; set; }

        public int DirectorId { get; set; } //many Director have one Movie
        [ForeignKey("DirectorId")]
        public Director Director { get; set; }
    }
}