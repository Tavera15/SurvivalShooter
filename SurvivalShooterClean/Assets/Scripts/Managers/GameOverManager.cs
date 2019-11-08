using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth[] players;          // Reference to the players' health.

    Animator anim;                          // Reference to the animator component.

    void Awake()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if(isEveryoneDead())
        {
            TimeManager.instance.SlowTime(.3f);

            // ... tell the animator the game is over.
            anim.SetTrigger("GameOver");
        }

    }

    bool isEveryoneDead()
    {
        for (int i = 0; i < players.Length; i++)
            if (!players[i].GetComponent<PlayerHealth>().isDead)
                return false;

        return true;
    }
}