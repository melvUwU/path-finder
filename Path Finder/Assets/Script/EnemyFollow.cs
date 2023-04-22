using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform[] players;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        enemy.destination = players[i].position;
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(players[i].position);
    }
}
