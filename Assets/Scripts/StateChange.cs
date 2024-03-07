using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChange : MonoBehaviour
{
    public StateInfo _stateInfo;
    public SpriteRenderer playerSR;
    private GameObject thisObject;
    private GameObject playerObject;

    private void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
        thisObject = this.gameObject;
    }
    public void ColourSwap()
    {
        playerSR.color = _stateInfo.colour;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == playerObject)
        {
            ColourSwap();
            thisObject.SetActive(false);
        }
        else
            return;
    }
}
