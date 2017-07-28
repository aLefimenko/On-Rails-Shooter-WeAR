using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class RotateObject : MonoBehaviour {

    [SerializeField]
    private bool isX = false;
    private float _rotateSpeed;
    void Start() {
        _rotateSpeed = Random.Range(0.7f, 2f);
    }


    void Update () {
		if(isX)
        {
            transform.Rotate(Vector3.left*_rotateSpeed);
        }
        else
        {
            transform.Rotate(Vector3.down* _rotateSpeed);
        }
	}
}
