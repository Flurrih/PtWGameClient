using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Packets
{
    public class InitialPacket : IPacket
    {
        string token;
        public InitialPacket(PacketReader pr)
        {
            token = pr.ReadString();
            GameClient.token = token;
        }
    }
}
