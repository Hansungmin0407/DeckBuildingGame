using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DIceAnimation : MonoBehaviour
{

    Transform diceTransform;

    public Outline outline;


    private float _diceTransformRotationX;

    private float _diceTransformRotationY;

    private float _diceTransformRotationZ;

    private int _isMouseClickedCount;


    Vector3 _diceTransformPosition;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

        diceTransform = GetComponent<Transform>();

        _diceTransformPosition = diceTransform.position;



        outline = GetComponent<Outline>();
        outline.enabled = false;

        _isMouseClickedCount = 0;


        _diceTransformRotationX = 0;
        _diceTransformRotationY = 0;
        _diceTransformRotationZ = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (_isMouseClickedCount%2 == 0)
        {
            DiceRolling();
        }
        else
        {
            // Do nothing, stop rolling
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

        _isMouseClickedCount++;
        Debug.Log("Dice Clicked");
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

}
