using System;
using System.Collections.Generic;
using System.Text;
using Timewaster.Core.ValueObjects;

namespace Timewaster.Core.Extensions
{
    public static class PermissionHandler
    {
        public static bool HasPermission(ServiceContext context, string partitionKey)
        {
            return false;
        }
    }
}
