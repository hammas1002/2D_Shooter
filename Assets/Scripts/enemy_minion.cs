using UnityEngine;
using System.Collections;

public class enemy_minion : Enemy
{

    [SerializeField]
    private int stoppingDistance;


    [SerializeField]
    float attackSpeed = 5f;
    [SerializeField]
    float timeBtwAttack;
    [SerializeField]
    float attackTime;

    private void Update()
    {
        
        if (player!=null)
        {
           
            float distance = Vector2.Distance(transform.position, player.position);
           
            if (distance>stoppingDistance)
            {
                
                transform.position = Vector2.MoveTowards(transform.position,player.position,speed*Time.deltaTime);
            }
            else
            {
                if (Time.time>=attackTime)
                {
                    StartCoroutine(Attack());
                    attackTime = Time.time + timeBtwAttack;
                }
                
            }
        }
    }
    IEnumerator Attack()
    {
        
        
        transform.position = Vector2.Lerp(transform.position, player.position, attackSpeed * Time.deltaTime);
        
        player.GetComponent<player>().Damage();
        yield return null;
    }

}
