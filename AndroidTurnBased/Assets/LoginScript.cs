using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;
using ServerData;
using Assets;
using Assets.Packets;

public class LoginScript : MonoBehaviour{

    public InputField loginInput;
    public InputField passwordInput;
    public Text statusText;

    // Use this for initialization
    void Start () {
        GameClient.SetLoginScript(this);
	}
	
    public void JoinGame()
    {
        LoginPacket packet = new LoginPacket(loginInput.text.ToString(), passwordInput.text.ToString());
        GameClient.client.Send(packet.Data);
    }
    public void RegisterNewAccount()
    {
        //PacketWriter pw = new PacketWriter();
        //pw.Write((ushort)Headers.Registration);
        //pw.Write(GameClient.token);
        //pw.Write(loginInput.text.ToString());
        //pw.Write(passwordInput.text.ToString());
        //GameClient.SendPacket(pw.GetBytes());
        //Debug.Log("Registration packet sent");


        Debug.Log("Token: " + GameClient.token);
    }

}
