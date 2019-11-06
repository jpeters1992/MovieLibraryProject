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
        //MEMBER VARIABLES
        ApplicationDbContext context;

        //CONSTRUCTOR
        public MovieController()
        {
            context = new ApplicationDbContext();
        }

        //MEMBER METHODS 

        // GET api/values
        public IHttpActionResult Get()
        {
            // Retrieve ALL movies from db logic
            var movies = context.Movies.ToList();
            return Ok(movies);
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            // Retrieve A movie by id from db logic
            var movie = context.Movies.Find(id);
            if(movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        // POST api/values
        public IHttpActionResult Post([FromBody]Movie value)
        {
            // Create movie in db logic
            var movieInDb = context.Movies.SingleOrDefault(m => m.MovieId == value.MovieId);
            if (movieInDb == null)
            {
                try
                {
                    var newMovie = context.Movies.Add(value);
                    context.SaveChanges();
                    return Content(HttpStatusCode.Created, newMovie);
                }
                catch (Exception)
                {
                    return InternalServerError(new Exception("ERROR: Unable to create new row in database from supplied data"));
                }

            }
            else
            {
                return Ok(Update(movieInDb.MovieId, value));
            }
        }

        // PUT api/values/5
        public IHttpActionResult Put(int id, [FromBody]Movie value)
        {
            // Update movie in db logic
            var foundMovie = Update(id, value);
            if(foundMovie == null)
            {
                return NotFound();
            }
            return Ok(foundMovie);
        }

        
        private Movie Update(int id, Movie value)
        {
            // Update movie in db logic
            var foundMovie = context.Movies.SingleOrDefault(m => m.MovieId == id);
            if(foundMovie == null || value == null)
            {
                return null;
            }
            try
            {
                foundMovie.Title = value.Title;
                foundMovie.Director = value.Director;
                foundMovie.Genre = value.Genre;
                context.SaveChanges();
                return foundMovie;
            }
            catch (Exception)
            {
                throw new Exception("ERROR: Unable to update database");
            }
        }

        //// DELETE api/values/5
        //public IHttpActionResult Delete(int id)
        //{
        //    // Delete movie from db logic
        //    throw new NotImplementedException();
        //}
    }

}