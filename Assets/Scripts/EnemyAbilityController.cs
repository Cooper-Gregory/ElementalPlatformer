using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbilityController : MonoBehaviour
{
    public GameObject parentObject;
    private SpriteRenderer thisSr; 
    private Animator animator;

    private void Start()
    {
        thisSr.color = parentObject.GetComponent<SpriteRenderer>().color;
        animator = GetComponent<Animator>();
    }

    public void FOne()
    {
        animator.SetBool("F1.1", true);
        StartCoroutine(SimpleWait());
    }

    private IEnumerator SimpleWait()
    {
        yield return new WaitForSeconds(.2f);
        animator.SetBool("F1.1", false);
    }
}
