using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    public GameObject enemy;

    void Start()
    {
        
    }


    void Update()
    {
        //if out of range wont shoot
        float distance = Vector2.Distance(transform.position, enemy.transform.position);
        Debug.Log("Distance");

        if(distance < 6)
        {
            timer += Time.deltaTime;

            if (timer > 1)
            {
                timer = 0;
                shoot();
            }
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        Debug.Log("Shooting");
    }
}
