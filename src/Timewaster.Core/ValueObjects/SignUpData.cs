using System;
using System.Collections.Generic;
using System.Text;

namespace Timewaster.Core.ValueObjects
{
    public struct SignUpData
    {
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}
