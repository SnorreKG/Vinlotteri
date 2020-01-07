using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float rotationSpeed;

    public bool doRot;

    public bool rotAxisX;
    public bool rotAxisY;
    public bool rotAxisZ;

    void Start()
    {
        
    }

    void Update()
    {
        if (rotAxisX == true && doRot)
            transform.Rotate(1f * rotationSpeed * Time.deltaTime, 0f, 0f, Space.World);   

        if (rotAxisY == true && doRot)
            transform.Rotate(0f, 1f * rotationSpeed * Time.deltaTime, 0f, Space.World);

        if (rotAxisZ == true && doRot)
            transform.Rotate(0f, 0f, 1f * rotationSpeed * Time.deltaTime, Space.World);
    }
}
