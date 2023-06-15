using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ustaVideosA.Data.Enum;

namespace ustaVideosA.Models{
    public class Movie{
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUR { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }

        /*Relations with others tables*/
        public List<Actor_Movies> Actor_Movies { get; set; }

        public int CinemaId { get; set; }
        [ForeignKey ("CinemaId")]
        public Cinema Cinema { get; set; }

        public int DirectorId { get; set; }
        [ForeignKey("DirectorId")]
        public Director Director { get; set; }
    }
}