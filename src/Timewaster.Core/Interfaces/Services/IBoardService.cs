﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Timewaster.Core.Entities.Boards;
using Timewaster.Core.Entities.Projects;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Interfaces.Services
{
    public interface IBoardService
    {
        public ValueTask<IEnumerable<SprintStory>> GetSprintStories(ServiceContext context, int sprintId);
        public ValueTask<Issue> GetIssueById(ServiceContext context, int id);
        public ValueTask<Story> GetStoryById(ServiceContext context, int id);
        public ValueTask<Sprint> GetSprintById(ServiceContext context, int id);
        public ValueTask<Issue> ChangeStatusOnIssue(ServiceContext context, Issue issue, int statusId);
        public ValueTask<IEnumerable<Status>> GetStatusesBySprintId(ServiceContext context, int sprintId);
    }
}
