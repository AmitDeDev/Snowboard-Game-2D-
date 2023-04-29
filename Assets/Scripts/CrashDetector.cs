using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float crashReloadDelay = 0.7f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashedSoundPlayed = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !hasCrashedSoundPlayed)
        {
            hasCrashedSoundPlayed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadSceneOnCrash", crashReloadDelay);
            Debug.Log("Ouch, Hit my head");
        }
    }

    void ReloadSceneOnCrash()
    {
        SceneManager.LoadScene(0);
    }

}
