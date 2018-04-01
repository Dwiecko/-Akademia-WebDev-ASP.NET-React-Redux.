using LinkShortenerWebApi.Models;
using LinkShortenerWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.Controllers
{
    public class LinkController : Controller
    {
        private ILinksRepository _repository;

        public LinkController(ILinksRepository linksRepository)
        {
            _repository = linksRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var books = _repository.GetLinks();
            return View(books);
        }

        [HttpPost]
        public IActionResult Create(Link link)
        {
            _repository.Create(link);
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Delete(Link link)
        {
            _repository.Delete(link.Id);
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult Edit(Link link)
        {
            return View(link);
        }

        [HttpPost]
        public IActionResult Update(Link link)
        {
            _repository.Update(link);
            return Redirect("Index");
        }
    }
}