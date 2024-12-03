using UnityEngine;

public class CarScript : MonoBehaviour
{
    public float speed = 7f;
    float maximumSteerAngle = 60f;

    public float steerSpeed = 30;

    public Transform wheelFrontRight;
    public Transform wheelFrontLeft;
    public Transform wheelRearRight;
    public Transform wheelRearLeft;

    Vector3 left = Vector3.left;
    Vector3 forword = Vector3.forward;
    public float speedForword = 15f;


    public float wheelSpeed = 360f;

    float angleOfWheels = 0;

    void Update()
    {
        moveCarForwardBackward();
        rotateWheels();
        steerWheels();
        steerCar();
    }

    void moveCarForwardBackward()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= left * speed * Time.deltaTime;
        }
    }

    void rotateWheels()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            wheelFrontRight.Rotate(new Vector3(-Time.deltaTime * wheelSpeed, 0, 0));
            wheelFrontLeft.Rotate(new Vector3(-Time.deltaTime * wheelSpeed, 0, 0));
            wheelRearRight.Rotate(new Vector3(0, -Time.deltaTime * wheelSpeed, 0), Space.Self);
            wheelRearLeft.Rotate(new Vector3(0, -Time.deltaTime * wheelSpeed, 0), Space.Self);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            wheelFrontRight.Rotate(new Vector3(0, Time.deltaTime * wheelSpeed, 0));
            wheelFrontLeft.Rotate(new Vector3(0, Time.deltaTime * wheelSpeed, 0));
            wheelRearRight.Rotate(new Vector3(0, Time.deltaTime * wheelSpeed, 0), Space.Self);
            wheelRearLeft.Rotate(new Vector3(0, Time.deltaTime * wheelSpeed, 0), Space.Self);
        }
    }

    void steerWheels()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            angleOfWheels += Time.deltaTime * steerSpeed;
            transform.position += forword * speedForword * Time.deltaTime;

        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            angleOfWheels -= Time.deltaTime * steerSpeed;
            transform.position -= forword * speedForword * Time.deltaTime;
        }
        else
        {
            angleOfWheels = Mathf.Lerp(angleOfWheels, 0, Time.deltaTime * steerSpeed * 0.75f);
        }

        angleOfWheels = Mathf.Clamp(angleOfWheels, -maximumSteerAngle, maximumSteerAngle);

        wheelFrontRight.localEulerAngles = new Vector3(90f, angleOfWheels, 0f);
        wheelFrontLeft.localEulerAngles = new Vector3(90f, angleOfWheels, 0f);
    }

    void steerCar()
    {
        left = Quaternion.Euler(0, 1, 0) * left;
    }
}