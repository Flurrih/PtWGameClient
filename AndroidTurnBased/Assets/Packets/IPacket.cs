using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Packets
{
    public abstract class IPacket
    {
        protected PacketWriter pw = new PacketWriter();
    }
}
