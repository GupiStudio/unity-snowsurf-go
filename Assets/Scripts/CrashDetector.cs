using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Ground"))
        {
            Debug.Log("You died!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
