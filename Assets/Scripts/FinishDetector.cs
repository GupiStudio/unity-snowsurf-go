using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishDetector : MonoBehaviour
{
    [SerializeField] float _reloadDelay = 1f;
    [SerializeField] ParticleSystem particleEffect;
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            if (particleEffect)
                particleEffect.Play();

            Debug.Log("You finished!");
            Invoke("ReloadScene", _reloadDelay);
        }    
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
