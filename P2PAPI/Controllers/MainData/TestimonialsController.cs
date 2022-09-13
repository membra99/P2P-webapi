using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using P2P.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using P2P.DTO.Output;
using P2P.DTO.Input;

namespace P2P.WebApi.Controllers.MainData
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class TestimonialsController : ControllerBase
    {
        private readonly MainDataServices _mainDataServices;

        public TestimonialsController(MainDataServices mainServices)
        {
            _mainDataServices = mainServices;
        }

        //GET: api/Testimonial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestimonialODTO>>> GetById(int id)
        {
            return await _mainDataServices.Get(id);
        }


        //PUT: api/Testimonial
        [HttpPut]
        public async Task<ActionResult<IEnumerable<TestimonialODTO>>> PutTestimonials(TestimonialIDTO testimonialIDTO)
        {
            try
            {
                return await _mainDataServices.EditTestimonial(testimonialIDTO);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        //POST: api/Testimonial
        [HttpPost]
        public async Task<ActionResult<IEnumerable<TestimonialODTO>>> PostTestimonials(TestimonialIDTO testimonialIDTO)
        {
            try
            {
                return await _mainDataServices.AddTest(testimonialIDTO);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //DELETE: api/Testimonial/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<TestimonialODTO>>> DeleteTestimonial(int id)
        {
            try
            {
                var testimonial = await _mainDataServices.DeleteTestimonial(id);
                if (testimonial == null) return NotFound();
                return testimonial;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }
    }
}
