using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	private bool _run = false;
	private PlayerControl _playerControl;
	
	void Start(){
		_playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        //_playerControl.status = true;
        _run = true;
	}	
}
