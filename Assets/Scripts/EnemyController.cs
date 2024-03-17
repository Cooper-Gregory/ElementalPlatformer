using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public StateInfo element;

    private EnemyAbilityController _enemyAbilityController;

    public GameObject pos1;
    public GameObject pos2;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;

    public float obstacleRayDistance;
    public float characterDirection;

    private SpriteRenderer body;
    private SpriteRenderer eyes;



    private void Start()
    {
        _enemyAbilityController = GetComponentInChildren<EnemyAbilityController>();
        //Setting colour of body to element
        body = GetComponent<SpriteRenderer>();
        body.color = element.colour;
        //Finding eyes for colour changes
        eyes = GameObject.Find("Eyes").GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        //Setting initial point for enemy to move to
        currentPoint = pos2.transform;
        characterDirection = 1f;
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
        else if(currentPoint == pos1.transform)
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
        characterDirection *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pos1.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pos2.transform.position, 0.5f);
        Gizmos.DrawLine(pos1.transform.position, pos2.transform.position);
    }

    private void PlayerDetect()
    {
        RaycastHit2D hitObstacle = Physics2D.Raycast(transform.position, Vector2.right * characterDirection, obstacleRayDistance, LayerMask.GetMask("Player"));

        if (hitObstacle.collider != null)
        {
            // Player detected
            Debug.DrawRay(transform.position, hitObstacle.distance * Vector2.right, Color.red);
            eyes.color = Color.red;
            PlayerDamage();
        }
        else
        {
            // No player in sight
            Debug.DrawRay(transform.position, obstacleRayDistance * Vector2.right, Color.green);
            eyes.color = Color.black;
        }
    }

    private void PlayerDamage()
    {
        if(element.iD == 0)
        {
            _enemyAbilityController.FOne();
        }
        else if (element.iD == 1)
        {

        }
        else if (element.iD == 2)
        {

        }
        else if (element.iD == 3)
        {

        }
    }
}
