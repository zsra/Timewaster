using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.Interfaces.Services;
using Timewaster.Core.ValueObjects;
using Timewaster.Web.Converters;
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
                (Sprint sprint, IEnumerable<SprintStory> sprintStories) = await _plansService.CreatePlan(new ServiceContext() { ContextId = "TEST" });
                viewModel = new PlanViewModel
                {
                    Sprint = sprint,
                    SprintStories = new List<SprintStory>(sprintStories),
                    Statuses = new List<Status>(await _plansService.GetDefaultStatuses(new ServiceContext()))
                };
            }
            else
            {
                (Sprint sprint, IEnumerable<SprintStory> sprintStories) = await _plansService.GetSprintPlan(new ServiceContext() { ContextId = "TEST" }, (int)id);
                viewModel = new PlanViewModel
                {
                    Sprint = sprint,
                    SprintStories = new List<SprintStory>(sprintStories),
                    Statuses = new List<Status>(await _plansService.GetDefaultStatuses(new ServiceContext())),
                };
            }
           
            return View(viewModel);
        }

        public async Task<IActionResult> CreateStory(StoryViewModel storyVM, int sprintId)
        {
            if (ModelState.IsValid)
            {
                Sprint sprint = await _plansService.GetSprint(new ServiceContext() { ContextId = "TEST" }, storyVM.SprintId);
                Story story = storyVM.ViewModelToEntity(sprint);
                
                await _plansService.CreateStory(new ServiceContext() { ContextId = "TEST" }, story);
                
                return RedirectToAction(nameof(Index), new { id = storyVM.SprintId });
            }
            storyVM.SprintId = sprintId;
            return View(storyVM);
        }

        public async Task<IActionResult> CreateIssue(IssueViewModel issueVM, int statusId, int storyId, int sprintId)
        {
            if (ModelState.IsValid)
            {
                Status status = await _plansService.GetStatus(new ServiceContext() { ContextId = "TEST" }, issueVM.StatusId);
                Story story = await _plansService.GetStory(new ServiceContext() { ContextId = "TEST" }, issueVM.StoryId);   
                Issue issue = issueVM.ViewModelToEntity(status, story);

                await _plansService.CreateIssue(new ServiceContext() { ContextId = "TEST" }, issue);
                
                return RedirectToAction(nameof(Index), new { id = issueVM.SprintId });
            }
            issueVM.StatusId = statusId;
            issueVM.StoryId = storyId;
            issueVM.SprintId = sprintId;
            return View(issueVM);
        }

        public async Task<IActionResult> UpdateStory([Bind("Name, Description")] Story story)
        {
            await _plansService.UpdateStory(new ServiceContext() { ContextId = "TEST" }, story);
            return View(story);
        }

        public async Task<IActionResult> UpdateIssue(int id, IssueViewModel issueVM)
        {
            if (id != issueVM.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                Status status = await _plansService.GetStatus(new ServiceContext() { ContextId = "TEST" }, issueVM.StatusId);
                Story story = await _plansService.GetStory(new ServiceContext() { ContextId = "TEST" }, issueVM.StoryId);
                Issue issue = issueVM.ViewModelToEntity(status, story);
                
                await _plansService.UpdateIssue(new ServiceContext() { ContextId = "TEST" }, issue);
                return RedirectToAction(nameof(Index), new { id = issueVM.SprintId });
            }

            return View(issueVM);
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
