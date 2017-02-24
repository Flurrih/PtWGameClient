using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System;
using ServerData;
using Assets;
using Assets.Packets;
using System.Collections.Generic;
using Assets.Networking;

public class GameClient : MonoBehaviour {

    public static ClientSocket client;
    public static string token;
    public static PlayerData player;
    public static LoginScript loginScript { get; private set;}

    // Use this for initialization
    void Start () {
        client = new ClientSocket();
        client.Connect("192.168.0.105", 6556);
    }
    void Update()
    {
    }

    public static void SetLoginScript(LoginScript loginS)//TO RECODE!!!!!!
    {
        loginScript = loginS;
    }
    
}
