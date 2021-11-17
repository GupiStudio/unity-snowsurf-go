using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishDetector : MonoBehaviour
{
    [SerializeField] float _reloadDelay = 1f;
    [SerializeField] ParticleSystem particleEffect;
    [SerializeField] string _nextScene;
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            var audioSource = GetComponent<AudioSource>();

            if (audioSource)
                audioSource.Play();

            if (particleEffect)
                particleEffect.Play();

            Invoke("LoadNextScene", _reloadDelay);
        }    
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(_nextScene);
    }
}
