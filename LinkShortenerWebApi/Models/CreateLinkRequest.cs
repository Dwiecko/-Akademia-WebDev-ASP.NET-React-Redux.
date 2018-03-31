namespace LinkShortenerWebApi.Models
{
    public class CreateLinkRequest
    {
        public string URL { get; set; }

        public Link GetLink()
        {
            var link = new Link
            {
                URL = this.URL
            };
            return link; 
        }
    }
}