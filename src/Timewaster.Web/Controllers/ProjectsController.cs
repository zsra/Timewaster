using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.Entities.Projects;
using Timewaster.Core.Interfaces.Services;
using Timewaster.Core.ValueObjects;
using Timewaster.Web.ViewModels;

namespace Timewaster.Web.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<IActionResult> View(int? id)
        {
            if (id == null) return NotFound();

            Project project = await _projectService.GetProject(new ServiceContext(), (int)id);
            
            var projectViewModel = new ProjectViewModel
            {
                ProjectName = project.Name,
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
