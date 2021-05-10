using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CodeBlockFunct : MonoBehaviour
{
    //Script dictates how the if statement function works, if more functions were added such as for loop they would be added here
    public string function;
    public XRSocketInteractor ifSocket1, ifSocket2, ifSocket3;
    // Start is called before the first frame update
    public bool IfStatement(double gX, double gY, double gV)
    {
        XRBaseInteractable block = ifSocket1.selectTarget;
        CodeBlockValue codeBlockValue = block.GetComponent<CodeBlockValue>();
        string val1 = codeBlockValue.value1;
        double val1doub = 0;

        XRBaseInteractable block2 = ifSocket2.selectTarget;
        codeBlockValue = block2.GetComponent<CodeBlockValue>();
        string operate = codeBlockValue.value1;

        XRBaseInteractable block3 = ifSocket3.selectTarget;
        codeBlockValue = block3.GetComponent<CodeBlockValue>();
        string val2 = codeBlockValue.value1;
        double val2doub = 0;

        if (val1 == "x")
        {
            val1doub = gX;
        }else if(val1 == "y")
        {
            val1doub = gY;
        }
        else if(val1 == "v")
        {
            val1doub = gV;
        }
        else
        {
            val1doub = System.Convert.ToDouble(val1);
        }

        if (val2 == "x")
        {
            val2doub = gX;
        }
        else if (val2 == "y")
        {
            val2doub = gY;
        }
        else if (val2 == "v")
        {
            val2doub = gV;
        }
        else
        {
            val2doub = System.Convert.ToDouble(val2);
        }


        if (operate == "==")
        {
            return (val1doub == val2doub);

        }
        else if (operate == "!=")
        {
            return (val1doub != val2doub);
        }
        else
        {
            return true;
        }
    }

}
