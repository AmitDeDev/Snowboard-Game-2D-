using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float crashReloadDelay = 0.7f;
    [SerializeField] ParticleSystem crashEffect;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            Debug.Log("Ouch, Hit my head");
            crashEffect.Play();
            Invoke("ReloadSceneOnCrash", crashReloadDelay);
        }
    }

    void ReloadSceneOnCrash()
    {
        SceneManager.LoadScene(0);
    }

}
