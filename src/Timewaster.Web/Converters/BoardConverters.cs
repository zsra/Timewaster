using System;
using Timewaster.Core.Entities.Boards;
using Timewaster.Web.ViewModels;

namespace Timewaster.Web.Converters
{
    public static class BoardConverters
    {
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
            };
        }

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

        private static void NullChecker(StoryViewModel viewModel, Sprint sprint)
        {
            if (viewModel == null)
                throw new ArgumentNullException($"{nameof(viewModel)} cannot be null");
            if (sprint == null)
                throw new ArgumentNullException($"{nameof(sprint)} cannot be null");
        }

        private static void NullChecker(IssueViewModel viewModel, Status status, Story story)
        {
            if(viewModel == null)
                throw new ArgumentNullException($"{nameof(viewModel)} cannot be null");
            if(status == null)
                throw new ArgumentNullException($"{nameof(status)} cannot be null");
            if(story == null)
                throw new ArgumentNullException($"{nameof(story)} cannot be null");
        }
    }
}
