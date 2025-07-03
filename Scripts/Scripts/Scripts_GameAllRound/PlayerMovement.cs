using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //Links
    //https://www.youtube.com/watch?v=P_6W-36QfLA
    //https://www.youtube.com/watch?v=ux80fiJshsc
    //https://www.youtube.com/watch?v=ObMK6jUsWPE
    
    

    private Rigidbody2D rb;


    private float Move;

    public float Speed;

    public float jump;

    bool grounded;

    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;

    private Animator anim;
    private bool isFacingRight;

    public GameObject attackPoint;
    public float radius;
    public LayerMask enemies;

    public float damage;

    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isFacingRight = true;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<PlayerHealth>().IsDead())
        {
            Move = Input.GetAxis("Horizontal");
            rb.linearVelocity = new Vector2(Move * Speed, rb.linearVelocity.y);

            if (Input.GetButtonDown("Jump") && isGrounded())
            {
                rb.AddForce(new Vector2(rb.linearVelocity.x, jump * 10));
            }

            if (Move != 0)
            {
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
            }

            anim.SetBool("isJumping", !isGrounded());

            if (!isFacingRight && Move > 0)
            {
                Flip();
            }
            else if (isFacingRight && Move < 0)
            {
                Flip();
            }

            if (Input.GetButtonDown("Attack"))
            {
                anim.SetBool("isAttacking", true);
            }
       
        }


        
    }


    public void attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);

        foreach (Collider2D enemyGameobject in enemy)
        {
            Debug.Log("Hit enemy");
            enemyGameobject.GetComponent<EnemyHealth>().health -= damage;
        }
       


    }

    public void endAttack()
    {
        anim.SetBool("isAttacking", false);
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }


    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
       Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
       Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
    }

}
      
