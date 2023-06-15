using System.ComponentModel.DataAnnotations;

namespace ustaVideosA.Models{
    public class Cinema{
        [Key]
        public int Id { get; set; }
        public string logo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        /*Relationships with others tables*/
        public List<Movie> Movies { get; set; }
    }
}