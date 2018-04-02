using LinkShortenerWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

public class RedirectController : Controller
    {
        private ILinksRepository _repository;

        public RedirectController(ILinksRepository linksRepository)
        {
            _repository = linksRepository;
        }

        [HttpGet(template: "/{hash}")]
        public IActionResult Index(string hash)
        {
            var URL = GetRepository().GetUrlForHash(hash);
            if(string.IsNullOrEmpty(URL))  return NotFound();

            if (URL.Contains("http://") || URL.Contains("https://"))
                return Redirect((URL));
            else
                return Redirect(("http://" + URL));
        }

    private ILinksRepository GetRepository() => _repository;
}