using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
using ServerData;
using Assets;
using Assets.Packets;

public class LoginScript : MonoBehaviour {

    public InputField loginInput;
    public InputField passwordInput;
    public Text statusText;
    

    // Use this for initialization
    void Start () {
	}
	
    public void JoinGame()
    {
        PacketWriter pw = new PacketWriter();
        pw.Write((ushort)Headers.Login);
        Debug.Log(GameClient.id);
        pw.Write(GameClient.id);
        pw.Write(loginInput.text.ToString());
        pw.Write(passwordInput.text.ToString());
        GameClient.SendPacket(pw.GetBytes());
        Debug.Log("Login packet sent");
    }
    public void RegisterNewAccount()
    {
        PacketWriter pw = new PacketWriter();
        pw.Write((ushort)Headers.Registration);
        pw.Write(GameClient.id);
        pw.Write(loginInput.text.ToString());
        pw.Write(passwordInput.text.ToString());
        GameClient.SendPacket(pw.GetBytes());
        Debug.Log("Registration packet sent");
    }


}
