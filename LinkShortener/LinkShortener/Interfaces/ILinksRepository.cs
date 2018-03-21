using LinkShortener.Models;
using System.Collections.Generic;

namespace LinkShortener.Interfaces
{
    public interface ILinksRepository
    {
        void AddLink(Link link);
        string GetUrlForHash(string hash);
        List<Link> GetLinks();
        void Update(Link link);
        void Delete(Link link);  
    }
}
