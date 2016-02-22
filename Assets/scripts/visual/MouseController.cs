using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour {

    public Server s;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnMouseDown() {
        s.Team++;
        if (s.Team == 3)
            s.Team = 0;
    }
}
