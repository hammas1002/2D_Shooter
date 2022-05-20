using UnityEngine;

public class camera_follow : MonoBehaviour
{
    public Transform player;
    public float speed;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player!=null)
        {
            float xClamped = Mathf.Clamp(player.position.x,xMin,xMax);
            float yClamped = Mathf.Clamp(player.position.y, yMin, yMax);
            transform.position = Vector2.Lerp(transform.position,new Vector2(xClamped,yClamped),speed*Time.deltaTime);
        }
    }
}
