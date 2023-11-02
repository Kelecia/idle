using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    //follow player
    public GameObject player;
    public float speed = 1;


    public int maxHealth = 3;
    private int currentHealth;

    public int value = 1;


    void Start()
    {
        currentHealth = maxHealth; 
    }

 
    void Update()
    {
        //moving
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            //other.gameObject.GetComponent<EnemyAI>().currentHealth -= 10;
            TakeDamage(1);
        }
    }

    public void IncreaseDamage()
    {
       TakeDamage(6);
    }

    void OnMouseDown()
    {
        // Handle the mouse click on the enemy
        TakeDamage(1); // adjust the damage
    }


    void Die()
    {
        //  any death logic here,  death animations, giving rewards, etc.
        Destroy(gameObject);
        CoinCounter.instance.IncreaseCoins(value);
    }

   
}
