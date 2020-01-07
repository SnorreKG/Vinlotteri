using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRegistration : MonoBehaviour
{

    private GameObject gameManager;
    private Info gameManagerInfo;

    public int _number;

    private bool isRegistered;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameManagerInfo = gameManager.GetComponent<Info>();

        isRegistered = false;
    }

  
    void Update()
    {
        if (isRegistered)
        {
            FaceCamera();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Detection Point")
        {
            SendInfo();
        }
    }


    private void SendInfo()
    {
        gameManagerInfo.GetNumber(_number);
        isRegistered = true;
        //RemoveBall();
    }

    private void RemoveBall()
    {
        Destroy(gameObject, 3);
    }

    private void FaceCamera()
    {
        Quaternion _currentRotation = transform.rotation;
        transform.rotation = Quaternion.Slerp(_currentRotation, Quaternion.Euler(-90f, 0f, 0f), Time.deltaTime);
    }


}
