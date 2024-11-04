using System;
using System.Collections.Generic;

namespace WOD.WebUI;

public partial class Admin
{
    public long Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;
}
