﻿using Assets.Packets;
using Assets.Packets.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Networking
{
    public class PacketHandler
    {
        public static void Handle(byte[] packet)
        {
            PacketReader pr = new PacketReader(packet);
            Header header = (Header)pr.ReadUInt16();
            Debug.Log(DateTime.Now + " | Received packet: " + header);

            switch (header)
            {
                case Header.Init:
                    {
                        InitialPacket pc = new InitialPacket(pr);
                    }
                    break;
                case Header.Login:
                    {
                        LoginAuthorizationPacket pc = new LoginAuthorizationPacket(pr);
                    }
                    break;
            }
        }
    }
}