using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


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
        if (Socket.selectTarget != null) {
            CodeBlockValue codeBlockValue = Socket.selectTarget.GetComponent<CodeBlockValue>();
            varVal = codeBlockValue.value1;
            textOutput.SetText(varName + " = " + varVal);
        }
        else
        {
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
