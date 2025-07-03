using UnityEngine;

public class MonsterDamage : MonoBehaviour
{

    //links
    // https://www.youtube.com/watch?v=qgX941I-YqE
    // https://www.youtube.com/watch?v=waj6i9cQ6rM
    // https://www.youtube.com/watch?v=cruE--5ML_Q
    // https://www.youtube.com/watch?v=j4036aBB4Mo
    // https://www.youtube.com/watch?v=KF3EVjOhN4c
    // https://www.youtube.com/watch?v=ICVkhZ5s970

    public int damage;
    public PlayerHealth playerHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
