using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab29.Models;

namespace Lab29.Controllers
{
    public class MovieController : ApiController
    {
        [HttpGet]
        public List<string> GetMovieList() // Gets list of all movies
        {
            MovieDBEntities ORM = new MovieDBEntities();
            return ORM.Movies.Select(c => c.movieName).ToList();
        }
        [HttpGet]
        public List<Movy> GetMoviesByCategory(string movieCategory) // list of movies in a category
        {
            MovieDBEntities ORM = new MovieDBEntities();
            return ORM.Movies.Where(c => c.movieCategory.Contains(movieCategory)).ToList();
        }
        [HttpGet]
        public string GetRandomMovie() // returns random movie name
        {
            MovieDBEntities ORM = new MovieDBEntities();
            Random r = new Random();
            List<string> MoviesList = ORM.Movies.Select(c => c.movieName).ToList();
            int result = r.Next(MoviesList.Count());
            return MoviesList[result];
        }
        [HttpGet]
        public Movy GetRandomMovieFromCategory(string category) // get random movie in a certain category
        {
            MovieDBEntities ORM = new MovieDBEntities();
            Random r = new Random();
            List<Movy> movieList = ORM.Movies.Where(c => c.movieCategory.Contains(category)).ToList();
            int result = r.Next(movieList.Count());
            return movieList[result];
        }
        [HttpGet]
        public List<Movy> GetRandomMovies(int amount) // returns random movie(s)
        {
            MovieDBEntities ORM = new MovieDBEntities();
            Random r = new Random();
            List<Movy> MoviesList = ORM.Movies.ToList();
            List<Movy> MovieList = new List<Movy>();
            for (int i = 0; i < amount; i++)
            {
                int result = r.Next(MoviesList.Count());
                MovieList.Add(MoviesList[result]);
                MoviesList.RemoveAt(result);
            }

            return MovieList;

        }
        [HttpGet]
        public List<string> GetAllCategories()
        {
            MovieDBEntities ORM = new MovieDBEntities();
            return ORM.Movies.Select(c => c.movieCategory).Distinct().ToList();
        }

    }
}
