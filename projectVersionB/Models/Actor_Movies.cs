using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ustaVideosB.Models{
    public class Actor_Movies{
        [Key]
        public int Id { get; set; }
        /************************************Relationships*************************************/
        public int MovieId { get; set; } //Many IDS have one Movie
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        public int ActorId { get; set; } // Many IDS have one Actor
        [ForeignKey("ActorId")]
        public Actor Actor { get; set; }
        

    }
}