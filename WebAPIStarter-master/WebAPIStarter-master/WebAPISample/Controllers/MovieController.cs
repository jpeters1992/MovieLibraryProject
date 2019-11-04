﻿using System;
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
        public IHttpActionResult Post([FromBody]Movie value)
        {
            // Create movie in db logic
            throw new NotImplementedException();
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
            //still needs to be coded out
            throw new NotImplementedException();
        }

        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            // Delete movie from db logic
            throw new NotImplementedException();
        }
    }

}