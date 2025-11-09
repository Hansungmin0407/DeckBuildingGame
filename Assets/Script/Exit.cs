using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public void LoadIngameScene()
    {
        SceneManager.LoadScene("Main store scene");
    }
}
