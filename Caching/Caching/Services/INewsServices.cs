using System.Collections.Generic;

namespace Caching.Services
{
    public interface INewsServices
    {
        IList<string> news { get; set; }

        IList<string> GetLatestNews();
    }
}