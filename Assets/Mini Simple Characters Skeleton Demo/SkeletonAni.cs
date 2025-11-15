using UnityEngine;

public class SkeletonAni : MonoBehaviour, IMonsterAnimatable
{
    private Animator anim;

    public float damagedAnimLength = 2.0f;
    public float deadAnimLength = 2.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public float DamagedAni()
    {
        anim.SetTrigger("Damaged");
        return damagedAnimLength;
    }

    public float DeadAni()
    {
        anim.SetTrigger("Death");
        return deadAnimLength;
    }
}