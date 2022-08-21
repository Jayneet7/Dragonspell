using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{
    public string theName;
    public GameObject inputField;
    public GameObject textDisply;

    public void Storename()
    {
        theName = inputField.GetComponent<Text>().text;
        textDisply.GetComponent<Text>().text = "WElcome" + theName + "ARe"; 

    }
}
