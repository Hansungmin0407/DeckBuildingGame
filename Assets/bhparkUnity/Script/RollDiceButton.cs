using UnityEngine;

public class RollDiceButton : MonoBehaviour
{

    public Outline outline;

    public DiceMachine diceMachine;

    public DIceAnimation diceAnimation0;
    public DIceAnimation diceAnimation1;
    public DIceAnimation diceAnimation2;


    public int RollNum = 5;

    public int diceSelectValue;

    public bool isRollDiceButtonClicked = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        diceSelectValue = -1;

        outline = GetComponent<Outline>();
        outline.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {

        if(diceAnimation0.isMouseClickedCount)
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

        isRollDiceButtonClicked = true;
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
