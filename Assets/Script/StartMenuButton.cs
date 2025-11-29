using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Debug.Log("Start Button Clicked");
        SceneManager.LoadScene("Background");
    }

    void OnMouseEnter()
    {
        Debug.Log("Mouse Entered Start Button");
    }

    private void OnMouseExit()
    {
        Debug.Log("Mouse Exited Start Button");
    }

}
