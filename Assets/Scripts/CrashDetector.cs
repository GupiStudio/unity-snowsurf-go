using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float _reloadDelay = 1f;
    [SerializeField] ParticleSystem particleEffect;
    [SerializeField] AudioClip crashSfx;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Ground"))
        {
            var playerController = FindObjectOfType<PlayerController>();

            if (playerController)
                playerController.DisableControls();
                
            var audioSource = GetComponent<AudioSource>();

            if (audioSource)
                audioSource.PlayOneShot(crashSfx);

            if (particleEffect)
                particleEffect.Play();

            Debug.Log("You died!");
            Invoke("ReloadScene", _reloadDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
