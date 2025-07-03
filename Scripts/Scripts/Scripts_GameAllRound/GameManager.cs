using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //Links
    // https://www.youtube.com/watch?v=pKFtyaAPzYo&t=616s
    // https://www.youtube.com/watch?v=E25JWfeCFPA
    // https://www.youtube.com/watch?v=DX7HyN7oJjE
    // https://www.youtube.com/watch?v=YOaYQrN1oYQ
    // https://www.youtube.com/watch?v=tBj-FWcIwYw&t=48s

    public GameObject gameOverUI;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOverUI.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    
    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

  

    public void quit()
    {
        Application.Quit();
    }
    
}
