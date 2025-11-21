using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuButton : MonoBehaviour
{
    
    public Outline outline;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnMouseDown()
    {
        SceneManager.LoadScene("Background");
        Debug.Log("Start Button Clicked");
    }


    void OnMouseEnter()
    {
        Debug.Log("Mouse Entered Start Button");
        outline.enabled = true;
    }

    private void OnMouseExit()
    {
        Debug.Log("Mouse Exited Start Button");
        outline.enabled = true;
    }

}
