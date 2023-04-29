using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float reLoadDelayInSeconds = 0.8f;
    [SerializeField] ParticleSystem finishEffect;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player Finished");
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", reLoadDelayInSeconds);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
