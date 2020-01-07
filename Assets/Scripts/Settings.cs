using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Toggle autoStartToggle;
    private bool autoStartIsOn;
    private int autoStartIsOnInt;
    private string autoStartPlayerprefsCode = "AST";


    public InputField lowestNumberInputField;
    public InputField highestNumberInputField;

    private string lowestNumberString;
    private string highestNumberString;

    private string highestNumberPlayerprefsCode = "HNS";
    private string lowestNumberPlayerprefsCode = "LNS";

    private void Start()
    {
        autoStartIsOnInt = PlayerPrefs.GetInt(autoStartPlayerprefsCode);
        if (autoStartIsOnInt == 1)
        {
            autoStartIsOn = true;
        }
        else if (autoStartIsOnInt == 0)
        {
            autoStartIsOn = false;
        }
        autoStartToggle.isOn = autoStartIsOn;


        lowestNumberString = PlayerPrefs.GetString(lowestNumberPlayerprefsCode);
        highestNumberString = PlayerPrefs.GetString(highestNumberPlayerprefsCode);

        lowestNumberInputField.text = lowestNumberString;
        highestNumberInputField.text = highestNumberString;
    }
    void Update()
    {
        
    }

    public void ReciveStringMinimum()
    {
        lowestNumberString = lowestNumberInputField.text;
        PlayerPrefs.SetString(lowestNumberPlayerprefsCode, lowestNumberString);
    }

    public void ReciveStringMaximum()
    {
        highestNumberString = highestNumberInputField.text;
        PlayerPrefs.SetString(highestNumberPlayerprefsCode, highestNumberString);
    }

    public void ReciveAutoStartToggle()
    {
        autoStartIsOn = autoStartToggle.isOn;
        if(autoStartIsOn == true)
        {
            autoStartIsOnInt = 1;
        }
        else if (autoStartIsOn == false)
        {
            autoStartIsOnInt = 0;
        }
        PlayerPrefs.SetInt(autoStartPlayerprefsCode, autoStartIsOnInt);
    }

}
