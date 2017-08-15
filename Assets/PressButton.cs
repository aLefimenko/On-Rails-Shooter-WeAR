using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButton : MonoBehaviour {

    [SerializeField]
    private GameObject _start;

	void Update () {
        if (BaseSDK.GetButton(0) || BaseSDK.GetButton(1) || BaseSDK.GetButton(2))
        {
            _start.GetComponent<FirstSceneTutorial>().StartTutorial();
            gameObject.SetActive(false);
        }
	}
}
