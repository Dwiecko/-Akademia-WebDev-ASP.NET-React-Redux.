using LinkShortener.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.Controllers
{
    [Route("")]
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
            var URL = _repository.GetUrlForHash(hash);
            if (URL.Contains("http://") || URL.Contains("https://"))
                return Redirect(URL);
            else
                return Redirect("http://" + URL);
        }
    }
}