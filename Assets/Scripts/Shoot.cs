using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject redBullet;
    public Transform bulletPos;

    private float timer;
    public GameObject enemy;

    public bool isUpgraded = false; // Track if the gun is upgraded

    void Start()
    {
        
    }


    void Update()
    {
        //if out of range wont shoot
        float distance = Vector2.Distance(transform.position, enemy.transform.position);
        Debug.Log("Distance");

        if(distance < 8)
        {
            timer += Time.deltaTime;

            if (timer > 1)
            {
                timer = 0;
                if(isUpgraded)
                {
                    strongBullet();
                   Debug.Log("new bullet");
                }
                else
                {
                    shoot();
                }

            }
        }
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        Debug.Log("Shooting");
    }

    void strongBullet()
    {
        Instantiate(redBullet, bulletPos.position, Quaternion.identity);
        Debug.Log("Shooting strogner bu;llet");
    }
    
}
