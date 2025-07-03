using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{

    //Links
    //https://www.youtube.com/watch?v=bRcMVkJS3XQ


    public int maxHealth = 100;
    public float Health;
    public float currentHealth;
    private Animator anim;

    public Image healthbar;
    public GameManager gameManager;
    private bool Dead;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created    
    public bool IsDead()
    {
        return Health <= 0;
    }

    void Start()
    {
        Health = maxHealth;    
        anim = GetComponent<Animator>();
        currentHealth = Health;
    }

    // Update is called once per frame
    void Update()
    {

        healthbar.fillAmount = Mathf.Clamp(Health / maxHealth, 0, 1);

        if(Health < currentHealth)
        {
            currentHealth = Health;
            anim.SetTrigger("Attacked");
        }

        if (Health <= 0 && !Dead) 

        {
            Dead = true; 
            anim.SetBool("isDead", true);
            Debug.Log("You're is dead");
            gameManager.gameOver();
        }

        
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if(Health <= 0)
        {
            Debug.Log("Damaged");
        }
    }

}
