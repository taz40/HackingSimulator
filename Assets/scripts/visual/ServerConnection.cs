using UnityEngine;
using System.Collections;

public class ServerConnection : MonoBehaviour {

    public Server src;
    public Server dest;
    LineRenderer lr;

	// Use this for initialization
	void Start () {
        lr = GetComponent<LineRenderer>();
        lr.SetWidth(.01f, .01f);
        Vector3 pos = ServerMapController.serverGameObjects[src].transform.position;
        pos.z = 0;
        lr.SetPosition(0, pos);
        pos = ServerMapController.serverGameObjects[dest].transform.position;
        pos.z = 0;
        lr.SetPosition(1, pos);
        // color set
        Color start = Color.gray;
        if (src.Team == 1)
        {
            start = Color.red;
        }else if (src.Team == 2) {
            start = Color.blue;
        }

        Color end = Color.gray;
        if (dest.Team == 1)
        {
            end = Color.red;
        }
        else if (dest.Team == 2)
        {
            end = Color.blue;
        }

        lr.SetColors(start, end);
        src.RegisterServerChangedCallback(OnConnectionChanged);
        dest.RegisterServerChangedCallback(OnConnectionChanged);
    }

    void OnConnectionChanged(Server s) {
        Color start = Color.gray;
        if (src.Team == 1)
        {
            start = Color.red;
        }
        else if (src.Team == 2)
        {
            start = Color.blue;
        }

        Color end = Color.gray;
        if (dest.Team == 1)
        {
            end = Color.red;
        }
        else if (dest.Team == 2)
        {
            end = Color.blue;
        }

        lr.SetColors(start, end);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
