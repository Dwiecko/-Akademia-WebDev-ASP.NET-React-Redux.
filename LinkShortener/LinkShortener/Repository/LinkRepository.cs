using LinkShortener.Interfaces;
using LinkShortener.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinkShortener.Repository
{
    public class LinkRepository : ILinksRepository
    {
        public static List<Link> _links;
        public LinkRepository()
        {
             _links = new List<Link>
             {
                new Link{
                    Id = 0,
                    URL = "https://google.com/",
                    Hash = "ABCDEFGH"
                },
                new Link{
                    Id = 1,
                    URL = "https://wp.pl/",
                    Hash = "ZXCVBNML"
                }
             };
        }

        public void AddLink(Link link)
        {
            link.Id = _links.Count;
            link.Hash = ConvertLinkToHex(link);
            _links.Add(link);
        }

        public void Delete(Link link)
        {
            var linkToDelete = _links
                .SingleOrDefault(element => element.URL == link.URL && element.Hash == link.Hash);
            _links.Remove(linkToDelete);
        }

        public List<Link> GetLinks() => _links;

        public void Update(Link link)
        {
            var linkToUpdateIndex = _links.FindIndex(element => element.Id == link.Id);
            if (linkToUpdateIndex != -1)
                _links[linkToUpdateIndex] = link;
        }

        private String ConvertLinkToHex(Link link)
        {
            var hexCode = String.Format("{0:X}", link.URL.GetHashCode());
            return hexCode;
        }
        public string GetUrlForHash(string hash)
        {
            var urlItem = _links.Where(item => item.Hash == hash).FirstOrDefault();

            if (urlItem == null)
                return string.Empty;

            return urlItem.URL;
        }
    }
}
