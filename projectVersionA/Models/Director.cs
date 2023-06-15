using System.ComponentModel.DataAnnotations;

namespace ustaVideosA.Models{
    public class Director{

        [Key]
        public int Id { get; set; }
        public string ProfilePictureURL { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }

        /*Relations with other Tables*/
        public List<Movie> Movies { get; set; }
    }
}