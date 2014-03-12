using ConcertManager.Models;
using ConcertManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ConcertManager.Controllers
{
    public class BandController : ApiController
    {
        private BandRepository bandRepository;

        public BandController()
        {
            this.bandRepository = new BandRepository();
            //bandRepository.SaveBand(new Band { Id = 3, Name = "Phoenix" });
        } 

        public Band[] Get()
        {
            return bandRepository.GetAllBands();
        }

        public HttpResponseMessage Post(Band contact)
        {
            this.bandRepository.SaveBand(contact);

            var response = Request.CreateResponse<Band>(System.Net.HttpStatusCode.Created, contact);

            return response;
        }
    }
}
