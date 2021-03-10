using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.Interfaces.Services;
using Timewaster.Core.ValueObjects;
using Timewaster.Web.ViewModels;

namespace Timewaster.Web.Controllers
{
    public class PlansController : Controller
    {
        private readonly IPlanService _planService;

        public PlansController(IPlanService planService)
        {
            _planService = planService;
        }

        public async Task<IActionResult> Index()
        {
            PlanViewModel viewModel = new PlanViewModel {
                SprintStories = new List<SprintStory>(await _planService.CreatePlan( new ServiceContext())),
                Statuses = new List<Status>(await _planService.GetDefaultStatuses(new ServiceContext()))
            };
            return View(viewModel);
        }

        public async Task<IActionResult> CreateSprint([Bind("CreatedAt", "ClosingAt")] Sprint sprint)
        {
            await _planService.CreateSprint(new ServiceContext(), sprint);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateStory([Bind("Name, Description")] Story story)
        {
            await _planService.CreateStory(new ServiceContext(), story);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreateIssue([Bind("Name, Description")] Issue issue)
        {
            await _planService.CreateIssue(new ServiceContext(), issue);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteSprint(int id)
        {
            await _planService.DeleteSprint(new ServiceContext(), id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteStory(int id)
        {
            await _planService.DeleteStory(new ServiceContext(), id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteIssue(int id)
        {
            await _planService.DeleteIssue(new ServiceContext(), id);
            return RedirectToAction(nameof(Index));
        }
    }
}
