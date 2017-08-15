using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starttutorial : MonoBehaviour
{
    private Coroutine _cor;

    private float[] coord = new float[3];



    void Start()
    {

    }


    void Update()
    {
        coord = BaseSDK.GetAxel();
    }

    public void OnPointStart()
    {
        _cor = StartCoroutine(GoON());
    }

    private IEnumerator GoON()
    {
        yield return new WaitForSeconds(2f);

    }

    private void OffPOintStart()
    {
        StopCoroutine(_cor);
    }
}
