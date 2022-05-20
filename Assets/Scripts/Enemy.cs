using UnityEngine;

public class Enemy : MonoBehaviour,IDamage
{
    public int Health { set; get; }
    public Transform player;

    [SerializeField]
    protected int health;
    [SerializeField]
    protected int speed;
    [SerializeField]
    int damageAmount = 1;

    public GameObject[] dropsAvailable;
    public int pickupChance=20;

    protected virtual void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Health = health;
        
    }
    public void Damage()
    {
        Health -= damageAmount;
        if (Health <= 0)
        {
            int randomNum = Random.Range(0,101);
            if (randomNum<pickupChance)
            {
                GameObject pickup = dropsAvailable[Random.Range(0,dropsAvailable.Length)];
                Instantiate(pickup,transform.position,transform.rotation);
            }

            Destroy(this.gameObject);
        }
    }



}
