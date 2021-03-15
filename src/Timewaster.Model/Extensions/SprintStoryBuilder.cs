using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.Interfaces.Extensions;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Extensions
{
    public class SprintStoryBuilder : ISprintStoryBuilder
    {
        public Story Story { get; set; }
        public IEnumerable<Status> Statuses { get; set; }
        public IEnumerable<Issue> Issues { get; set; }

        public SprintStory GetResult() => new SprintStory { Story = Story, GroupOfIssues = GetGroupOfIssues() };

        private IEnumerable<(Status, List<Issue>)> GetGroupOfIssues()
        {
            List<(Status, List<Issue>)> result = new List<(Status, List<Issue>)>();
            AddStatuses(ref result);
            foreach(var (issue, item) in from Issue issue in Issues from item in from item in result
                                              where item.Item1.Id == issue.Status.Id select item select (issue, item))
            {
                item.Item2.Add(issue);
            }

            return result;
        }

        private void AddStatuses(ref List<(Status, List<Issue>)> result) => result.AddRange(from Status status in Statuses
                                                                                             select (status, new List<Issue>()));
    }
}
