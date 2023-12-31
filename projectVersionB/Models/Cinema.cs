using System.ComponentModel.DataAnnotations;

namespace ustaVideosB.Models{
    public class Cinema{
        [Key]
        public int Id { get; set; }
        public string logo { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        /************************************Relationships*************************************/
        public List<Movie> Movies { get; set; } // one Cinema have many Movies
    }
}