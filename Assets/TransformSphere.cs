using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformSphere : MonoBehaviour {

    private GameObject _playerObject;
	void Start () {
        _playerObject = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () {
        transform.position = _playerObject.transform.position;
	}
}
