using ustaVideosA.Models;

namespace ustaVideosA.Data{
    public class AppDbInitializer{
        public void Seed(IApplicationBuilder applicationBuilder){
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()){
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                // Cinema
                if(!context.Cinema.Any()){
                    context.Cinema.AddRange(new List<Cinema>(){
                        new Cinema(){
                            Name = "Universal Pictures, Nintendo, Illumination Entertainment",
                            logo = "http://localhost/images/Nintendo-Logo.png",
                            Description = "Nintendo Company, Ltd. (任天堂株式会社 Nintendō Kabushiki-gaisha?) es una empresa de entretenimiento dedicada a la investigación, desarrollo y distribución de software y hardware de videojuegos, y juegos de cartas, con sede en Kioto, Japón.3​ Su origen se remonta a 1889, cuando comenzó a operar como Nintendo Koppai tras ser fundada por el artesano Fusajirō Yamauchi4​ con el objetivo de producir y comercializar naipes hanafuda.5​ Tras incursionar en varias líneas de negocio durante la década de 1960 y adquirir una personalidad jurídica de empresa de capital abierto bajo la denominación actual, en 1977 distribuyó su primera videoconsola en Japón, la Color TV Game 15.6"
                        },
                        new Cinema(){
                            Name = "Bla Bla Bla",
                            logo = "http://",
                            Description = "Bla Bla Bla"
                        },
                        new Cinema(){
                            Name = "Bla Bla Bla",
                            logo = "http://",
                            Description = "Bla Bla Bla"
                        }
                    });
                    context.SaveChanges();
                }
                //Actor
                if(!context.Actor.Any()){
                    context.Actor.AddRange(new List<Actor>(){
                        new Actor(){
                            ProfilePictureURL = "http://localhost/images/jack.png",
                            FullName = "Jack Black",
                            Bio = "Jack Black nació el 28 de agosto de 1969 en Santa Mónica, California, EE.UU.. Es un actor y productor, conocido por Escuela de rock (2003), Alta fidelidad (2000) y Super Nacho (2006). Está casado con Tanya Haden desde el 14 de marzo de 2006. Tienen dos niños."
                        },
                        new Actor(){
                            ProfilePictureURL = "http://",
                            FullName = "bla bla bla",
                            Bio = "bla bla bla"
                        },
                        new Actor(){
                            ProfilePictureURL = "http://",
                            FullName = "bla bla bla",
                            Bio = "bla bla bla"
                        }
                    });
                    context.SaveChanges();
                }
                //Director
                if(!context.Director.Any()){
                    context.Director.AddRange(new List<Director>(){
                        new Director(){
                            ProfilePictureURL = "http://localhost/images/aaron.jpg",
                            FullName = "Aaron Horvath",
                            Bio = "Aaron Horvath nació el 19 de agosto de 1980 en California, Estados Unidos. Es un director y productor, conocido por Super Mario Bros.: La película (2023), Teen Titans Go! La película (2018) y Teen Titans Go! (2013).",
                        },
                        new Director(){
                            ProfilePictureURL = "http://localhost/images/mariobross.png",
                            FullName = "blahblahblahblahbl",
                            Bio = "blahblahblahblahblahblahblahblah",
                        },
                        new Director(){
                            ProfilePictureURL = "http://localhost/images/mariobross.png",
                            FullName = "blahblahblahblahbl",
                            Bio = "blahblahblahblahblahblahblahblah",
                        }
                    });
                    context.SaveChanges();
                }
                //Movies
                if(!context.Movie.Any()){
                    context.Movie.AddRange(new List<Movie>(){
                        new Movie(){
                            Name = "Super Mario Bros. Movie",
                            Description = "Un fontanero llamado Mario viaja a través de un laberinto subterráneo con su hermano, Luigi, tratando de salvar a una princesa capturada.",
                            Price = 146361865,
                            ImageUR = "http://localhost/images/marioBrosMovie.png",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            DirectorId = 1,
                            MovieCategory = Enum.MovieCategory.Action,
                        },
                        new Movie(){
                            Name = "white",
                            Description = "bablabla",
                            Price = 234.234,
                            ImageUR = "bla bla bla bla bla bla bla bla bla",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            DirectorId = 1,
                            MovieCategory = Enum.MovieCategory.Action,
                        },
                        new Movie(){
                            Name = "mix",
                            Description = "bablabla",
                            Price = 234.234,
                            ImageUR = "bla bla bla bla bla bla bla bla bla",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            DirectorId = 1,
                            MovieCategory = Enum.MovieCategory.Action,
                        }
                    });
                    context.SaveChanges();
                }
                //Actor_Movies
                if(!context.Actor_Movies.Any()){
                    context.Actor_Movies.AddRange(new List<Actor_Movies>(){
                        new Actor_Movies(){
                            MovieId = 1 ,
                            ActorId = 1
                        },
                        new Actor_Movies(){
                            MovieId = 2 ,
                            ActorId = 2
                        },
                        new Actor_Movies(){
                            MovieId = 3 ,
                            ActorId = 3
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}