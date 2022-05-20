using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_ranged : Enemy
{
    [SerializeField]
    private int stoppingDistance;

    [SerializeField]
    float timeBtwAttack;
    [SerializeField]
    float attackTime;
    public GameObject enemyBullet;
    public Transform shotPoint;

    private void Update()
    { 
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            Vector2 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            shotPoint.rotation = rotation;

            if (distance > 0.5f)
            {

                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                
                if (Time.time >= attackTime)
                {
                    attackTime = Time.time + timeBtwAttack;
                    //attack
                    Debug.Log("enemy bullet");
                    Instantiate(enemyBullet, shotPoint.position, shotPoint.rotation);
                }
            }                             
        }
    }

}
