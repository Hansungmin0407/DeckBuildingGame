using UnityEngine;

public class RollDiceButton : MonoBehaviour
{
    public Outline outline;

    public DiceMachine diceMachine;

    public Transform playerTransform;

    public Transform rollcubeTransform;

    public int RollNum = 10;
    public bool isRollDiceButtonClicked = false;

    void Start()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;

        rollcubeTransform = GetComponent<Transform>();

        if (playerTransform == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                playerTransform = playerObj.transform;
            }
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            rollcubeTransform.position = playerTransform.position + new Vector3(3f, 7f, 0f);
        }
    }

    void OnMouseDown()
    {

        Debug.Log("IsRolling, RollNum : " + diceMachine.IsRolling + RollNum );



        if (diceMachine.IsRolling || RollNum > -1)
        {
            if (diceMachine.IsRolling || RollNum > -1)
            {
                RollNum--;

                Debug.Log("Rolling is Start, RollNUM : " + RollNum);
            }

            isRollDiceButtonClicked = true;

            diceMachine.ToggleDiceState();
        }
        else
        {
            Debug.Log(RollNum);
            Debug.Log("No rolls left!");
        }
    }

    private void OnMouseEnter()
    {
        outline.enabled = true;
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
    }
}