﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnemyManager : MonoBehaviour {
    Transform[] players;
    public PlayerHealth playerHealth;       // Reference to the player's heatlh.
    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 3f;            // How long between each spawn.
    public float distance = 15;             // How close the player needs to be to activate.

    void Start () {
        players = PlayerManager.instance.players;
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Spawn()
    {
        playerHealth = null;

        for(int i = 0; i < players.Length;i++)
        {
            if (!players[i].GetComponent<PlayerHealth>().isDead)
                playerHealth = players[i].GetComponent<PlayerHealth>();
        }

        if (!playerHealth) { return; }

        // If the player has no health left...
        if (playerHealth.currentHealth <= 0f)
        {
            // ... exit the function.
            return;
        }

        if(Vector3.Distance(transform.position, playerHealth.transform.position) > distance)
        {
            return;
        }

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy, transform.position, transform.rotation);
    }
}
