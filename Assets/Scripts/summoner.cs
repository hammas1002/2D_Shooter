using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summoner : Enemy
{
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    public Vector2 targetPosition;
    public Enemy enemyToSummon;
    public float timeBtwSummons;
    public float summonTime;


    new void Start()
    {
        base.Start();
        float randomX = Random.Range(xMin,xMax);
        float randomY = Random.Range(yMin, yMax);
        targetPosition = new Vector2(randomX,randomY);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player!=null)
        {
            float distance = Vector2.Distance(transform.position, targetPosition);

            if (distance > 0.5f)
            {

                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                //start running animation here
            }
            else
            {
                if (Time.time>=summonTime)
                {   //Stop Running animation.
                    //Start Summoning animation.
                    summonTime = Time.time + timeBtwSummons;
                    Summon();
                }
            }
        }
    }

    public void Summon()
    {
        Instantiate(enemyToSummon,transform.position,Quaternion.identity);
    }
}
