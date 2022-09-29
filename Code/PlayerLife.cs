using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
public class PlayerLife : MonoBehaviour
{
   private Animator anim;
   private Rigidbody2D rb;
   PhotonView view;
   public AudioSource deathSoundEffect;
    private void Start()
    {
        view = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
   private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.CompareTag("Trap") && view.IsMine)
       {
           Die();
       }
    }
    private void Die() 
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static; //Oyuncu öldüğü yerde dursun..
         anim.SetTrigger("death");
        
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//Öldükten sonra geri yaşam...
        
    }
}
