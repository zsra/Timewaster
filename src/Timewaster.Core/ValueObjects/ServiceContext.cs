using System.Collections.Generic;

namespace Timewaster.Core.ValueObjects
{
    public struct ServiceContext
    {
        public string ContextId { get; set; }
        public string UserId { get; set; }
        public IEnumerable<string> PartitionKeys { get; set; }
    }
}
