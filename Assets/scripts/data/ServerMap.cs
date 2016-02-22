using UnityEngine;
using System.Collections.Generic;

public class ServerMap {

    public Server[,] servers;

    public ServerMap() {
        generateServerMap();
    }

    public void generateServerMap() {
        generateServers();
        generateServerConnections();
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

    public int countServersInTier(int tier) {
        int numberOfServers = 0;
        for (int i = 0; i < 4; i++) {
            if (servers[tier, i] != null)
                numberOfServers++;
        }
        return numberOfServers;
    }

    public void generateServerConnections() {
        for (int tier = 0; tier < 9; tier++) {
            for (int server = 0; server < 4; server++) {
                Server s = servers[tier, server];
                if (s != null) {
                    int numberOfServersInNextTier = countServersInTier(tier + 1);
                    int numOfConnections = Random.Range(1, numberOfServersInNextTier+1);
                    List<int> taken = new List<int>();
                    for (int connection = 0; connection < numOfConnections; connection++) {
                        int connectedServer = Random.Range(0, 4);
                        while (taken.Contains(connectedServer) || servers[tier+1, connectedServer] == null) {
                            connectedServer = Random.Range(0, 4);
                        }
                        s.connections.Add(servers[tier+1, connectedServer]);
                        taken.Add(connectedServer);
                    }
                }
            }
        }
    }

}
