using Microsoft.EntityFrameworkCore;
using RazorMoviePage.Models;
using RazorPagesMovie.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (
                var context = new RazorPagesMovieContext(
                    serviceProvider.GetRequiredService<DbContextOptions<RazorPagesMovieContext>>()
                )
            )
            {
                if (context == null || context.Movie == null)
                {
                    throw new ArgumentException("Null RazorPagesMovie context");
                }

                // Para mirar cualquier película
                if (context.Movie.Any())
                {
                    // La db muestra todo lo que contiene la clase
                    return;
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Price = 7.99M,
                        Rating = "R"
                    },
                    new Movie
                    {
                        Title = "Ghostbusters",
                        ReleaseDate = DateTime.Parse("1984-03-13"),
                        Genre = "Comedy",
                        Price = 8.99M,
                        Rating = "G"
                    }, new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-02-23"),
                        Genre = "Comedy",
                        Price = 9.99M,
                        Rating = "G"
                    }, new Movie
                    {
                        Title = "Río Bravo",
                        ReleaseDate = DateTime.Parse("1959-04-15"),
                        Genre = "Western",
                        Price = 3.99M,
                        Rating = "NA"
                    }
                );

                context.SaveChanges();
            
            }
        }
    }
        
}
