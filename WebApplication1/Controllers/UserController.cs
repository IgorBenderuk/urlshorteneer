using AutoMapper;
using DataService.Entities.DbSet;
using DataService.Entities.DTOS.RequestDto;
using DataService.Entities.DTOS.ResponseDto;
using DataService.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUnitOfWork unitOfWork, IMapper mapper) : Base(unitOfWork, mapper)
    {
        [HttpGet]
        public async Task<IActionResult>GetUsers()
        {
            var users = await unitOfWork.UserRepo.GetAll();
            var result = mapper.Map<IEnumerable<UserResponse>>(users);
            return Ok(result);
        }

        [HttpGet("userID : Guid")]
        public async Task<IActionResult> GetSingleUser(Guid Id)
        {
            var user = await unitOfWork.UserRepo.GetSingle(Id);
            var result = mapper.Map<User>(user);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDriver(CreateUserRequest userCreate)
        {
            if(!ModelState.IsValid)
                return BadRequest("invalid model");

            var user = mapper.Map<User>(userCreate);

            await unitOfWork.UserRepo.Create(user);
            await unitOfWork.CompleteAsync();
            return CreatedAtAction(nameof(GetSingleUser), new { userId = user.Id }, user);
        }


        [HttpPut]
        public async Task<IActionResult> UpDateUser([FromBody] UpDateUserRequest userUpDate)
        {
            if (!ModelState.IsValid)
                return BadRequest("invalid model");

            var user= mapper.Map<User>(userUpDate);

            await unitOfWork.UserRepo.Update(user);
            await unitOfWork.CompleteAsync();
            return CreatedAtAction(nameof(GetSingleUser), new { userId = user.Id }, user);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var user =await unitOfWork.UserRepo.GetSingle(userId);
            if (user == null)
                return NotFound();

            await unitOfWork.UserRepo.Delete(userId);
            await unitOfWork.CompleteAsync();
            return NoContent();
        }






    }
}
