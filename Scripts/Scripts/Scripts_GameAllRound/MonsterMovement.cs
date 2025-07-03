using UnityEngine;

public class MonsterMovement : MonoBehaviour
{

    //Links
    //https://www.youtube.com/watch?v=l7VyxIzAIAc

    public EnemyHealth enemyHealth;
    public Transform[] patrolPoints; 
    public Transform player; 
    public float moveSpeed;
    public int patrolDestination;
    private bool isFacingRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
     
        if (enemyHealth.currentHealth > 0)
        {
            
            if (patrolDestination >= 0 && patrolDestination < patrolPoints.Length)
            {
                if (patrolDestination == 0)
                {
                    transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
                    if (Vector2.Distance(transform.position, patrolPoints[0].position) < .2f && isFacingRight)
                    {
                        Flip();
                        patrolDestination = 1;
                    }
                }
                else if (patrolDestination == 1)
                {
                    transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
                    if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f && !isFacingRight)
                    {
                        Flip();
                        patrolDestination = 0;
                    }
                }
            }
            else
            {
                
                if (transform.position.x < player.position.x && !isFacingRight)
                {
                    Flip();
                }
                else if (transform.position.x > player.position.x && isFacingRight)
                {
                   Flip();
                }
            }
        }
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
