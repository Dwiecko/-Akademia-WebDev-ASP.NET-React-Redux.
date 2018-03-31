using System.Linq;
using LinkShortenerWebApi.Models;
using LinkShortenerWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortenerWebApi.Controllers
{
    [Route("api/[controller]")]
    public class LinkApiController : Controller
    {
      private readonly ILinksRepository repository;
      private int itemPerPage = 10;
      public LinkApiController(ILinksRepository repository)
      {
          this.repository = repository;
      }

      [HttpGet("{id}")]
      // GET api/stops/{id}
      public IActionResult Get(int id)
      {
          return Ok(repository.Get(id));
      }

      //GET api/stops/?search={string}&page={int}
      [HttpGet]
      public IActionResult Get([FromQuery]GetLinkRequest request)
      {
          var (links, count) = repository
                  .Get(request.Search, (request.Page.Value - 1) * itemPerPage);
          var result = new SearchResult
          {
              PageInfo = new PageInfo
              {
                  CurrentPage = request.Page.Value,
                  MaxPage = count % itemPerPage == 0 ? count / itemPerPage : count / itemPerPage + 1
              },
              Items = links.Select(selector: x => new LinkResult(x))
          };
          return Ok(result);
      }

      // DELETE api/stops/{id}
      [HttpDelete]
      public IActionResult Delete(int id)
      {
          repository.Delete(id);
          return Ok();
      }

      //POST api/stops
      [HttpPost]
      public IActionResult Post([FromBody]CreateLinkRequest createLink)
      {
            return Ok(repository.Create(createLink.GetLink()));
      }

      //POST api/stops
      [HttpPut]
      public IActionResult Put([FromBody]Link stop)
      {
            return Ok(repository.Update(stop));
      }
  }
    }