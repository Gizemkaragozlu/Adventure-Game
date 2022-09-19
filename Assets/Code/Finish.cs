using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Finish : MonoBehaviour
{
    private AudioSource finishSound;

    void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        
        if(other.gameObject.tag == "Player")
            {
                finishSound.Play();
                Invoke("ComplateLevel",2);

            }
    }
     void ComplateLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
