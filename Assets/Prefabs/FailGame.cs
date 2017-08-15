using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailGame : MonoBehaviour {


    private float scaleSpeed = 0.005f;

    [SerializeField]
    private float scale = 2f;

    void Start()
    {
        gameObject.transform.localScale = Vector3.zero;
    }

    void FixedUpdate()
    {

        if(gameObject.transform.localScale.x<scale)
        {
            gameObject.transform.localScale += Vector3.one * scaleSpeed * scale;
        }

        
    }

    /*private GameObject _player;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerExit(Collider _col)
    {
        Debug.Log("Player_position  " + _player.transform.position.ToString());
        Debug.Log("Collider position   " + _col.transform.position.ToString());
        //Vector3.
        //_col.transform.position = _player.transform.position + Vector3.Distance(_col.transform.position, _player.transform.position);
        _col.transform.position = _player.transform.position + (_player.transform.position - _col.transform.position);
        Debug.Log("Collider new position   " + _col.transform.position.ToString());
    }

    /*private bool isOnScreen = true;

    private GameObject _targetObject;

    void Start()
    {
        _targetObject = GameObject.FindGameObjectWithTag("spawn");
    }

    void Update()
    {
        Vector3 _targetPosition = Camera.main.WorldToViewportPoint(this.transform.position);
        if (_targetPosition.z>0 && _targetPosition.x>0 && _targetPosition.y < 1 && _targetPosition.x < 1 && _targetPosition.y > 0)
        {
            isOnScreen = true;
        }
        else
        {
            gameObject.transform.position = new Vector3(Random.Range(_targetObject.transform.position.x - 400f, _targetObject.transform.position.x + 400f), Random.Range(_targetObject.transform.position.y - 400f, _targetObject.transform.position.y + 400f), Random.Range(_targetObject.transform.position.z - 400f, _targetObject.transform.position.z + 400f));
        }
    }

    void OnTriggerEnter(Collider col)
    {

    }*/
}
