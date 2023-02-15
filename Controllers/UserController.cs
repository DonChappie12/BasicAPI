using AutoMapper;
using BasicAPI.DTOs;
using BasicAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        // private readonly ILogger<WeatherForecastController> _logger;
        public readonly IMapper _mapper;
        private DBContext _context;

        public UserController(IMapper mapper, DBContext context)
        // public UserController(ILogger<UserController> logger)
        {
            // _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var users = _context.Users.ToList();
            var userResponse = _mapper.Map<List<UserDTO>>(users);
            return Ok(userResponse);
        }

        [HttpPost]
        public ActionResult Post([FromBody] UserDTO user)
        {
            var newUser = new User
            {
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email
            };

            _context.Users.Add(newUser);
            var userResponse = _mapper.Map<User>(newUser);
            _context.SaveChanges();

            return Ok(userResponse);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UserDTO user)
        {
            var updateUser = _context.Users.FirstOrDefault(u => u.Id == id);
            _mapper.Map(user, updateUser);

            _context.Users.Update(updateUser);
            _context.SaveChanges();
            return Ok(updateUser);
        }
    }
}