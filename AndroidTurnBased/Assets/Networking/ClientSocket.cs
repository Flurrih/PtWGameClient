﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

namespace Assets.Networking
{
    public class ClientSocket
    {
        public Socket _socket;
        private byte[] _buffer;

        public ClientSocket()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Connect(string ipAddress, int port)
        {
            _socket.BeginConnect(new IPEndPoint(IPAddress.Parse(ipAddress), port), ConnectCallback, null);

        }

        private void ConnectCallback(IAsyncResult result)
        {
            if (_socket.Connected)
            {
                Debug.Log("Connected to the server!");
                _buffer = new byte[1024];
                _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallback, null);
            }
            else
                Debug.Log("Could not connect");
        }

        private void ReceiveCallback(IAsyncResult result)
        {
            try
            {
                if (_socket.Connected)
                {
                    int bufLength = _socket.EndReceive(result);
                    byte[] packet = new byte[bufLength];
                    Array.Copy(_buffer, packet, packet.Length);

                    PacketHandler.Handle(packet);

                    _buffer = new byte[1024];
                    _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallback, null);
                }
            }
            catch (Exception ex)
            {
            }


        }

        public void Send(byte[] data)
        {
            if (_socket.Connected)
                _socket.Send(data);
        }
    }
}

