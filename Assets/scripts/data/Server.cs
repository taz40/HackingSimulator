using UnityEngine;
using System.Collections;
using System;

public class Server {

    Action<Server> onServerChanged;

    int team;

    public int Team {
        get {
            return team;
        }
        set {
            team = value;

            if(onServerChanged != null)
                onServerChanged(this);
        }
    }

    public Server() {
        Team = UnityEngine.Random.Range(0, 3);
    }

    public void RegisterServerChangedCallback(Action<Server> cb) {
        onServerChanged += cb;
    }

    public void UnregisterServerChangedCallback(Action<Server> cb) {
        onServerChanged -= cb;
    }


}
