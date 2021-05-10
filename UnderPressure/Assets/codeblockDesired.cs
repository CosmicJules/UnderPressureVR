using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;


public class codeblockDesired : MonoBehaviour
{
    //Compares output value V with desired output value
    public GameObject curOut;
    public GameObject curDesOut;
    public GameObject door;
    public GameObject[] GraphCubes;

    public void checkAnswer()
    {
        GameObject blockVal = curOut;
        CodeBlocks codeBlocksOutput = blockVal.GetComponent<CodeBlocks>();
        double outputValue = codeBlocksOutput.value;

        GameObject blockDesVal = curDesOut;
        CodeBlockValue codeBlocksDesOutput = blockDesVal.GetComponent<CodeBlockValue>();
        double desOutputValue = System.Convert.ToDouble(codeBlocksDesOutput.value2);

        if (outputValue == desOutputValue)
        {
            //Open door and get necessary heart rate information
            Debug.Log("Correct Answer: door opened");
            //Destroy(door);

            GraphCubes[1].GetComponent<getHRWeb>().getHrStream();

            GraphCubes[0].GetComponent<getHR>().GetEndTime();
            
            //GraphCubes[0].GetComponent<getHR>().getGraphData();
            //GraphCubes[2].GetComponent<Window_Graph>().CreateGraph();

            door.GetComponent<MeshRenderer>().enabled = false;
            door.GetComponent<BoxCollider>().enabled = false;
            
        }
        else
        {
            Debug.Log("Incorrect");
            //if ((door.GetComponent<Renderer>().enabled == false) && (door.GetComponent<BoxCollider>().enabled == false))
            //{
            //    door.GetComponent<BoxCollider>().enabled = true;
            //    door.GetComponent<Renderer>().enabled = true;
            //}
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        checkAnswer(); 
    }

}
