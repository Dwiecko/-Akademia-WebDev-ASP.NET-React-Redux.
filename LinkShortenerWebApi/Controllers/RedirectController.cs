using LinkShortenerWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

public class RedirectController : Controller
    {
        private ILinksRepository _repository;

        public RedirectController(ILinksRepository linksRepository)
        {
            _repository = linksRepository;
        }

        [HttpGet("{hash}")]
        public IActionResult Index(string hash)
        {
            var URL = GetRepository().GetUrlForHash(hash);
            if (URL.Contains("http://") || URL.Contains("https://"))
                return Ok(Redirect(URL));
            else
                return Ok("http://" + URL);
        }

    private ILinksRepository GetRepository() => _repository;
}