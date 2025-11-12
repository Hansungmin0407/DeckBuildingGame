using UnityEngine;

public class AniController : MonoBehaviour
{
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetBool("NextStage", true);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetBool("NextStage", false);
        }
        if ( Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetTrigger("Damaged");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            anim.SetTrigger("Attack");
        }
    }
}
