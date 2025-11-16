using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AniController : MonoBehaviour
{
    private Animator anim;
    public float moveSpeed = 5.0f; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(NextBattle(20.0f));
    }

    public IEnumerator NextBattle(float distance)
    {
        anim.SetBool("NextStage", true);

        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + (Vector3.right * distance);
        
        float enlapse = 0f;
        float duration = distance / moveSpeed;

        while (enlapse < duration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, (enlapse / duration));

            enlapse += Time.deltaTime;
            yield return null;
        }
        transform.position = endPosition;
        anim.SetBool("NextStage", false);
    }

    public void AttackAni()
    {
        anim.SetTrigger("Attack");
    }

    public void VictoryAni()
    {
        anim.SetTrigger("Victory");
    }
}