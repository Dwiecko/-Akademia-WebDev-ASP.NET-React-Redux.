using System.Linq;
using LinkShortenerWebApi.Models;
using LinkShortenerWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortenerWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/LinkApi")]
    public class LinkApiController : Controller
    {
      private readonly ILinksRepository repository;
      private int itemPerPage = 10;
      public LinkApiController(ILinksRepository repository)
      {
          this.repository = repository;
      }

      [HttpGet("{id}")]
      // GET api/links/{id}
      public IActionResult Get(int id)
      {
          return Ok(repository.Get(id));
      }

      //GET api/links/?search={PartOfURL}&page={int}
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

      // DELETE api/links/{id}
      [HttpDelete]
      public IActionResult Delete(int id)
      {
          repository.Delete(id);
          return Ok();
      }

      //POST api/links
      [HttpPost]
      public IActionResult Post([FromBody]CreateLinkRequest createLink)
      {
            return Ok(repository.Create(createLink.GetLink()));
      }

      //POST api/links
      [HttpPut]
      public IActionResult Put([FromBody]Link link)
      {
            return Ok(repository.Update(link));
      }
  }
    }