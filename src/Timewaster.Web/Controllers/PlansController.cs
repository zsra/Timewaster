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
        private readonly IPlansService _plansService;

        public PlansController(IPlansService plansService)
        {
            _plansService = plansService;
        }

        public async Task<IActionResult> Index(int? id)
        {
            PlanViewModel viewModel;
            if (id == null)
            {
                (Sprint sprint, IEnumerable<SprintStory> sprintStories) = await _plansService.CreatePlan(new ServiceContext() { ContextId = "test" });
                viewModel = new PlanViewModel
                {
                    Sprint = sprint,
                    SprintStories = new List<SprintStory>(sprintStories),
                    Statuses = new List<Status>(await _plansService.GetDefaultStatuses(new ServiceContext()))
                };
            }
            else
            {
                (Sprint sprint, IEnumerable<SprintStory> sprintStories) = await _plansService.GetSprint(new ServiceContext() { ContextId = "test" }, (int)id);
                viewModel = new PlanViewModel
                {
                    Sprint = sprint,
                    SprintStories = new List<SprintStory>(sprintStories),
                    Statuses = new List<Status>(await _plansService.GetDefaultStatuses(new ServiceContext())),
                };
            }
           
            return View(viewModel);
        }

        public async Task<IActionResult> CreateStory(Story story, int sprintId)
        {
            if (!string.IsNullOrEmpty(story.Name))
            {          
                await _plansService.CreateStory(new ServiceContext() { ContextId = "TEST" }, story);
                return RedirectToAction(nameof(Index), sprintId);
            }
            else
            {
                story = await _plansService.AssignSprintToStory(new ServiceContext() { ContextId = "TEST" }, story, sprintId);
                return View(story);
            }

           
        }

        public async Task<IActionResult> CreateIssue([Bind("Name, Description")] Issue issue)
        {
            if (!string.IsNullOrEmpty(issue.Title))
            {
                await _plansService.CreateIssue(new ServiceContext() { ContextId = "TEST" }, issue);
                return RedirectToAction(nameof(Index));
            }
                
            return View(issue);
        }

        public async Task<IActionResult> UpdateStory([Bind("Name, Description")] Story story)
        {
            await _plansService.UpdateStory(new ServiceContext() { ContextId = "TEST" }, story);
            return View(story);
        }

        public async Task<IActionResult> UpdateIssue([Bind("Name, Description")] Issue issue)
        {
            await _plansService.UpdateIssue(new ServiceContext() { ContextId = "TEST" }, issue);
            return View(issue);
        }

        public async Task<IActionResult> DeleteSprint(int id)
        {
            await _plansService.DeleteSprint(new ServiceContext() { ContextId = "TEST" }, id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteStory(int id)
        {
            await _plansService.DeleteStory(new ServiceContext() { ContextId = "TEST" }, id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteIssue(int id)
        {
            await _plansService.DeleteIssue(new ServiceContext(), id);
            return RedirectToAction(nameof(Index));
        }
    }
}
