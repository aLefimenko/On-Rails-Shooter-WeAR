using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class InstAsteroids : MonoBehaviour  {

    public List<GameObject> asteroisAndOther = new List<GameObject>();
    [SerializeField]
    private int countObjectOfType;
    private List<GameObject> asteroidOnScene = new List<GameObject>();

    private Vector3 _playerPosition;
    private GameObject _spawnTarget;

	void Start () {
        _playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        _spawnTarget = GameObject.FindGameObjectWithTag("spawn");
        foreach (GameObject _gj in asteroisAndOther)
        {
            for (int j = 0; j < countObjectOfType; j++)
            {
               // Vector3 randomposition = new Vector3( Random.onUnitSphere.x * 500,  Random.onUnitSphere.y * 500,  Random.onUnitSphere.z * 500);
                Vector3 randomposition = new Vector3(Random.Range(_playerPosition.x -2500f, _playerPosition.x+ 2500f), Random.Range(_playerPosition.y - 2500f, _playerPosition.y+ 2500f), Random.Range(_playerPosition.z- 2500f, _playerPosition.z+ 2500f));
                asteroidOnScene.Add(Instantiate(_gj, randomposition, Quaternion.identity));
                
            }
        }
        foreach(GameObject _gObjects in asteroidOnScene)
        {
            _gObjects.SetActive(false);
        }
        StartCoroutine(CreateObjects());
    }

    IEnumerator CreateObjects()
    {
        yield return new WaitForSeconds(0.001f);
        int i = Random.Range(0, asteroidOnScene.Count);
        //int j = Random.Range(0, asteroidOnScene.Count);
        //_playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        /*if (asteroidOnScene[j].transform.position.z<_playerPosition.z)
        {
            SetNewPOsition(asteroidOnScene[j],_playerPosition);   
        }*/
        if(!asteroidOnScene[i].activeSelf)
        {
            asteroidOnScene[i].SetActive(true);
        }
        Repeat();

    }

    /*void SetNewPOsition(GameObject _gameobj, Vector3 _newPosition)
    {
        
        _gameobj.transform.position = new Vector3(Random.Range(_newPosition.x - 300f, _newPosition.x + 300f), Random.Range(_newPosition.y - 300f, _newPosition.y + 300f), Random.Range(_newPosition.z - 300f, _newPosition.z + 300f));
    }*/

    void Repeat()
    {
        StartCoroutine(CreateObjects());
    }
}
