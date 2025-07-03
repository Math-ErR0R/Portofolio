using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class JS : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
        StartCoroutine(LoadNextSceneAfterDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //loads next scene after a short delay
    private IEnumerator LoadNextSceneAfterDelay()
    {
        yield return new WaitForSeconds(1.0f);
        Debug.Log("Loading next scene...");
        SceneManager.LoadScene("EndDemo");
    }
}
