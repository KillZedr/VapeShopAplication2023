using System;
using System.Collections.Generic;

namespace VSA.Domain;
public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;
    public string Email { get; set; }
    public string HashPassvord { get; set; }
}
