using System;
using System.Collections.Generic;

namespace Mod7ScaffoldDemo;

public partial class BlogMaster
{
    public int BlogId { get; set; }

    public string BlogName { get; set; } = null!;

    public string AuthorName { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
