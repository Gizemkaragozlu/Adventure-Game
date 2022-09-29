using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
   PhotonView view;
    public Rigidbody2D rb;
    private BoxCollider2D coll;
    public int jump;//Zıplamak..
    private SpriteRenderer sprite;//Sağa sola bakmak..
    private Animator anim;//Boşta durunca yapılan animasyon...
    public LayerMask jumpableGround;
    private float dirX = 0f;//Bunu yapmaya ihtiyaç yok ama zararı da yok..
    public float moveSpeed = 7f;//Koşma hızı
    //[SerializeField] private float jumpForce = 14f;//Atlama Kuvveti..
    public enum MovementState{idle, running, jumping, falling}
   public AudioSource jumpSoundEffect;
  private void  Start() 
  {
    view = GetComponent<PhotonView>();
    coll = GetComponent<BoxCollider2D>();
    sprite = GetComponent<SpriteRenderer>();
    anim = GetComponent<Animator>();
  }

    // Update is called once per frame
    void Update()
    {
      if(view.IsMine){
dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX* moveSpeed, rb.velocity.y);
       // UpdateCamera();

        if(Input.GetKeyDown("space")&& IsGrounded())//Bosluk tuşuna basınca zıpla..
        {
          jumpSoundEffect.Play();
           rb.AddForce(new Vector3(0, jump , 0));
        }
        
        UpdateAnimationState();
         }
      
    }
    void UpdateCamera(){
        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
        cam.transform.position = this.transform.position + new Vector3(0,0,-15);
     
    }
    private void UpdateAnimationState()
    {
      MovementState state;
        if(dirX > 0f)
        {
            state = MovementState.running;
            //anim.SetBool("running", true);
             sprite.flipX = false;//Sağa koşunca sağa baksın..
        }
        else if(dirX < 0f)
        {
            state = MovementState.running;
            //anim.SetBool("running", true);
            sprite.flipX = true;//Sola koşunca sola baksın..
        }
        else
        {
           state = MovementState.idle;
            //anim.SetBool("running", false);
        }
        if(rb.velocity.y > .1f)
        {
          state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1d)
        {
          state = MovementState.falling;
        }
        anim.SetInteger("state",(int)state);
    }
    private bool IsGrounded()
    {
     return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 1f, jumpableGround);
    }
    
}
