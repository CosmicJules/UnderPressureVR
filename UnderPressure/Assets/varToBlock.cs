using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class varToBlock : MonoBehaviour
{

    public XRGrabInteractable block;

    // Start is called before the first frame update
    void Start()
    {
        VariableSetter variableSetter = block.GetComponent<VariableSetter>();
        string val1 = variableSetter.varName;
        string function = "=";
        //string value2 = variableSetter.varVal;
        bool run = true;
    }



    // Update is called once per frame
    void Update()
    {

    }
}
