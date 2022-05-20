using UnityEngine;

public class projectile : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float lifeTime;

    public GameObject explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("projectileDestroy",lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up*speed*Time.deltaTime);
    }
    private void projectileDestroy()
    {
        Instantiate(explosionParticle,transform.position,Quaternion.identity);
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        IDamage hit = collision.GetComponent<IDamage>();
        Debug.Log(collision.tag);
        if (hit!=null)
        {
            hit.Damage();
            projectileDestroy();
        }
    }
}
