using System;
using System.Threading;
using System.Threading.Tasks;
using Timewaster.Core.Interfaces;

namespace Timewaster.Infrastructure.Services
{
    public class WebFileSystem : IFileSystem
    {
        public Task<bool> SavePicture(string pictureName, string pictureBase64, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
