using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caching.Services
{
    public class NewsServices : INewsServices
    {
        public IList<string> news { get; set; }

        public IList<string> GetLatestNews()
        {
            news = new List<string> { "Titulo 1", "Titulo 2" };
            return news;
        }
    }
}
