using LinkShortenerWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

public class RedirectController : Controller
    {
        private ILinksRepository _repository;

        public RedirectController(ILinksRepository linksRepository)
        {
            _repository = linksRepository;
        }

        [HttpGet("api/{hash}")]
        public IActionResult Index(string hash)
        {
            var URL = GetRepository().GetUrlForHash(hash);
            if (URL.Contains("http://") || URL.Contains("https://"))
                return Ok(Json(URL));
            else
                return Ok(Json("http://" + URL));
        }

    private ILinksRepository GetRepository() => _repository;
}