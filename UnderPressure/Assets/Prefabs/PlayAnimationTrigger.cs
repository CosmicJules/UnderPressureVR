using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationTrigger : MonoBehaviour
{

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
