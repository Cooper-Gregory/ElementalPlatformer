using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject enemy;
    public GameObject pos1;
    public GameObject pos2;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;

    public float obstacleRayDistance;
    public float characterDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pos2.transform;
        characterDirection = 0f;
    }
    private void Update()
    {
        TransformSetter();
        PlayerDetect();
    }

    private void TransformSetter()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pos2.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pos2.transform)
        {
            Flip();
            currentPoint = pos1.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pos1.transform)
        {
            Flip();
            currentPoint = pos2.transform;
        }
    }
    private void Flip()
    {
        Vector2 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pos1.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pos2.transform.position, 0.5f);
        Gizmos.DrawLine(pos1.transform.position, pos2.transform.position);
    }

    private void PlayerDetect()
    {
        RaycastHit2D hitObstacle = Physics2D.Raycast(transform.position, Vector2.right * new Vector2(characterDirection, 0f), obstacleRayDistance, LayerMask.NameToLayer("Player"));

        if(hitObstacle.collider != null)
        {
            Debug.LogWarning("Enemy detected");
            Debug.DrawRay(transform.position, Vector2.right * hitObstacle.distance * new Vector2(characterDirection, 0f), Color.red);
        }
        else
        {
            Debug.Log("No enemy in sight");
            Debug.DrawRay(transform.position, Vector2.right * hitObstacle.distance * new Vector2(characterDirection, 0f), Color.green);
        }
    }
}
