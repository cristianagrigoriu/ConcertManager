using ConcertManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConcertManager.Services
{
    public class BandRepository
    {
        private const string CacheKey = "ConcertStore";
        

        public BandRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var contacts = new Band[]
                    {
                        new Band
                        {
                            Id = 1, Name = "The Beatles"
                        },
                        new Band
                        {
                            Id = 2, Name = "Queen"
                        }
                    };

                    ctx.Cache[CacheKey] = contacts;
                }
            }
        }

        public Band[] GetAllBands()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (Band[])ctx.Cache[CacheKey];
            }

            return new Band[]
            {
                new Band
                {
                    Id = 0,
                    Name = "Placeholder"
                }
            };
        }

        /*returns the success or failure of adding one band*/
        public bool SaveBand(Band newBand)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = ((Band[])ctx.Cache[CacheKey]).ToList();
                    currentData.Add(newBand);
                    ctx.Cache[CacheKey] = currentData.ToArray();

                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return false;
                }
            }

            return false;
        }
    }
}