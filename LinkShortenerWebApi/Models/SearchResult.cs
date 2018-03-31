using System.Collections.Generic;

namespace LinkShortenerWebApi.Models
{
    public class SearchResult
  {
      public IEnumerable<LinkResult> Items { get; set; }
      public PageInfo PageInfo { get; set; }
  }
}