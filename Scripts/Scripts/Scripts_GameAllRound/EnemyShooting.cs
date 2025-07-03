using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    //Links
    //https://www.youtube.com/watch?v=bwi4lteomic
    //https://www.youtube.com/watch?v=--u20SaCCow

    public GameObject Arrow;
    public Transform ArrowPos;
    private float timer;
    private GameObject player;
    private Animator anim;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
           player = GameObject.FindGameObjectWithTag("Player");
           anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {   
         
     

        float distance = Vector2.Distance(transform.position, player.transform.position);
        

        if(distance < 6)
        {
            timer += Time.deltaTime; 
                
           
            if(timer > 1)
            {
                anim.SetBool("Attacking", true);  
                timer = 0;
            }
        }else{
            anim.SetBool("Attacking", false);            
        }

         
    }

    void shoot()
    {
        Instantiate(Arrow, ArrowPos.position, Quaternion.identity);
    }

   

}
