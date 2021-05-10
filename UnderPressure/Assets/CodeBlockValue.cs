using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class CodeBlockValue : MonoBehaviour
{
 //This script dictates the values of some code blocks and how they are printed onto a block
    public string value1;
    public string function;
    public string value2;
    public bool run;
    public TextMeshPro textInBlock;
    

    // Start is called before the first frame update
    void Start()
    {
        if (value1 != "NA" && function != "NA" && value2 != "NA")
        {
            textInBlock.SetText("V = " + value1 + " " + function + " " + value2);
            //e.g. V=V*10
        }else if(value1 == "NA" && function == "NA" && value2 == "NA")
        {
            Debug.Log("varblock");
            //ignore printing if it is a varblock as these values are autofilled by varsetter script
        }
        else if (value1 == "NA" && function == "NA" && value2 != "NA")
        {
            textInBlock.SetText("V = " + value2);
            //V = 16
        }


        else
        {
            textInBlock.SetText(value1);
            //e.g. the values that go into the varblock (16)
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
