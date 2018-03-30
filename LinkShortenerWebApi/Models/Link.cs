using System;

namespace LinkShortenerWebApi.Models
{
    public class Link
    {
        public long Id { get; set; }
        public string URL { get; set; }
        public string Hash { get; set; }
    }
}
