using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace DockerMVCApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IDbConnection _db;

        public UsersController(IDbConnection db)
        {
            _db = db;
        }

        [HttpGet("api/users")]
        public async Task<IEnumerable<dynamic>> Get()
        {
            return await _db.QueryAsync("SELECT * FROM users");
        }

        [HttpPost("api/users")]
        public async Task<dynamic> Create([FromBody] User user)
        {
            return await _db.ExecuteAsync("INSERT INTO users VALUES(@id,@name,@message)", user);
        }

        [HttpGet("api/users/test")]
        public IActionResult Test()
        {
            return Ok(new {Message = "users test"});
        }
    }

    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
    }
}