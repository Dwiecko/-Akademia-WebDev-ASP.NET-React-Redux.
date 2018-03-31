using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkShortenerWebApi.DAO;
using LinkShortenerWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LinkShortenerWebApi.Repositories
{
    public class LinksRepository : ILinksRepository
    {
        private readonly LinksDbContext _context;
        private readonly int _linksToShow = 20;
        public LinksRepository(LinksDbContext context) 
        {
            _context = context;
        }
        public void Delete(long id)
        {
            Link linkEntity = _context.Links.Find(id);
            _context.Links.Remove(linkEntity);
            _context.SaveChanges();
        }

        public Link Create(Link link)
        {
            link.Hash = ConvertLinkToHex(link);
            _context.Links.Add(link);
            _context.SaveChanges();
            return link;
        }
        public Link Update(Link link)
        {
            _context.Links.Attach(link);
            _context.Entry(link).State = EntityState.Modified;
            _context.SaveChanges();
            return link;
        }

        public (IEnumerable<Link>, int) Get(string search, int skip)
        {
            var linksFilteredByURL = search != null ? _context.Links
            .Where(x => x.URL.ToLower()
            .Contains(search)) : _context.Links;
            var linksCount = linksFilteredByURL.Count();

            var paginatedLink = linksFilteredByURL
            .OrderBy(x => x.Id)
            .Skip(skip)
            .Take(_linksToShow);

            return (paginatedLink, linksCount);
        }

        public Link Get(long id) => _context.Links.Find(id);
        private string ConvertLinkToHex(Link link)
        {
            var hexCode = String.Format("{0:X}", link.URL.GetHashCode());
            return hexCode;
        }
        public string GetUrlForHash(string hash)
        {
            var urlItem = _context.Links.Where(item => item.Hash == hash).FirstOrDefault();

            if (urlItem == null)
                return string.Empty;

            return urlItem.URL;
        }
    }
}