using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class CodeBlockValue : MonoBehaviour
{
 
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
        }else if(value1 == "NA" && function == "NA" && value2 == "NA")
        {
            Debug.Log("varblock");
        }
        else if (value1 == "NA" && function == "NA" && value2 != "NA")
        {
            textInBlock.SetText("V = " + value2);
        }


        else
        {
            textInBlock.SetText(value1);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
