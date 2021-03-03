using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.Entities.Projects;
using Timewaster.Core.Interfaces.Services;
using Timewaster.Core.ValueObjects;
using Timewaster.Web.ViewModels;

namespace Timewaster.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<IActionResult> Index(int? projectId)
        {
            if (projectId == null) return NotFound();

            Project project = await _projectService.GetProject(new ServiceContext(), (int)projectId);
            
            var projectViewModel = new ProjectViewModel
            {
                Sprints = new List<Sprint>(project.Sprints),
            };
            return View(projectViewModel);
        }

        public async Task<IActionResult> Create([Bind("Name", "Description")] Project project)
        {
            if (!string.IsNullOrEmpty(project.Name))
            {
                project.PartitionKey = "test";
                project = await _projectService.CreateAsync(new ServiceContext(), project);
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

    }
}
