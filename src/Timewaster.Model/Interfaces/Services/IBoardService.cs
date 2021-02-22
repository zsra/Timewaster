using System.Collections.Generic;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Interfaces.Services
{
    public interface IBoardService
    {
        public IEnumerable<Row> GetRows();
    }
}
