using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


//This script checks to make sure that the rings are in a 'end' position i.e. smallest on bottom, biggest on top
public class PuzzleLightDetect : MonoBehaviour
{
    public List<XRGrabInteractable> rings;
    public List<XRSocketInteractor> spacesL;
    public List<XRSocketInteractor> spacesC;
    public List<XRSocketInteractor> spacesR;

    public Material[] material;
    Renderer render;
    public int x;
    public bool LightEnabled;


    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        LightEnabled = false;
        render = GetComponent<Renderer>();
        render.enabled = true;
        render.sharedMaterial = material[x];

    }

    // Update is called once per frame
    void Update()
    {
        render.sharedMaterial = material[x];
        checkTowers(spacesL,spacesC,spacesR);
        

    }
    //Checks ring positions
    public void checkTowers(List<XRSocketInteractor> spaces, List<XRSocketInteractor> spaces2, List<XRSocketInteractor> spaces3)
    {
        if(spaces[0].selectTarget == rings[0] && spaces[1].selectTarget == rings[1] && spaces[2].selectTarget == rings[2] ||
            spaces2[0].selectTarget == rings[0] && spaces2[1].selectTarget == rings[1] && spaces2[2].selectTarget == rings[2] ||
            spaces3[0].selectTarget == rings[0] && spaces3[1].selectTarget == rings[1] && spaces3[2].selectTarget == rings[2])
        {
            ToggleLightOn();
        }
        else
        {
            ToggleLightOff();
        }
    }

    //This will change the material of the cube that indicates if the user has the rings in a valid end position
    public void  ToggleLightOn()
    {

            x = 1;

    }
    public void ToggleLightOff()
    {

        x = 0;

    }
}
