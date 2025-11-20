
/*using System.Runtime.CompilerServices;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class DIceAnimation : MonoBehaviour
{
    public Transform playerTransform;
    Transform diceTransform;

    public Outline outline;

    public DiceMachine diceMachine;

    public RollDiceButton rollDiceButton;

    public GameRuleMaster gameRuleMaster;

    public AudioSource DiceShake;
    public AudioSource DicePosition;
    public AudioSource DiceSelected;

    private float _diceTransformRotationX;
    private float _diceTransformRotationY;
    private float _diceTransformRotationZ;
    public bool isMouseClickedCount;

    Vector3 _diceTransformPosition;
    private Vector3[] _diceTransformRotation;

    public bool IsDiceRolling => _isDiceRolling;
    private bool _isDiceRolling = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _diceTransformRotation = new Vector3[6];

        _diceTransformRotation[0] = new Vector3(0, -210, 0);
        _diceTransformRotation[1] = new Vector3(90, -210, 0);
        _diceTransformRotation[2] = new Vector3(90, -120, 0);
        _diceTransformRotation[3] = new Vector3(90, 60, 0);
        _diceTransformRotation[4] = new Vector3(90, -30, 0);
        _diceTransformRotation[5] = new Vector3(0, -30, 0);

        diceTransform = GetComponent<Transform>();
        _diceTransformPosition = diceTransform.position;
        outline = GetComponent<Outline>();
        outline.enabled = false;
        isMouseClickedCount = false;

        _diceTransformRotationX = 0;
        _diceTransformRotationY = 0;
        _diceTransformRotationZ = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDiceRolling)
        {
            DiceRolling();
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

    private void OnMouseDown()
    {
        if (gameRuleMaster.isAttacking || _isDiceRolling)
        {
            return;
        }

        if (rollDiceButton.isRollDiceButtonClicked)
        { 
            isMouseClickedCount = true;
            Debug.Log("Dice Clicked");
        }
    }
    public void RestartRolling()
    {
        _isDiceRolling = true;
    }

    private void DiceRolling()
    {
        _diceTransformRotationX += Time.deltaTime * 300;
        _diceTransformRotationY += Time.deltaTime * 300;
        _diceTransformRotationZ += Time.deltaTime * 300;

        _diceTransformPosition.x = _diceTransformRotationX;
        _diceTransformPosition.y = _diceTransformRotationY;
        _diceTransformPosition.z = _diceTransformRotationZ;

        diceTransform.rotation = Quaternion.Euler(_diceTransformPosition);
    }

    public void SetDiceFinalRotation(int diceValue)
    {
        Debug.Log("SetDiceFinalRotation called with diceValue: " + diceValue    );
        Debug.Log("Final Rotation: " + _diceTransformRotation[diceValue - 1]);
        PlayAudio(1);

        _isDiceRolling = false;
        diceTransform.rotation = Quaternion.Euler(_diceTransformRotation[diceValue -1]);
    }
    public void PlayAudio(int Getnum)
    {
        if (Getnum == 1)
        {
            if (!DicePosition.isPlaying)
            {
                DicePosition.Play();
            }
        }
        else if (Getnum == 2)
        {
            if (!DiceSelected.isPlaying)
            {
                DiceSelected.Play();
            }
        }
    }
}*/