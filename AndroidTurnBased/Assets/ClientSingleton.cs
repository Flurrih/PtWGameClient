using UnityEngine;
using System.Collections;

public class ClientSingleton : MonoBehaviour {

    public static GameClient client;
	// Use this for initialization
	void Awake () {
        client = new GameClient();
	}
}
