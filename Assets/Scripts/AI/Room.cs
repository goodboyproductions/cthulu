using System;
using System.Collections.Generic;
using Cthulu;
using UnityEngine;

public class Room : MonoBehaviour {
    public List<Furniture> furniture;

    [SerializeField] List<Node> nodes;
    [SerializeField] List<MonsterSpawnPoint> spawnPoints;
    public List<Portal> portals;

    void Start() {
        PathFollower.ReachNode += CheckEnter;
    }

    private void CheckEnter(Npc npc, Node node) {
        if(nodes==null || npc==null){
            Debug.Log(nodes);
            Debug.Log(npc);
            return;
        }
        if (nodes.Contains(node) & npc.CurRoom!=this) {
            npc.EnterRoom(this);
        }
    }

    public Node RandomNode() {
        return nodes.RandomItem();
    }

    public void SpawnAtRandom(Monster m) {
        MonsterSpawnPoint s = spawnPoints.RandomItem(x=>x.CanSpawn());
    }

    public void SpanwMonster(Monster m, MonsterSpawnPoint spawn) {
        spawn.Spawn(m);
    }
}