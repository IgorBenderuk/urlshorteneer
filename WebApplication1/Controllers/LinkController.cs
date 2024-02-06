using AutoMapper;
using DataService.Entities.DbSet;
using DataService.Entities.DTOS.RequestDto;
using DataService.Entities.DTOS.ResponseDto;
using DataService.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController(IUnitOfWork unitOfWork, IMapper mapper) : Base(unitOfWork, mapper)
    {
        [HttpGet("/{shortCode}")]
        public async Task<IActionResult> Redirect(string shortCode)
        {
            var link = await unitOfWork.LinkRepo.GetUrlByShorten(shortCode);
            if (link == null)
                    return NotFound("it is any Url according to this shorten one ");

            return await Redirect(link.LongUrl);
        }


            
        [HttpGet]
        public async Task<IActionResult> GetLinks()
        {
            var links = await unitOfWork.LinkRepo.GetAll();
            var result = mapper.Map<IEnumerable<LinkResponse>>(links);
            return Ok(result);
        }

        [HttpGet("getLinksByUser")]
        public async Task<IActionResult> GetLinksByUser(Guid Id)
        {
            var links = await unitOfWork.LinkRepo.GetUserLinks(Id);
            var result = mapper.Map<IEnumerable<LinkResponse>>(links);
            return Ok(result);
        }
        [HttpGet("{linkID:Guid}")]
        public async Task<IActionResult> GetSingleLink(Guid linkID)
        {
            var link = await unitOfWork.LinkRepo.GetSingle(linkID) ;
            var result = mapper.Map<LinkResponse>(link);
            return Ok(result);
        }


        [HttpPost]///this endpoint returns invalid guid Id for just created link 
        public async Task<IActionResult> Create([FromBody] CreateLinkrRequest linkCreate)
        {
            if (!ModelState.IsValid)
                return BadRequest("invelid model to create");

            if (!Uri.TryCreate(linkCreate.LongUrl, UriKind.Absolute, out var url))
                return BadRequest("Invalid url");

            var link = mapper.Map<Link>(linkCreate);
            link.UserId = linkCreate.UserId;

            await unitOfWork.LinkRepo.Create(link);
            await unitOfWork.CompleteAsync();
            var id = link.Id;
            return CreatedAtAction(nameof(GetSingleLink), new { linkID =link.Id}, link);
        }





    }
}
