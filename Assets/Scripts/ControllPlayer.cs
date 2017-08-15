using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllPlayer : MonoBehaviour {

    /*private GameObject _targetObject;

    private Vector3 _vectorToTarget;

    private float rad;
	void Start () {
        _targetObject = GameObject.FindGameObjectWithTag("target");
	}

	void Update () {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        _targetObject.transform.position += new Vector3(x, y, 0);
        rad = Vector3.Angle(transform.position, _targetObject.transform.position);
	}

    public void MoveObject(int _i)
    {
        switch (_i)
        {
            case 1:
                _targetObject.transform.position += Vector3.up;
                break;
            case 2:
                _targetObject.transform.position += Vector3.left;
                break;
            case 3:
                _targetObject.transform.position += Vector3.right;
                break;
            case 4:
                _targetObject.transform.position += Vector3.down;
                break;
        }
    }*/






    private float speed = 5.0f, turnspeed = 30.0f, truespeed = 0f, strafeSpeed = 100.0f;
    private Rigidbody _rigidbody;
    private Gyroscope _gyro;
    float moveX, moveY;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime);
        /*if(Input.gyro.enabled)
        {
            _gyro = Input.gyro;
            moveX = _gyro.gravity.x;
            moveY = _gyro.gravity.y;
        }*/
        //float x = moveX;
        //float y = moveY;
        /*float x = Input.GetAxis("Horizontal") *  Time.deltaTime;
        float y = Input.GetAxis("Vertical") *  Time.deltaTime;
        _rigidbody.AddTorque(Vector3.forward * turnspeed * -x);
        _rigidbody.AddTorque(Vector3.up * x * strafeSpeed);
        _rigidbody.AddTorque(Vector3.right * turnspeed * -y);
        transform.position += new Vector3(x*speed, y*speed, 0);
        //Vector3 strafe = new Vector3(Input.GetAxis("Horizontal") * strafeSpeed * Time.deltaTime, Input.GetAxis("Vertical") * strafeSpeed * Time.deltaTime, 0);
        /*_rigidbody.AddRelativeTorque(-y,x,0);
        _rigidbody.AddRelativeForce(-y, x, 0);
        _rigidbody.AddRelativeForce(strafe);
        _rigidbody.AddForce(-0.2f * _rigidbody.velocity);*/
        //_rigidbody.AddForce(0.2f*_rigidbody.velocity);

    }


    /*var turnspeed = 5.0; var speed = 5.0; private var trueSpeed = 0.0; var strafeSpeed = 5.0;

    function Update()
    {

        var roll = Input.GetAxis("Roll"); var pitch = Input.GetAxis("Pitch"); var yaw = Input.GetAxis("Yaw"); var strafe =

        Vector3(Input.GetAxis("Horizontal") * strafeSpeed * Time.deltaTime, Input.GetAxis("Vertical") * strafeSpeed * Time.deltaTime, 0);

        var power = Input.GetAxis("Power");

        //Truespeed controls if (trueSpeed < 10 && trueSpeed > -3){ trueSpeed += power; } if (trueSpeed > 10){ trueSpeed = 9.99; } if (trueSpeed < -3){ trueSpeed = -2.99; } if (Input.GetKey("backspace")){ trueSpeed = 0; }

        rigidbody.AddRelativeTorque(pitch * turnspeed * Time.deltaTime, yaw * turnspeed * Time.deltaTime, roll * turnspeed * Time.deltaTime); rigidbody.AddRelativeForce(0, 0, trueSpeed * speed * Time.deltaTime); rigidbody.AddRelativeForce(strafe);

        rigidbody.AddForce(-0.20 * rigidbody.velocity);

    }*/
}
