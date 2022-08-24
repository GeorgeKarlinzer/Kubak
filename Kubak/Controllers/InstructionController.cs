using Kubak.Data;
using Kubak.Models;
using Kubak.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Kubak.Controllers
{
    public class InstructionController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public InstructionController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _context = dbContext;
        }

        [Authorize]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [Authorize]
        public IActionResult CreateInstruction()
        {
            return View();
        }

        [Authorize]
        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userOrganization = _context.UserOrganizations.First(x => x.UserId == userId);

            var instructions = _context.Instructions
                .Where(x => x.OrganizationId == userOrganization.OrganizationId)
                .ToList()
                .Where(x => x.CategoryId is null);
            var categories = _context.InstructionCategories
                .Where(x => x.OrganizationId == userOrganization.OrganizationId)
                .ToList()
                .Where(x => x.CategoryId is null);

            var viewModel = new InstructionsViewModel
            {
                Instructions = instructions,
                Categories = categories
            };

            return View(viewModel);
        }
    }
}
