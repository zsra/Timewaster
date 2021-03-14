using System.Collections.Generic;

namespace Timewaster.Core.Entities.Boards
{
    public class Status : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Sprint> Sprints { get; set; }
    }
}
