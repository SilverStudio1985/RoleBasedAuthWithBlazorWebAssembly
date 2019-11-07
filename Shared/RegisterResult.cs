using System.Collections.Generic;

namespace RoleBasedAuthWithBlazorWebAssembly.Shared
{
    public class RegisterResult
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
