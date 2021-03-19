using System;
using System.Collections.Generic;
using System.Linq;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.ValueObjects;
using Timewaster.Web.ViewModels;

namespace Timewaster.Web.Converters
{
    public static class PlansConverters
    {
        #region Sprint converters
        public static PlanViewModel EntityToViewModel((Sprint sprint, IEnumerable<SprintStory> sprintStories) board, IEnumerable<Status> statuses)
        {
            NullChecker(board.sprint, board.sprintStories, statuses);
            return new PlanViewModel
            {
                Sprint = board.sprint,
                SprintStories = new List<SprintStory>(board.sprintStories),
                Statuses = new List<Status>(statuses)
            };
        }

        private static void NullChecker(Sprint sprint, IEnumerable<SprintStory> sprintStories, IEnumerable<Status> statuses)
        {
            if (sprint == null)
                throw new ArgumentNullException($"{nameof(sprint)} cannot be null");
            if (sprintStories?.Any() == false)
                throw new ArgumentNullException($"{nameof(sprintStories)} cannot be null");
            if (statuses?.Any() == false)
                throw new ArgumentNullException($"{nameof(statuses)} cannot be null");
        }
        #endregion
    }
}
