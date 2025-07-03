using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float health;
    public float currentHealth;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private EdgeCollider2D edgeCollider;
    
    private Rigidbody2D rBody;
    private MonsterDamage monsterDamage;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        edgeCollider = GetComponent<EdgeCollider2D>();
        rBody = GetComponent<Rigidbody2D> ();
        monsterDamage = GetComponent<MonsterDamage>();
        currentHealth = health;
        
    }


    // Update is called once per frame
    void Update()
    {
        if(health < currentHealth)
        {
            currentHealth = health;
            anim.SetTrigger("Attacked");
        }

        if (health <= 0)
        {
            anim.SetBool("isDead", true);
            
           
            if (boxCollider != null) boxCollider.enabled = false;
            if (edgeCollider != null) edgeCollider.enabled = false;
            if (monsterDamage != null) monsterDamage.enabled = false;
            if (rBody != null) Destroy(rBody);
        }

    }

    

}
