using UnityEngine;

public class RollDiceButton : MonoBehaviour
{

    public Outline outline;

    public DiceMachine diceMachine;

    public DIceAnimation diceAnimation0;
    public DIceAnimation diceAnimation1;
    public DIceAnimation diceAnimation2;


    public int RollNum = 5;


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
