using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 currentPosition;
    bool hasStarted = false;
    void Start()
    {
        currentPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted || Input.GetKeyDown(KeyCode.J))
        {
            LockPosition();
            LaunchOnClick();
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            LockPosition();
            LaunchOnClick();
            hasStarted = false;
        }
        
    }
    private void LaunchOnClick()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(2f,5f);
            hasStarted = true;
        }
    }
    private void LockPosition()
    {
        transform.position = currentPosition;
        
    }
}
