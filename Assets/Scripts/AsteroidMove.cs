using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour {

    private GameObject _playerObject;
    private Vector3 _playerPosition;

    void OnTriggerEnter(Collider col)
    {
        SetPosition(col);
    }

    void OnTrigger(Collider col)
    {
        SetPosition(col);
    }

    void SetPosition(Collider _col)
    {
        _playerObject = GameObject.FindGameObjectWithTag("Player");
        _playerPosition = _playerObject.transform.position;
        _col.transform.position = new Vector3(_col.transform.position.x - _playerPosition.x, _col.transform.position.y - _playerPosition.y, _col.transform.position.z - _playerPosition.z);
        //_col.transform.position = new Vector3(Random.Range(_col.transform.position.x-_playerPosition.x,0), Random.Range(_col.transform.position.y - _playerPosition.y, 0), Random.Range(_playerPosition.z - 300f, _playerPosition.z + 300f));
    }
}

