using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;
using UnityEditor.SceneManagement;

public class DiceMachine : MonoBehaviour
{
    private GameRuleMaster ruleMaster;
    public bool playerInput = true;


    public RollDiceButton rollDiceButton;



    public List<int> diceValue;
    public int diceNum = 3;
    public int playerSelectDiceValue = 0;
    public int playerSelectDiceCount = 0;

    static private int _maxDiceRandomValue = 6;
    private int _diceListInputValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        diceValue = new List<int>();
        RollDice();
    }

    // Update is called once per frame
    void Update()
    {
        if (rollDiceButton.diceSelectValue != -1 && rollDiceButton.isRollDiceButtonClicked == true)
        {
            if (rollDiceButton.diceSelectValue == 1)
            {
                playerSelectDiceCount = GetCountInDiceList(diceValue, 1);
                Debug.Log("Player selected dice value: " + playerSelectDiceCount);
            }

            if (rollDiceButton.diceSelectValue == 2)
            {
                playerSelectDiceCount = GetCountInDiceList(diceValue, 2);
                Debug.Log("Player selected dice value: " + playerSelectDiceCount);
            }

            if (rollDiceButton.diceSelectValue == 3)
            {
                playerSelectDiceCount = GetCountInDiceList(diceValue, 3);
                Debug.Log("Player selected dice value: " + playerSelectDiceCount);
            }

            if (rollDiceButton.diceSelectValue == 4)
            {
                playerSelectDiceCount = GetCountInDiceList(diceValue, 4);
                Debug.Log("Player selected dice value: " + playerSelectDiceCount);
            }

            if (rollDiceButton.diceSelectValue == 5)
            {
                playerSelectDiceCount = GetCountInDiceList(diceValue, 5);
                Debug.Log("Player selected dice value: " + playerSelectDiceCount);
            }

            if (rollDiceButton.diceSelectValue == 6)
            {
                playerSelectDiceCount = GetCountInDiceList(diceValue, 6);
                Debug.Log("Player selected dice value: " + playerSelectDiceCount);
            }
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                playerSelectDiceCount = 300;
                Debug.Log("Player selected dice value: " + playerSelectDiceCount);
            }
        }
    }
    
    public int GetCountInDiceList(List<int> list, int targetNumber)
    {
        int count = 0;
        // 리스트의 모든 요소를 순회
        foreach (int number in list)
        {
            // 요소가 찾는 숫자와 일치하면 카운트 증가
            if (number == targetNumber)
            {
                count++;
            }
        }
        return count;
    }
    public void RollDice()
    {
        diceValue.Clear();
        for (int i = 0; i < diceNum; i++)
        {
            _diceListInputValue = Random.Range(1, _maxDiceRandomValue + 1);
            diceValue.Add(_diceListInputValue);
        }
        Debug.Log("Roll DIce : " + string.Join(", ", diceValue));
    }
}