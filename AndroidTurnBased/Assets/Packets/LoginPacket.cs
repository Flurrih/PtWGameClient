using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Packets.Headers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Packets
{
    class LoginPacket : IPacket
    {
        //string token;
        //string login;
        //string password;
        byte[] packet;
        public LoginPacket(string login, string password)
        {
            pw.Write((ushort)Header.Login);
            pw.Write(login);
            pw.Write(password);
            packet = pw.GetBytes();
        }

        public byte[] Data
        {
            get { return packet; }
            set { }
        }
    }

    class LoginAuthorizationPacket : IPacket
    {
        bool isAuthorized;
        public LoginAuthorizationPacket(PacketReader pr)
        {
            LoginHeader loginHeader = (LoginHeader)pr.ReadUInt16();
            switch(loginHeader)
            {
                case LoginHeader.Authorization:
                    {
                        //LoginScript.statusText.text = "Account accepted";
                        
                    }
                    break;
                case LoginHeader.NonAuthorization:
                    {
                        //LoginScript.statusText.text = "Account not accepted";
                    }
                    break;
            }
        }
    }
}
