using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.Interfaces.Services;
using Timewaster.Core.ValueObjects;
using Timewaster.Web.Converters;
using Timewaster.Web.ViewModels;

namespace Timewaster.Web.Controllers
{
    public class BoardController : Controller
    {
        private readonly IBoardService _boardService;

        public BoardController(IBoardService boardService)
        {
            _boardService = boardService;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id == null) return NotFound();
            Sprint Sprint = await _boardService.GetSprintById(new ServiceContext { ContextId = "TEST" }, (int)id);
            BoardViewModel viewModel = Sprint.EntityToViewModel(
                            sprintStories: await _boardService.GetSprintStories(new ServiceContext { ContextId = "TEST" }, (int)id),
                            statuses: await _boardService.GetStatusesBySprintId(new ServiceContext { ContextId = "TEST" }, (int)id));
            
            return View(viewModel);
        }

        public async Task<IActionResult> GetStory(int? id)
        {
            if (id == null) return NotFound();
            Story story = await _boardService.GetStoryById(new ServiceContext { ContextId = "TEST" }, (int)id);
            StoryViewModel storyVM = story.EntityToViewModel();
            
            return View(storyVM);
        }

        public async Task<IActionResult> GetIssue(int? id)
        {
            if (id == null) return NotFound();
            Issue issue = await _boardService.GetIssueById(new ServiceContext { ContextId = "TEST" }, (int)id);
            IssueViewModel issueVM = issue.EntityToViewModel();
            
            return View(issueVM);
        }
    }
}
