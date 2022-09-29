using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public AudioSource collectionSoundEffect;
    
private void  OnTriggerEnter2D(Collider2D collision) 
 {
  
  if(collision.gameObject.CompareTag("Cherry"))
  {
    collectionSoundEffect.Play();
    Destroy(collision.gameObject);
  }    
 
 }

}
