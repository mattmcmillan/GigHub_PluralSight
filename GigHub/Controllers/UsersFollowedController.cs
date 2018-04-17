using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class UsersFollowedController : Controller
    {
        public ApplicationDbContext _context;

        public UsersFollowedController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var artists = _context.Followings
                .Where(a => a.FollowerId == userId)
                .Select(a => a.UserFollowed)
                .ToList();

            return View(artists);
        }
    }
}