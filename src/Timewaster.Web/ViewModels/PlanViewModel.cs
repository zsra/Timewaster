using System;
using System.Collections.Generic;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Web.ViewModels
{
    public class PlanViewModel
    {
        public DateTime CreatedAt { get; set; }
        public DateTime ClosingAt { get; set; }

        public List<Status> Statuses { get; set; } = new List<Status>();
        public List<Story> Stories { get; set; } = new List<Story>();
        public List<Issue> Issues { get; set; } = new List<Issue>();

        public List<SprintStory> SprintStories { get; set; } = new List<SprintStory>();
    }
}
