using Kubak.Data;
using Kubak.Models;
using Kubak.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Kubak.Controllers
{
    [Authorize]
    public class InstructionController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        private UserOrganization UserOrganization => _context.UserOrganizations
                .First(x => x.UserId == User.FindFirst(ClaimTypes.NameIdentifier).Value);

        public InstructionController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _context = dbContext;
        }

        public IActionResult CreateCategory()
        {
            ViewBag.Categories = _context.InstructionCategories
                    .Where(x => x.OrganizationId == UserOrganization.OrganizationId)
                    .ToList()
                    .Append(new InstructionCategory());

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([Bind("Name", "CategoryId")] InstructionCategory category)
        {
            if (category.CategoryId == 0)
                category.CategoryId = null;

            category.OrganizationId = UserOrganization.OrganizationId;
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> CreateInstruction([Bind("Name", "Link", "CategoryId")] Instruction instruction)
        {
            if (instruction.CategoryId == 0)
                instruction.CategoryId = null;

            instruction.OrganizationId = UserOrganization.OrganizationId;
            await _context.AddAsync(instruction);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateInstruction()
        {
            ViewBag.Categories = _context.InstructionCategories
                       .Where(x => x.OrganizationId == UserOrganization.OrganizationId)
                       .ToList()
                       .Append(new InstructionCategory());

            return View();
        }

        public IActionResult Index()
        {
            var instructions = _context.Instructions
                .Where(x => x.OrganizationId == UserOrganization.OrganizationId)
                .ToList()
                .Where(x => x.CategoryId is null);
            var categories = _context.InstructionCategories
                .Where(x => x.OrganizationId == UserOrganization.OrganizationId)
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
