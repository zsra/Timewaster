using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Projects;
using Timewaster.Core.Interfaces.Services;
using Timewaster.Core.ValueObjects;
using Timewaster.Web.ViewModels;

namespace Timewaster.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            DashboardViewModel viewModel = new DashboardViewModel {
                Projects = new List<Project>( await _dashboardService.GetProjects(new ServiceContext()) )
            };

            return View(viewModel);
        }

        public async Task<IActionResult> ViewProject(int? projectId)
        {
            if (projectId == null) return NotFound();

            var project = await _dashboardService.GetProject(new ServiceContext(), (int)projectId);
            return View(project);
        }

        public async Task<IActionResult> CreateProject([Bind("Name", "Description")] Project project)
        {
            if (!string.IsNullOrEmpty(project.Name))
            {
                project.PartitionKey = "test";
                project = await _dashboardService.CreateProjectAsync(new ServiceContext(), project);
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }
    }
}
