using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
    public class MovieController : ApiController
    {
        ApplicationDbContext context;
        public MovieController()
        {
            context = new ApplicationDbContext();
        }

        // GET api/values
        public IHttpActionResult Get()
        {
            // Retrieve all movies from db logic
            var movies = context.Movies.ToList();
            return Ok(movies);
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            // Retrieve movie by id from db logic
            var movie = context.Movies.Find(id);
            if(movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        // POST api/values
        public IHttpActionResult Post([FromBody]Movie movie)
        {
            // Create movie in db logic

            if (!ModelState.IsValid)
                return BadRequest();

            context.Movies.Add(movie);
            context.SaveChanges();

            return Ok(movie);
        }

        // PUT api/values/5
        public IHttpActionResult Put(int id, [FromBody]Movie movie)
        {
            // Update movie in db logic
            var newMovie = Update(id, movie);
            if(newMovie == null)
            {
                return NotFound();
            }
            return Ok(newMovie);
        }

        
        private Movie Update(int id, Movie movie)
        {
            // Update movie in db logic
            var newMovie = context.Movies.SingleOrDefault(m => m.MovieId == id);
            if(newMovie == null || movie == null)
            {
                return null;
            }
            try
            {
                newMovie.Title = movie.Title;
                newMovie.Director = movie.Director;
                newMovie.Genre = movie.Genre;
                context.SaveChanges();
                return newMovie;
            }
            catch (Exception)
            {
                throw new NotImplementedException("ERROR: Unable to update database");
            }
        }

        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            // Delete movie from db logic
            throw new NotImplementedException();
        }
    }

}