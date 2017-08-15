using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfAsteroidExit : MonoBehaviour {

    private GameObject _player;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerExit(Collider _col)
    {
        //Debug.Log("Player_position  " + _player.transform.position.ToString());
        //Debug.Log("Collider position   " + _col.transform.position.ToString());
        //Vector3.
        //_col.transform.position = _player.transform.position + Vector3.Distance(_col.transform.position, _player.transform.position);
        _col.gameObject.SetActive(false);
        _col.gameObject.transform.localScale = Vector3.zero;
        _col.transform.position = _player.transform.position + (_player.transform.position - _col.transform.position);
        _col.gameObject.SetActive(true);
        //Debug.Log("Collider new position   " + _col.transform.position.ToString());
    }
}
