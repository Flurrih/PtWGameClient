using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Packets.Headers
{
    enum Header : ushort
    {
        Init,
        Login,
        Chat
    }

    enum LoginHeader : ushort
    {
        Authorization,
        NonAuthorization
    }
}
