using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    void OnCollisionEnter2D(Collision2D collision)
    {
      
            SceneManager.LoadScene(2);
            
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
     
            SceneManager.LoadScene(2);
    }

}
