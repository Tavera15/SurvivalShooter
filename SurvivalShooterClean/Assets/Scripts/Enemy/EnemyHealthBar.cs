using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Image healthBar;

    private float health;
    private float maxHealth;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        health = GetComponent<EnemyHealth>().currentHealth;
        maxHealth = GetComponent<EnemyHealth>().startingHealth;

        healthBar.fillAmount = (health / maxHealth);
        healthBar.color = (health <= 25 ? Color.red : Color.green);
    }
}
