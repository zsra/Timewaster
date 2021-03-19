using System;
using System.Collections.Generic;
using System.Linq;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.ValueObjects;
using Timewaster.Web.ViewModels;

namespace Timewaster.Web.Converters
{
    public static class BoardConverters
    {
        #region Story converters
        public static Story ViewModelToEntity(this StoryViewModel viewModel, Sprint sprint)
        {
            NullChecker(viewModel, sprint);
            return new Story
            {
                Id = (int)viewModel.Id,
                PartitionKey = viewModel.PartitionKey,
                Name = viewModel.Name,
                Description = viewModel.Description,
                Sprint = sprint,
                IsClosed = viewModel.IsClosed
            };
        }

        public static StoryViewModel EntityToViewModel(this Story story)
        {
            if(story == null)
                throw new ArgumentNullException($"{nameof(story)} cannot be null");

            return new StoryViewModel
            {
                Id = story.Id,
                Description = story.Description,
                IsClosed = story.IsClosed,
                Name = story.Name,
                PartitionKey = story.PartitionKey,
                SprintId = story.Sprint.Id
            };
        }

        private static void NullChecker(StoryViewModel viewModel, Sprint sprint)
        {
            if (viewModel == null)
                throw new ArgumentNullException($"{nameof(viewModel)} cannot be null");
            if (sprint == null)
                throw new ArgumentNullException($"{nameof(sprint)} cannot be null");
        }
        #endregion

        #region Issue converters
        public static Issue ViewModelToEntity(this IssueViewModel viewModel, Status status, Story story)
        {
            NullChecker(viewModel, status, story);
            return new Issue
            {
                Id = (int)viewModel.Id,
                PartitionKey = viewModel.PartitionKey,
                Title = viewModel.Title,
                Description = viewModel.Description,
                Status = status,
                Story = story
            };
        }

        public static IssueViewModel EntityToViewModel(this Issue issue)
        {
            if(issue == null)
                throw new ArgumentNullException($"{nameof(issue)} cannot be null");

            return new IssueViewModel
            {
                Id = issue.Id,
                Description = issue.Description,
                PartitionKey = issue.PartitionKey,
                SprintId = issue.Story.Sprint.Id,
                StatusId = issue.Status.Id,
                StoryId = issue.Story.Id,
                Title = issue.Title
            };
        }

        private static void NullChecker(IssueViewModel viewModel, Status status, Story story)
        {
            if (viewModel == null)
                throw new ArgumentNullException($"{nameof(viewModel)} cannot be null");
            if (status == null)
                throw new ArgumentNullException($"{nameof(status)} cannot be null");
            if (story == null)
                throw new ArgumentNullException($"{nameof(story)} cannot be null");
        }
        #endregion

        #region Sprint converters
        public static BoardViewModel EntityToViewModel(this Sprint sprint, IEnumerable<SprintStory> sprintStories, IEnumerable<Status> statuses)
        {
            NullChecker(sprint, sprintStories, statuses);
            return new BoardViewModel
            {
                Sprint = sprint,
                Rows = sprintStories,
                Statuses = statuses
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
