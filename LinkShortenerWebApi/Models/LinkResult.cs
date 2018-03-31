namespace LinkShortenerWebApi.Models
{
    public class LinkResult
  {
      public LinkResult(Link link)
      {
          Id = link.Id;
          URL = link.URL;
          Hash = link.Hash;
      }
      public long Id { get; set; }
      public string URL { get; set; }
      public string Hash { get; set; }
  }   
}