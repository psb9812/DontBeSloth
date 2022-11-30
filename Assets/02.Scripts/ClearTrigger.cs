using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public AudioClip clearSound;
    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameManager.isClear = true;
            audio.PlayOneShot(clearSound);
        }
    }
}
