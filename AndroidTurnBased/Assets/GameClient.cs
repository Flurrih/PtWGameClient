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

public class GameClient : MonoBehaviour {

    public static Socket master;
    public static string _name;
    public static string id;

    private static IPEndPoint ip;

    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(transform.gameObject);

        master = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        ip = new IPEndPoint(IPAddress.Parse(GetIPAddress()), 8888);
        try
        {
            master.Connect(ip);
            if (master.Connected)
            {
                Debug.Log("Conncted to the server");
            }
            master.Blocking = false;
        }
        catch
        {
            Debug.Log("Could not connect to the host");
        }
        
    }
    void Update()
    {
        ReceivePacket();
    }
    

    public static void ConnectToServer()
    {
        if (master.Connected != true)
        {
            try
            {
                master.Connect(ip);
                if (master.Connected)
                    Debug.Log("Conncted to the server");
            }
            catch
            {
                Debug.Log("Could not connect to the host");
            }
        }
    }

    public static void SendPacket(byte[] data)
    {
        if(master.Connected)
            master.Send(data);
    }

    public void ReceivePacket()
    {
        byte[] Buffer;
        int readBytes;

        try
        {
                Buffer = new byte[master.SendBufferSize];
                readBytes = master.Receive(Buffer);

                if (readBytes > 0)
                {
                    PacketManager.Unpack(Buffer);
                }
        }
        catch { }

    }

    public static string GetIPAddress()
    {
        IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());

        foreach (IPAddress i in ips)
        {
            if (i.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                return i.ToString();
        }

        return "127.0.0.1";
    }
}
