using System;
using System.Collections.Generic;
using System.Text;

namespace ZZB.Tool.Authentication
{
    public interface ICurrentUser
    {
        int Id { get;  }

        bool IsLogin { get;  }

        string Name { get;  }

        bool HasRole { get; set; }

        bool HasClaim { get; set; }

    }
}
