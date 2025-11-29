using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Monster monster;

    public Transform RedHpBar;

    public Transform parentTransform;

    public Transform myTransform;

    private float HpBarScaleX;
    private float preRatio;
    private bool first = true;

    void Start()
    {
        parentTransform = transform.parent;
        monster = parentTransform.GetComponent<Monster>();
        RedHpBar = transform.Find("Red");
        myTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float hpRatio = (float)monster.monsterHP / (float)monster.MaxHP;

        if(first || (preRatio != hpRatio))
        {
            Debug.Log("HPRatio == " + hpRatio);
            Debug.Log("MAXHP == " + monster.MaxHP);
            Debug.Log("HP == " + monster.monsterHP);
            preRatio = hpRatio;
            first = false;
        }

        myTransform.localPosition = new Vector3(0f, 0f, 0f);
        RedHpBar.localScale = new Vector3(hpRatio, 0.3f, 1f);
        RedHpBar.localPosition = new Vector3(-0.00001f, 2f, 0.5f - hpRatio / 2.0f);
    }
}
