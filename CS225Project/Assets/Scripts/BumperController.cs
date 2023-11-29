using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    private bool spacePressed;
    private Quaternion raisedAngle;
    private Quaternion loweredAngle;

    public float bumperSpeed;
    public bool facingLeft;

    // Update is called once per frame
    void Update()
    {
        // read player input
        if (Input.GetKey(KeyCode.Space))
            spacePressed = true;
        else
            spacePressed = false;
    }

    void Start()
    {
        loweredAngle = transform.rotation;

        if (facingLeft)
            raisedAngle = Quaternion.Euler(0, 0, 190);
        else
            raisedAngle = Quaternion.Euler(0, 0, 50);
    }

    void FixedUpdate()
    {
        // rotate bumper if space is pressed rotate back to default position if it isn't
        if (spacePressed && transform.rotation.z < raisedAngle.z)
            MoveBumper(raisedAngle);
        else if (!spacePressed && transform.rotation.z > loweredAngle.z)
            MoveBumper(loweredAngle);
    }

    void MoveBumper(Quaternion targetAngle)
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetAngle, bumperSpeed);
    }
}
