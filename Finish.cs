using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    //private AudioSource finishsound;
    private bool finishlevel = false;
    public bool key ;
    void Start()
    {
        //finishsound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Door" && !finishlevel && key)
        {
            //finishsound.Play();
            finishlevel = true;
            Invoke("CopleteLevel", 2f);
            CopleteLevel();
        }
        if (collision.gameObject.CompareTag("Key"))
        {
            
            Destroy(collision.gameObject);
            key = true;

            

        }
    }
    private void CopleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
