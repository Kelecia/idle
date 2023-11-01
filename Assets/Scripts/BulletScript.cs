using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
   public GameObject enemy;
   private Rigidbody2D rb;

   public float force;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      //enemy = GameObject.FindGameObjectWithTag("Enemy");

        //set direction & velocity for bullet
        Vector3 direction = enemy.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

 
    void Update()
    {
        
    }
}
