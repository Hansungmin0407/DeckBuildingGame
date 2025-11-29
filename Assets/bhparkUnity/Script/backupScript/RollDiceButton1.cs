/*using UnityEngine;

public class RollDiceButton : MonoBehaviour
{
    public Outline outline;

    public DiceMachine diceMachine;

    public DIceAnimation diceAnimation0;
    public DIceAnimation diceAnimation1;
    public DIceAnimation diceAnimation2;

    public Transform diceAnimation0Transform;
    public Transform diceAnimation1Transform;
    public Transform diceAnimation2Transform;

    public Transform playerTransform;

    public Transform rollcubeTransform;

    public int RollNum = 5;
    public int diceSelectValue;
    public bool isRollDiceButtonClicked = false;

    private bool _isRolling = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        diceSelectValue = -1;
        outline = GetComponent<Outline>();
        outline.enabled = false;

        diceAnimation0Transform = diceAnimation0.GetComponent<Transform>();
        diceAnimation1Transform = diceAnimation1.GetComponent<Transform>();
        diceAnimation2Transform = diceAnimation2.GetComponent<Transform>();

        rollcubeTransform = GetComponent<Transform>();

        if (playerTransform == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
            {
                playerTransform = playerObj.transform;
            }
            else
            {
                if (playerObj != null)
                {
                    playerObj = GameObject.Find("Player");
                    playerTransform = playerObj.transform;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform == null) return;

        rollcubeTransform.position = playerTransform.position + new Vector3(3f, 7f, 0f);

        diceAnimation0Transform.position = playerTransform.position + new Vector3(0f, 5f, 2f);
        diceAnimation1Transform.position = playerTransform.position + new Vector3(3f, 5f, 2f);
        diceAnimation2Transform.position = playerTransform.position + new Vector3(6f, 5f, 2f);

        if (_isRolling)
        {
            diceSelectValue = -1;
            return;
        }

        if (diceAnimation0.isMouseClickedCount)
        {
            diceSelectValue = diceMachine.diceValue[0];
        }
        else if (diceAnimation1.isMouseClickedCount)
        {
            diceSelectValue = diceMachine.diceValue[1];
        }
        else if (diceAnimation2.isMouseClickedCount)
        {
            diceSelectValue = diceMachine.diceValue[2];
        }
    }

    void OnMouseDown()
    {
        isRollDiceButtonClicked = true;
        diceSelectValue = -1;

        if (_isRolling)
        {
            if (RollNum > 0)
            {
                RollNum--;
                diceMachine.RollDice();
                diceAnimation0.SetDiceFinalRotation(diceMachine.diceValue[0]);
                diceAnimation1.SetDiceFinalRotation(diceMachine.diceValue[1]);
                diceAnimation2.SetDiceFinalRotation(diceMachine.diceValue[2]);
            }
            else
            {
                Debug.Log(RollNum);
                Debug.Log("No rolls left!");
            }

            _isRolling = false;
        }
        else
        {
            diceAnimation0.RestartRolling();
            diceAnimation1.RestartRolling();
            diceAnimation2.RestartRolling();

            _isRolling = true;
            isRollDiceButtonClicked = false;
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
*/