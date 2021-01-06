using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class RingPositions : MonoBehaviour
{
    public List<XRGrabInteractable> rings;

    public List<XRSocketInteractor> spacesL;
    public List<XRSocketInteractor> spacesC;
    public List<XRSocketInteractor> spacesR;

    private XRBaseInteractable lockedObject1;
    private XRBaseInteractable lockedObject2;
    private XRBaseInteractable lockedObject3;
    private XRBaseInteractable lockedObject4;
    private XRBaseInteractable lockedObject5;
    private XRBaseInteractable lockedObject6;
    private XRBaseInteractable lockedObject7;
    private XRBaseInteractable lockedObject8;
    private XRBaseInteractable lockedObject9;
    public LayerMask Ungrabbable;
    public LayerMask grabbable;
    public LayerMask disable;
    public LayerMask enable;
    public LayerMask noRing2;
    public LayerMask noRing3;
    public LayerMask noRings;

    void Update()
    {
        placeOnBottom(spacesL);
        placeOnBottom(spacesC);
        placeOnBottom(spacesR);
        takeFromTop(spacesL);
        takeFromTop(spacesC);
        takeFromTop(spacesR);
    }

    //public void validPlacement(List<XRSocketInteractor> spaces)
    //{
    //    if (spaces[0].selectTarget == rings[0])
    //    {
    //        spaces[1].interactionLayerMask = noRings;
    //        spaces[2].interactionLayerMask = noRings;
    //    }

    //}

    public void placeOnBottom(List<XRSocketInteractor> spaces)
    {
        if (spaces[0].selectTarget == null && spaces[1].selectTarget == null && spaces[2].selectTarget == null)
        {
            spaces[0].interactionLayerMask = disable;
            spaces[1].interactionLayerMask = disable;
            spaces[2].interactionLayerMask = enable;

        } else if (spaces[0].selectTarget == null && spaces[1].selectTarget == null && spaces[2].selectTarget != null)
        {
            spaces[0].interactionLayerMask = disable;
            spaces[1].interactionLayerMask = enable;
            spaces[2].interactionLayerMask = enable;
        }
        else
        {
            spaces[0].interactionLayerMask = enable;
            spaces[1].interactionLayerMask = enable;
            spaces[2].interactionLayerMask = enable;
        }

    }




    public void takeFromTop(List<XRSocketInteractor> spaces)
    {
        if(spaces[0].selectTarget != null || spaces[1].selectTarget != null || spaces[2].selectTarget != null)
        {
            if (spaces[0].selectTarget == null && spaces[1].selectTarget != null && spaces[2].selectTarget != null)
            {
                spaces[1].selectTarget.interactionLayerMask = grabbable;
                spaces[2].selectTarget.interactionLayerMask = Ungrabbable;
            }
            else if (spaces[0].selectTarget == null && spaces[1].selectTarget == null && spaces[2].selectTarget != null)
            {
                spaces[2].selectTarget.interactionLayerMask = grabbable;
            }
            else
            {
                spaces[0].selectTarget.interactionLayerMask = grabbable;
                spaces[1].selectTarget.interactionLayerMask = Ungrabbable;
                spaces[2].selectTarget.interactionLayerMask = Ungrabbable;
            }
        }
    }


    //public void CheckAnswer()
    //{

    //    //proxRing1 = Vector3.Distance(rings[0].transform.position, spaces[0].transform.position);
    //    //proxRing2 = Vector3.Distance(rings[1].transform.position, spaces[1].transform.position);
    //    //proxRing3 = Vector3.Distance(rings[2].transform.position, spaces[2].transform.position);

    //    //if (proxRing1 == 0 && proxRing2 == 0 && proxRing3 == 0)
    //    //{

    //    //    Debug.Log("WOOOOHOOOOO");
    //    //}
    //    //else
    //    //{
    //    //    Debug.Log("BOOOOOOOOOOOO "+ proxRing1 +" "+ proxRing2 +" "+ proxRing3);
    //    //}


    //    lockedObject1 = spaces[0].selectTarget;
    //    lockedObject2 = spaces[1].selectTarget;
    //    lockedObject3 = spaces[2].selectTarget;
    //    lockedObject4 = spaces[3].selectTarget;
    //    lockedObject5 = spaces[4].selectTarget;
    //    lockedObject6 = spaces[5].selectTarget;
    //    lockedObject7 = spaces[6].selectTarget;
    //    lockedObject8 = spaces[7].selectTarget;
    //    lockedObject9 = spaces[8].selectTarget;

    //    if (lockedObject1 == rings[0] && lockedObject2 == rings[1] && lockedObject3 == rings[2])
    //    {

    //        Debug.Log("Correct Position");
    //    }
    //    else if (lockedObject4 == rings[0] && lockedObject5 == rings[1] && lockedObject6 == rings[2])
    //    {

    //        Debug.Log("Correct Position 2");
    //    }


    //    else if (lockedObject7 == rings[0] && lockedObject8 == rings[1] && lockedObject9 == rings[2])
    //    {

    //        Debug.Log("Correct Position 3");
    //    }
    //    else
    //    {
    //        Debug.Log("invalid/incorrect position");
    //        for (int i = 0; i < 9; i++)
    //        {

    //            Debug.Log("item in position " + i +" is " +spaces[i].selectTarget );

    //        }
    //    }
    //}
}
