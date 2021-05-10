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

     //Ensures user can only place ring on base or if there is a ring already beneath it
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


    //Ensures that user can only take a ring if it is at the base or has no rings on top of it

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


}
