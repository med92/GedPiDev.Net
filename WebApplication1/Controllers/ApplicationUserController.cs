using GedPiDev.Domain.Entities;
using GedPiDev.Service.Implementation;
using GedPiDev.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class ApplicationUserController : ApiController
    {
        private IUserService userService = new UserService();

        // GET: api/Courriers
        [Authorize(Roles = "Admin")]
        public Task<List<ApplicationUser>> GetUsers()
        {
            return userService.GetAllAsync();
        }
        [Authorize(Roles = "user")]
        // GET: api/Courriers/5
        [ResponseType(typeof(ApplicationUser))]
        public async Task<IHttpActionResult> GetUser(string id)
        {
            ApplicationUser user = userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [Authorize(Roles = "user")]
        //GET api/Courriers/5
        [ResponseType(typeof(ApplicationUser))]
        public async Task<IHttpActionResult> GetUserByName(string username)
        {
            ApplicationUser user = userService.FindAsync(u=>u.UserName == username).Result;
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);

        }
    }
}
