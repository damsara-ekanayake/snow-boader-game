using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] float delay = 1.0f;
    [SerializeField] AudioClip crashSXF;
    bool isCrash = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" && !isCrash)
        {
            isCrash = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSXF);
            Invoke("ReloadScene", delay);
        }
    }
    
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    
}
