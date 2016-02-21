using UnityEngine;
using System.Collections.Generic;

public class ServerMap {

    public Server[,] servers;

    public ServerMap() {
        generateServerMap();
    }

    public void generateServerMap() {
        generateServers();
    }

    public void generateServers() {
        servers = new Server[10, 4];
        for (int tier = 0; tier < 10; tier++) {
            int numOfServers = Random.Range(1,5);
            List<int> taken = new List<int>();
            for(int server = 0; server < numOfServers; server++){
                int serverPos = Random.Range(0, 4);
                while (taken.Contains(serverPos)) {
                    serverPos = Random.Range(0, 4);
                }
                taken.Add(serverPos);
                servers[tier, serverPos] = new Server();
            }
        }

    }

}
