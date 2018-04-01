using System.Linq;
using LinkShortenerWebApi.Models;
using LinkShortenerWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortenerWebApi.Controllers
{
    [Produces("application/json")]
    [Route(template: "api/Link")]
    public class LinkApiController : Controller
    {
      private readonly ILinksRepository repository;
      private int itemPerPage = 10;
      public LinkApiController(ILinksRepository repository)
      {
          this.repository = repository;
      }

      // GET api/Link/{id}
      // Sample: http://localhost:5000/api/Link/2
      [HttpGet("{id}")]
      public IActionResult Get(long id)
      {
          return Ok(repository.Get(id));
      }

      //GET api/Link?Page={PageNumber}&Search={PartOfString}
      //Sample: http://localhost:5000/api/Link?Page=1&Search=trojmiasto.pl
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

      // DELETE api/Link
      // Sample: http://localhost:5000/api/Link?id=2
      [HttpDelete]
      public IActionResult Delete(long id)
      {
          repository.Delete(id);
          return Ok();
      }

      //POST api/Link
      [HttpPost]
      public IActionResult Post([FromBody]CreateLinkRequest createLink)
      {
            return Ok(repository.Create(createLink.GetLink()));
      }

      //POST api/Link
      [HttpPut]
      public IActionResult Put([FromBody]Link link)
      {
            return Ok(repository.Update(link));
      }
  }
    }