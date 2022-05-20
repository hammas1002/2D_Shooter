using UnityEngine;

public class weapon : MonoBehaviour
{
    public GameObject fireball;
    public Transform fireballSpawnPoint;
    
    [SerializeField]
    private float timeBtwShots;
    private float shotTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction =Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle-90,Vector3.forward);
        transform.rotation = rotation;
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time >= shotTime)
            {
                Instantiate(fireball, fireballSpawnPoint.position, fireballSpawnPoint.transform.rotation);
                shotTime = Time.time + timeBtwShots;
            }
        }


    }
}
