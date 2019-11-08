using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class ScoreManager : MonoBehaviour
{
    public static int score;        // The player's score.
    public GameObject player;

    Text text;                      // Reference to the Text component.
    PlayerShooting playerShoot;

    void Awake()
    {
        // Set up the reference.
        text = GetComponent<Text>();

        // Reset the score.
        score = 0;

        playerShoot = player.GetComponent<PlayerShooting>();
    }


    void Update()
    {
        if (!playerShoot) { return; }
        score = playerShoot.playerScore;

        // Set the displayed text to be the word "Score" followed by the score value.
        text.text = "Score: " + score;
    }
}