using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationTrigger : MonoBehaviour
{
    //Script plays animation once a player has walked into a collider and thereby trigger the animation to start.
    [SerializeField] private Animator[] myAnimationController;
    public string AnimationSet;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < myAnimationController.Length; i++)
            {
                myAnimationController[i].SetBool(AnimationSet, true);
            }
        }
    }
}
