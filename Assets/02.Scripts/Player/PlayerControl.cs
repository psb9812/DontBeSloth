using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Camera mainCam;
    bool isPlayer;
    RaycastHit hit;
    public Rigidbody pelvis;
    Vector3 torque;
    float rotForce = 8f;
    public bool isImmun = false;

    public GameObject[] hinges;
    
    AudioSource playerAudio;
    public AudioClip turnSound;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        torque = new Vector3(0, 20, -30f) * rotForce;
        this.transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

            isPlayer = Physics.Raycast(ray, out hit, 30f, LayerMask.GetMask("Player"));
            Debug.DrawRay(ray.origin, ray.direction * 20, Color.black, 5f);

            if (isPlayer)
            {
                ObjectMove();
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ObjectDrop();
        }
        if (isImmun)
        {
            Debug.Log("immun");
        }

    }

    private void ObjectMove()
    {
        pelvis.AddForce(transform.InverseTransformDirection(torque));
    }

    private void ObjectDrop()
    {
        foreach(GameObject hinge in hinges)
        {
            hinge.SetActive(false);
        }
        playerAudio.PlayOneShot(turnSound);
    }

    


    
}
