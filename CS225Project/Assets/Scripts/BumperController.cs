using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public float bumperSpeed;
    private bool spacePressed;
    public bool facingLeft;

    private Quaternion raisedAngle;
    private Quaternion loweredAngle;

    // Update is called once per frame
    void Update()
    {
        // read player input
        if (Input.GetKey(KeyCode.Space))
            spacePressed = true;
        else
            spacePressed = false;
    }

    private void Start()
    {
        loweredAngle = transform.rotation;

        if (facingLeft)
            raisedAngle = Quaternion.Euler(0, 0, 190);
        else
            raisedAngle = Quaternion.Euler(0, 0, 50);
    }

    private void FixedUpdate()
    {
        // rotate bumper if space is pressed rotate back to default position if it isn't
        if (spacePressed && transform.rotation.z < 50)
            MoveBumper(raisedAngle);
        else if (!spacePressed && transform.rotation.z > 0)
            MoveBumper(loweredAngle);
    }

    void MoveBumper(Quaternion targetAngle)
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetAngle, bumperSpeed);
    }
}
