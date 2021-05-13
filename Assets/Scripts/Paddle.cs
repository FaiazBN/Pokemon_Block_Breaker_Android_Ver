using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // config params

    [SerializeField] public float screenWidthInUnits = 16f;
    [SerializeField] public float yUnit;
    [SerializeField] public float min;
    [SerializeField] public float max;
    [SerializeField] JoyStick joyStick;
    [SerializeField] float playerSpeed;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joyStick = FindObjectOfType<JoyStick>();
    }


    // Update is called once per frame
    void Update()
    {
        
        float xPos = ((Input.mousePosition.x / Screen.width) * screenWidthInUnits);  // Input.mousePosition is where our current mouse is and by dividing it with screen width will give us the maximum value of x axis as 1 and after multiplying it with screen coordinate in unity units we can match our mouse position with screen coordinate in unity units
        Vector2 moveWithMouse = new Vector2(transform.position.x, yUnit); // Vector2 is a variable type where we can store our x and y coordinate, and by using "new Vector2(x,y)" we can store the coordinate
        moveWithMouse.x = Mathf.Clamp(GetXPos(), min, max); // mathf.clamp is used to limit value;
        //transform.position = moveWithMouse; // we are accessing the postion component and transforming it

        // for android
        if(joyStick.joyStickVec.y != 0)
        {
            rb.velocity = new Vector2(joyStick.joyStickVec.x * playerSpeed, joyStick.joyStickVec.y * playerSpeed);

        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private float GetXPos()
    {


        if (FindObjectOfType<GameSession>().IsAutoPlayOn() )
        {
            return  FindObjectOfType<Ball>().HasStarted()? FindObjectOfType<Ball>().transform.position.x: transform.position.x;
        }
        else
        {
            return ((Input.mousePosition.x / Screen.width) * screenWidthInUnits);
        }
       
    }

}
