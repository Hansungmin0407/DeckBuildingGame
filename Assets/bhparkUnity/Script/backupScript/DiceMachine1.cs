/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;
using UnityEditor.SceneManagement;

public class DiceMachine : MonoBehaviour
{
    public RollDiceButton rollDiceButton;
    public List<DIceAnimation> diceAnimations;

    public List<int> diceValue;
    public int diceNum = 3;
    public int playerSelectDiceValue = 0;
    public int playerSelectDiceCount = 0;

    static private int _maxDiceRandomValue = 6;
    private int _diceListInputValue;

    private bool _isRollingState = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        diceValue = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || (rollDiceButton.isRollDiceButtonClicked && rollDiceButton.diceSelectValue == 0))
        {
            ToggleDiceState();

            rollDiceButton.isRollDiceButtonClicked = false;
            rollDiceButton.diceSelectValue = -1;
        }

        if (rollDiceButton.diceSelectValue != -1 && rollDiceButton.isRollDiceButtonClicked == true)
        {
            if (rollDiceButton.diceSelectValue >= 1 && rollDiceButton.diceSelectValue <= 6)
            {
                playerSelectDiceCount = GetCountInDiceList(diceValue, rollDiceButton.diceSelectValue);
                Debug.Log("Player selected dice value: " + playerSelectDiceCount);
            }

            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                playerSelectDiceCount = 300;
                Debug.Log("Player selected dice value: " + playerSelectDiceCount);
            }

            rollDiceButton.isRollDiceButtonClicked = false;
            rollDiceButton.diceSelectValue = -1;
        }
    }
    // 굴리기/멈추기 토글 함수
    public void ToggleDiceState()
    {
        // _isRollingState = 현재 주사위 굴리는 중인지 확인하는 플래그
        if (_isRollingState)
        {
            _isRollingState = false;
            RollDice();
            for (int i = 0; i < diceNum; i++)
            {
                if (i < diceAnimations.Count)
                {
                    diceAnimations[i].SetDiceFinalRotation(diceValue[i]);
                }
            }
        }
        else
        {
            _isRollingState = true;
            foreach (var anim in diceAnimations)
            {
                anim.RestartRolling();
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
}*/