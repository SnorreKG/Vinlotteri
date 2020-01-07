using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScene : MonoBehaviour
{
  
    void Start()
    {
        
    }

 
    void Update()
    {
        
    }

    public void SwitchToGameScene()
    {
        Application.LoadLevel(0);
    }

    public void SwitchToSettingScene()
    {
        Application.LoadLevel(1);
    }
}
