using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ustaVideosA.Models{
    public class Actor_Movies{
        [Key]
        public int Id { get; set; }
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
        public int ActorId { get; set; }
        [ForeignKey("ActorId")]
        public Actor Actor { get; set; }
        

    }
}