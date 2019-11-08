using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;               // Reference to the player's position.
    PlayerHealth playerHealth;             // Reference to the player's health.
    EnemyHealth enemyHealth;               // Reference to this enemy's health.
    UnityEngine.AI.NavMeshAgent nav;       // Reference to the nav mesh agent.


    void Awake()
    {
        // Set up the references.
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = targetClosestPlayer();
    }


    void Update()
    {
        player = targetClosestPlayer();
        if (!player) { return; }

        playerHealth = player.GetComponent<PlayerHealth>();

        // If the enemy and the player have health left...
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            // ... set the destination of the nav mesh agent to the player.
            nav.SetDestination(player.position);
        }
        // Otherwise...
        else
        {
            // ... disable the nav mesh agent.
            nav.enabled = false;
        }
    }

    Transform targetClosestPlayer()
    {
        Transform[] players = PlayerManager.instance.players;
        List<Transform> alivePlayers = new List<Transform>();

        for(int i = 0; i < players.Length; i++)
        {
            if (!players[i].GetComponent<PlayerHealth>().isDead)
                alivePlayers.Add(players[i]);
        }

        if(alivePlayers.Count == 0) { return null; }
        if(alivePlayers.Count == 1) { return alivePlayers[0]; }

        int closestIndex = 0;
        float closeBy = Vector3.Distance(this.transform.position, alivePlayers[0].transform.position);

        for (int i = 1; i < alivePlayers.Count; i++)
        {
            float newDistance = Vector3.Distance(this.transform.position, alivePlayers[i].transform.position);

            if(newDistance < closeBy)
            {
                closeBy = newDistance;
                closestIndex = i;
            }
        }

        return players[closestIndex];
    }
}