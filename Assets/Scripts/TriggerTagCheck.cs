using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTagCheck : MonoBehaviour
{
    private bool isDone;

    public GameObject gameManager;

    public int tagsToCheck = 4;
    private int tagsChecked;
    public List<string> tagsThatChecks = new List<string>();
    void Start()
    {
        tagsChecked = 0;
        isDone = false;
    }

    void Update()
    {
        if (!isDone)
            if (tagsChecked >= tagsToCheck)
            {
                isDone = true;
                gameManager.GetComponent<Info>().StartRound();
            }
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < tagsThatChecks.Count; i++)
        {
            if(other.tag == tagsThatChecks[i])
            {
                tagsChecked++;
            }
        }
    }
}
