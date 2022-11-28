using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    private bool isBackMode = false;
    public Transform frontCamPosition;
    public Transform backCamPosition;

    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isBackMode)
            {
                BackCamMove();
            }
            else
            {
                FrontCamMove();
            }
            
        }
    }

    public void FrontCamMove()
    {
        isBackMode = false;
        StartCoroutine(CamMoving(isBackMode));
        Camera.main.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void BackCamMove()
    {
        isBackMode = true;
        StartCoroutine(CamMoving(isBackMode));
        Camera.main.transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    IEnumerator CamMoving(bool isback)
    {
        float currentTime = 0f;
        float lerpTime = 0.5f;
        float percent = 0f;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / lerpTime;

            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position,
                isback ? backCamPosition.position : frontCamPosition.position,
                percent);

            yield return null;
        }
    }
}
