using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Linq;

//This script is used in order to grab all the data required from the web application in the form of a large string

public class getHRWeb : MonoBehaviour
{
    public string hrDT;

    // Start is called before the first frame update
    public void getHrStream()
    {
        StartCoroutine(GetText());
    }


    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get("http://192.168.0.36:5000/return");
        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            
            hrDT = www.downloadHandler.text;
            Debug.Log(hrDT);

        }
    }
}
