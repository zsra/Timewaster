using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Projects;
using Timewaster.Core.Interfaces.Services;
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

        public async Task<IActionResult> Index()
        {
            BoardViewModel viewModel = new BoardViewModel {
              
            };
            return View(viewModel);
        }
    }
}
