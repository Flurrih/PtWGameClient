using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Packets
{
    public enum Headers : ushort
    {
        Login,
        Registration,
        Connection,
        Player
    }

    public enum LoginHeader : ushort
    {
        Authorization,
        NonAuthorization
    }

    public enum PlayerHeader : ushort
    {
        BasicData
    }
}
