using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//This script is used in order for the wall to read the variable blocks and will action on them accordingly. Will set them to Codeblock Values
public class VariableSetter : MonoBehaviour
{

    public XRSocketInteractor Socket;
    public TextMeshPro textOutput;
    public TextMeshPro varNameText;
    public string varName;
    public string varVal;
    public bool run;

    public void variableSet()
    {
        //Take value from input block
        if (Socket.selectTarget != null) {
            CodeBlockValue codeBlockValue = Socket.selectTarget.GetComponent<CodeBlockValue>();
            varVal = codeBlockValue.value1;
            textOutput.SetText(varName + " = " + varVal);
        }
        else
        {
            //If no value set in varblock
            varVal = null;
            textOutput.SetText(varName + " = " + "unassigned");
        }
    }

    void Start()
    {
        variableSet();
        textOutput.SetText(varName + " = " + "unassigned");
        varNameText.SetText(varName + " =");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
