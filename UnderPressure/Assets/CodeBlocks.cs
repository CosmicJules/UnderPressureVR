using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class CodeBlocks : MonoBehaviour
{
    public List<XRSocketInteractor> blockSockets;
    public List<XRSocketInteractor> VarSockets;
    public TextMeshPro textInBlock;
    public double value;
    private double x, y;

    // Start is called before the first frame update
    void Start()
    {
        textInBlock.SetText("V =" + value);



    }


    public void checkcontents()
    {
        if (blockSockets[0].selectTarget != null)
        {
            for (int i = 0; i < blockSockets.Count; i++)
            {
                try
                {
                    x = 0;
                    y = 0;
                    value = 0;
                    XRBaseInteractable blockValRun = blockSockets[i].selectTarget;
                    CodeBlockValue codeBlockValueRun = blockValRun.GetComponent<CodeBlockValue>();
                    codeBlockValueRun.run = true;
                }
                catch
                {
                    value = value * 1;
                }
            }
            for (int i = 0; i < blockSockets.Count; i++)
            {
                try
                {


                    XRBaseInteractable blockVal = blockSockets[i].selectTarget;
                    CodeBlockFunct codeBlockFunct = blockVal.GetComponent<CodeBlockFunct>();

                    //XRBaseInteractable blockValRun = blockSockets[i].selectTarget;
                    //CodeBlockValue codeBlockValueRun = blockValRun.GetComponent<CodeBlockValue>();
                    //codeBlockValueRun.run = true;

                    if (blockVal.CompareTag("ifStatement"))
                    {
                        bool ifvalid = codeBlockFunct.IfStatement(x, y, value);
                        Debug.Log("ifvalid: " + ifvalid);

                        for (int j = i + 1; j < blockSockets.Count; j++)

                        {
                            try
                            {
                                XRBaseInteractable blockValj = blockSockets[j].selectTarget;
                                CodeBlockValue codeBlockValuej = blockValj.GetComponent<CodeBlockValue>();
                                if (blockValj.CompareTag("EndIfStatement"))
                                {
                                    break;
                                }
                                else
                                {

                                    if (blockValj != null)
                                    {
                                        codeBlockValuej.run = ifvalid;
                                    }
                                    else { Debug.Log("No Block Found... moving on"); }


                                }
                            }
                            catch
                            {
                                Debug.Log("catch : No Block Found... moving on");
                            }
                        }

                    }



                    else if (blockVal.CompareTag("Operation"))
                    {
                        CodeBlockValue codeBlockValue = blockVal.GetComponent<CodeBlockValue>();
                        string v1 = codeBlockValue.value1;
                        string fnc = codeBlockValue.function;
                        double v2 = System.Convert.ToDouble(codeBlockValue.value2);
                        bool runnable = codeBlockValue.run;
                        //Debug.Log("Runnable: " + runnable + " " + "v2: " + v2);

                        if (fnc == "+" && runnable == true)
                        {
                            value = value + v2;
                        }
                        else if (fnc == "-" && runnable == true)
                        {
                            value = value - v2;
                        }
                        else if (fnc == "*" && runnable == true)
                        {
                            value = value * v2;
                        }
                        else if (fnc == "/" && runnable == true)
                        {
                            value = value / v2;
                        }
                        else if (fnc == "=" && runnable == true)
                        {
                            value = v2;
                        }

                    }
                    else if (blockVal.CompareTag("VarBlock"))

                    {


                        VariableSetter variableSetter = blockVal.GetComponent<VariableSetter>();
                        CodeBlockValue codeBlockValue = blockVal.GetComponent<CodeBlockValue>();
                        string value1 = variableSetter.varName;

                        string function = "=";
                        string value2 = variableSetter.varVal;
                        Debug.Log("Hello DAN! " + value1);
                        bool runnable = codeBlockValue.run;



                        if (value1 == "x")
                        {
                            x = System.Convert.ToDouble(value2);
                            Debug.Log("Current Value of Global x is " + x);
                        }
                        else if (value1 == "y")
                        {
                            y = System.Convert.ToDouble(value2);
                            Debug.Log("Current Value of Global y is " + y);
                        }

                    }
                    else if (blockVal.CompareTag("VarBlockOperation"))
                    {
                        CodeBlockValue codeBlockValue = blockVal.GetComponent<CodeBlockValue>();
                        string v1 = codeBlockValue.value1;
                        string fnc = codeBlockValue.function;
                        string v2 = codeBlockValue.value2;
                        bool runnable = codeBlockValue.run;
                        double v1doub = 0;
                        double v2doub = 0;


                        if ((v1 == "x" && v2 == "y"))
                        {
                            v1doub = x;
                            v2doub = y;

                        }
                        else if (v1 == "y" && v2 == "x")
                        {
                            v1doub = y;
                            v2doub = x;
                        }
                        else
                        {

                            if ((v1 == "x" && v2 != "x"))
                            {
                                v1doub = x;
                                v2doub = System.Convert.ToDouble(v2);

                            }
                            else if (v1 != "x" && v2 == "x")
                            {
                                v1doub = System.Convert.ToDouble(v1);
                                v2doub = x;
                            }

                            if ((v1 == "y" && v2 != "y"))
                            {
                                v1doub = y;
                                v2doub = System.Convert.ToDouble(v2);

                            }
                            else if (v1 != "y" && v2 == "y")
                            {
                                v1doub = System.Convert.ToDouble(v1);
                                v2doub = y;
                            }
                        }






                        if (fnc == "+" && runnable == true)
                        {
                            value = v1doub + v2doub;
                        }
                        else if (fnc == "-" && runnable == true)
                        {
                            value = v1doub - v2doub;
                        }
                        else if (fnc == "*" && runnable == true)
                        {
                            value = v1doub * v2doub;
                        }
                        else if (fnc == "/" && runnable == true)
                        {
                            value = v1doub / v2doub;
                        }
                        else if (fnc == "=" && runnable == true)
                        {
                            value = v2doub;
                        }

                    } //else if (blockVal.CompareTag("EndIfStatement"))
                    //{
                    //    for (int j = i + 1; j < blockSockets.Count; j++)

                    //    {
                    //        XRBaseInteractable blockValj = blockSockets[j].selectTarget;
                    //        CodeBlockValue codeBlockValuej = blockValj.GetComponent<CodeBlockValue>();
                    //        codeBlockValuej.run = true;

                    //    }
                    //}
                }
                catch
                {
                    value = value * 1;
                }
                textInBlock.SetText("V =" + value);
            }
        }
        else
        {
            textInBlock.SetText("V =" + " null");
        }
    }
    // Update is called once per frame
    void Update()
    {
        //XRBaseInteractable blockSockVal1 = VarSockets[0].selectTarget;
        //XRBaseInteractable blockSockVal2 = VarSockets[1].selectTarget;
        //CodeBlockValue varCodeBlockVal1 = blockSockVal1.GetComponent<CodeBlockValue>();
        //CodeBlockValue varCodeBlockVal2 = blockSockVal2.GetComponent<CodeBlockValue>();
        //x = varCodeBlockVal1.value1;
        //y = varCodeBlockVal2.value1;
    }
}
