using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float timeToDestroy = 3;
    public bool doDestroy = true;
    void Start()
    {
        if (doDestroy)
            Destroy(gameObject, timeToDestroy);
    }

    void Update()
    {
        
    }
}
