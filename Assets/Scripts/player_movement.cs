using UnityEngine;

public class player_movement : MonoBehaviour
{   public float movement_speed = 5.0f;
    private Rigidbody2D player;
    Vector2 movementInput;

    private Animator player_animator;


    // Start is called before the first frame update
    void Start()
    {
        player=GetComponent<Rigidbody2D>();
        player_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   movementInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));   
        if(movementInput==Vector2.zero){
            player_animator.SetBool("isRunning",false);
        }
        else{
            player_animator.SetBool("isRunning",true);
        }    
    }
    void FixedUpdate(){
        player.velocity=movementInput*movement_speed*Time.deltaTime;
    }

    
}
