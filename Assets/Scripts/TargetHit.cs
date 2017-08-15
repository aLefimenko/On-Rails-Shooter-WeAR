using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour {

    private GameObject _controll;

    [SerializeField]
    private GameObject _explosion;

    void Start()
    {
        _controll = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            gameObject.GetComponent<AudioSource>().Play();
            Destroy(Instantiate(_explosion, transform.position, Quaternion.identity), 1.5f);
            BaseSDK.Vibro();
            gameObject.SetActive(false);
            gameObject.transform.localScale = Vector3.zero;
            _controll.GetComponent<Controller>().LifeMinus();
        }
    }

}
