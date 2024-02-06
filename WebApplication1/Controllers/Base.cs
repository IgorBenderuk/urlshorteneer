using AutoMapper;
using DataService.Repos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Base(IUnitOfWork unitOfWork, IMapper mapper) : ControllerBase
    {
        protected readonly IUnitOfWork unitOfWork = unitOfWork;
        protected readonly IMapper mapper = mapper;
    }
}
