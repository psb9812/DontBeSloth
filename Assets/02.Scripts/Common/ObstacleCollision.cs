using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    PlayerControl playerControl;
    AudioSource audioSource;
    public AudioClip audioClip;
    private void Start()
    {
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (playerControl.isImmun)
        {
            gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
        }
        else
        {
            gameObject.GetComponent<CapsuleCollider>().isTrigger = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        audioSource.PlayOneShot(audioClip);
    }
}
