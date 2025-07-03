    using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BossMovement : MonoBehaviour
{  
    public GameObject player;
    private Animator anim;
    public float speed;
    public float detectionRange;
    private bool isDefeated = false;
    private bool isMoving = false;

    public EnemyHealth enemyHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Walking", false);
    }

    // Update is called once per frame
    void Update()
{
    // Check if the boss is not defeated
    if (!isDefeated)
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (enemyHealth.currentHealth > 0)
            {
                if (distance <= detectionRange)
                {
                    MoveTowardsPlayer();
                }
                else
                {
                    isMoving = false;
                    anim.SetBool("Walking", false);
                }
            }
            else
            {
                DefeatBoss();
            }
        }
        else 
        {
            isMoving = false;
            anim.SetBool("Walking", false);
        }
    }

    // Move the boss towards the player
    private void MoveTowardsPlayer()
    {

          if (!isMoving)
        {
            isMoving = true;
            anim.SetBool("Walking", true);
        }

        Vector3 direction = (player.transform.position - transform.position).normalized;

        transform.position += direction * speed * Time.deltaTime;
    }

    //function when the boss is defeated
   public void DefeatBoss()
    {
        isDefeated = true;
        isMoving = false;
        anim.SetBool("Walking", false);
        anim.SetBool("IsDefeated", true);
        StartCoroutine(LoadNextSceneAfterDelay());
    }

    //An function that loads the next scene after a 1 second delay
   private IEnumerator LoadNextSceneAfterDelay()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Loading next scene...");
        SceneManager.LoadScene("EndDemo");
    }
}