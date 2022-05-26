using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleCounter : MonoBehaviour
{
    public GameObject appleDisplay;
    public static int appleValue = 0;


    // Update is called once per frame
    void Update()
    {
        appleDisplay.GetComponent<Text>().text = "" + appleValue;
    }

}
