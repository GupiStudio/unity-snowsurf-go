using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float _reloadDelay = 1f;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Ground"))
        {
            Debug.Log("You died!");
            Invoke("ReloadScene", _reloadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
