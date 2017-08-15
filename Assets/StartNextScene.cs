using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNextScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(NextScene());
	}

    private IEnumerator NextScene()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(1);
    }
}
