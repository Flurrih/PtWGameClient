//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using UnityEngine;

//namespace Assets.Packets
//{
//    public static class PacketManager
//    {
//        public static void Unpack(byte[] data)
//        {
//            PacketReader pr = new PacketReader(data);
//            Headers header = (Headers)pr.ReadUInt16();
//            switch (header)
//            {
//                case Headers.Login:
//                    LoginHeader loginHeader = (LoginHeader)pr.ReadUInt16();
//                    switch (loginHeader)
//                    {
//                        case LoginHeader.Authorization:
//                            {
//                                Debug.Log("Login and password correct. Authorizated");
//                            }

//                            break;
//                        case LoginHeader.NonAuthorization:
//                            {
//                                Debug.Log("Login and password incorrect. Not authorizated");
//                            }
//                            break;
//                    }
//                    break;
//                case Headers.Connection:
//                    {
//                        string token = pr.ReadString();
//                        GameClient.token = token;
//                        Debug.Log("Client ID: " + GameClient.token);
//                    }
//                    break;
//                case Headers.Player:
//                    {
//                        PlayerHeader playerHeader = (PlayerHeader)pr.ReadInt16();
//                        switch(playerHeader)
//                        {
//                            case PlayerHeader.BasicData:
//                                {
//                                    int id = pr.ReadInt16();
//                                    string userName = pr.ReadString();

//                                    GameClient.id = id;
//                                    GameClient.userName = userName;

//                                    Debug.Log("Player received id: " + GameClient.id + " and username: " + GameClient.userName);
//                                }
//                                break;
//                        }
//                    }
//                    break;
//            }
//        }
//    }
//}
