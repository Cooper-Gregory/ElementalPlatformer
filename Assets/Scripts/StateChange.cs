using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChange : MonoBehaviour
{
    public StateInfo _stateInfo;
    public SpriteRenderer playerSR;
    private GameObject thisObject;

    private void Start()
    {
        thisObject = this.gameObject;
    }
    public void ColourSwap()
    {
        playerSR.color = _stateInfo.colour;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ColourSwap();
        thisObject.SetActive(false);
    }
}
