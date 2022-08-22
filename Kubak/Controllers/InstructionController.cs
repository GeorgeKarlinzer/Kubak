using Kubak.Data;
using Kubak.Models;
using Kubak.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult CreateCategory()
        {
            return View();
        }

        public IActionResult CreateInstruction()
        {
            return View();
        }

        public IActionResult Index()
        {
            var instructions = _context.Instructions
                .Include(x => x.Category).ToList();
            var categories = _context.InstructionCategories
                .Include(x => x.Instructions)
                .Include(x => x.ChildCategories).ToList();

            var viewModel = new InstructionsViewModel
            {
                Instructions = instructions.Where(x => x.CategoryId is null),
                Categories = categories.Where(x => x.CategoryId is null)
            };

            return View(viewModel);
        }
    }
}
