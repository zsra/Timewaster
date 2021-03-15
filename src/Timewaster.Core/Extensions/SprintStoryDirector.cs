using System;
using System.Collections.Generic;
using System.Text;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.Interfaces.Extensions;

namespace Timewaster.Core.Extensions
{
    public class SprintStoryDirector
    {
        private ISprintStoryBuilder _sprintStoryBuilder;

        public SprintStoryDirector(ISprintStoryBuilder sprintStoryBuilder)
        {
            _sprintStoryBuilder = sprintStoryBuilder;
        }

        public void Construct(Story story, IEnumerable<Status> statuses, IEnumerable<Issue> issues)
        {
            _sprintStoryBuilder.Story = story;
            _sprintStoryBuilder.Statuses = statuses ?? throw new NullReferenceException("statuses must be not null");
            _sprintStoryBuilder.Issues = issues ?? throw new NullReferenceException("issues must be not null");
        }
    }
}
