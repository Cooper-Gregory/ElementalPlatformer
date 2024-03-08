using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private KeyCode animKey;

    void Update()
    {
        AnimSet();
    }

    private void AnimSet()
    {
        if (Input.GetKeyDown(animKey))
        {
            animator.SetBool("Norm1", true);
            Debug.Log("Playing anim");
        }
        if (Input.GetKeyUp(animKey))
        {
            animator.SetBool("Norm1", false);
            Debug.Log("anim set false");
        }
    }
}
