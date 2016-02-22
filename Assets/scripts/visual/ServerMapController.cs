using UnityEngine;
using System.Collections.Generic;

public class ServerMapController : MonoBehaviour {

    public Sprite serverTexture;
    ServerMap map;
    public static Dictionary<Server, GameObject> serverGameObjects;
    public Material ConnectionMat;

	// Use this for initialization
	void Start () {
        serverGameObjects = new Dictionary<Server, GameObject>();
        map = new ServerMap();
        for (int tier = 0; tier < 10; tier++) {
            for (int server = 0; server < 4; server++) {
                Server s = map.servers[tier, server];
                if (s != null) {
                    GameObject serverGO = new GameObject();
                    serverGO.name = "Server_" + tier + "_" + server;
                    serverGO.transform.position = new Vector3(tier, server, -1);
                    serverGO.transform.SetParent(transform, false);
                    serverGO.AddComponent<BoxCollider2D>();
                    MouseController serverMC = serverGO.AddComponent<MouseController>();
                    serverMC.s = s;
                    SpriteRenderer serverSR = serverGO.AddComponent<SpriteRenderer>();
                    serverSR.sprite = serverTexture;
                    if (s.Team == 1)
                    {
                        serverSR.color = Color.red;
                    }else if (s.Team == 2) {
                        serverSR.color = Color.blue;
                    }
                    serverGameObjects.Add(s, serverGO);
                    s.RegisterServerChangedCallback(onServerChanged);
                    foreach (Server conn in s.connections)
                    {
                        GameObject connectionGO = new GameObject();
                        connectionGO.name = "Connection";
                        connectionGO.transform.SetParent(serverGO.transform);
                        LineRenderer lr = connectionGO.AddComponent<LineRenderer>();
                        lr.material = ConnectionMat;
                        ServerConnection connection = connectionGO.AddComponent<ServerConnection>();
                        connection.src = s;
                        connection.dest = conn;
                    }
                }
            }
        }
	}

    void onServerChanged(Server s){
        GameObject serverGO = serverGameObjects[s];
        SpriteRenderer serverSR = serverGO.GetComponent<SpriteRenderer>();
        serverSR.color = Color.white;
        if (s.Team == 1)
        {
            serverSR.color = Color.red;
        }
        else if (s.Team == 2)
        {
            serverSR.color = Color.blue;
        }
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
