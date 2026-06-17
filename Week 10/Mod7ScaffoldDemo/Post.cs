using System;
using System.Collections.Generic;

namespace Mod7ScaffoldDemo;

public partial class Post
{
    public int PostId { get; set; }

    public int BlogId { get; set; }

    public string Title { get; set; } = null!;

    public string? Content { get; set; }
    public 

    public virtual BlogMaster Blog { get; set; } = null!;
}
