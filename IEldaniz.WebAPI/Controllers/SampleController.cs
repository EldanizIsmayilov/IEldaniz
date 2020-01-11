using IEldaniz.BusinessLogicLayer.Abstractions.Services;
using IEldaniz.BusinessLogicLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IEldaniz.WebAPI.Controllers
{
    public class SampleController : ApiController
    {
        private readonly ISampleService _sampleService;
        public SampleController(ISampleService sampleService)
        {
            _sampleService = sampleService;
        }

        // GET api/values
        public IHttpActionResult Get()
        {
            return Ok(_sampleService.GetAll());
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            return Ok(_sampleService.Get(id));
        }

        // POST api/values
        public IHttpActionResult Post([FromBody]SampleDto sample)
        {
            return Ok(_sampleService.Add(sample));
        }

        // PUT api/values/5
        public IHttpActionResult Put(int id, [FromBody]SampleDto sample)
        {
            return Ok(_sampleService.Update(id, sample));
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            _sampleService.Delete(id);
        }
    }
}
