using System;
using System.Collections.Generic;
using LinkShortenerWebApi.Models;

namespace LinkShortenerWebApi.Repositories
{
 public interface ILinksRepository
    {
        (IEnumerable<Link>, int) Get(string search, int skip);
        Link Get(int Id);
        Link Create(Link link);
        Link Update(Link link);
        void Delete(int id);        
    }
}