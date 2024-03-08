using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100;


    private void Update()
    {
        onHealthZero();
    }

    public void onHealthZero()
    {
        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Norm1Damage()
    {
        enemyHealth -= 100;
    }
}
