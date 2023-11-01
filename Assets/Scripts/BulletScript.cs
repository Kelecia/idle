using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
   public GameObject enemy;
   private Rigidbody2D rb;

   public float force;
    private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector3 direction = enemy.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

 
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>10)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            
            Destroy(gameObject);
        }
    }
}
