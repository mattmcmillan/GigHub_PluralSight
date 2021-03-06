﻿using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)

        {
            var userId = User.Identity.GetUserId();

            if (_context.Followings.Any(f => f.UserFollowedId == dto.UserFollowedId
                                             && f.FollowerId == userId))
            {
                return BadRequest("User has already followed this artist.");
            }

            var following = new Following()
            {
                FollowerId = userId,
                UserFollowedId = dto.UserFollowedId
            };

            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();
        }
    }
}
