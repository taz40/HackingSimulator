using UnityEngine;
using System.Collections.Generic;
using System;

public class Server {

    Action<Server> onServerChanged;

    public List<Server> connections;

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
        connections = new List<Server>();
        Team = 0;
    }

    public void RegisterServerChangedCallback(Action<Server> cb) {
        onServerChanged += cb;
    }

    public void UnregisterServerChangedCallback(Action<Server> cb) {
        onServerChanged -= cb;
    }


}
