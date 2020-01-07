using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    public InputField lowestNumberInputField;
    public InputField highestNumberInputField;

    private string lowestNumberString;
    private string highestNumberString;

    private string highestNumberPlayerprefsCode = "HNS";
    private string lowestNumberPlayerprefsCode = "LNS";

    private void Start()
    {


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


}
