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
    }

    IEnumerator CreateObjects()
    {
        yield return new WaitForSeconds(0.001f);
        int i = Random.Range(0, asteroidOnScene.Count);
        if(!asteroidOnScene[i].activeSelf)
        {
            asteroidOnScene[i].SetActive(true);
        }
        Repeat();

    }

    void Repeat()
    {
        StartCoroutine(CreateObjects());
    }

    public void PoolObjects()
    {
        foreach (GameObject _gObjects in asteroidOnScene)
        {
            _gObjects.SetActive(false);
        }
    }

    public void InstaitiateObjects()
    {
        foreach (GameObject _gj in asteroisAndOther)
        {
            for (int j = 0; j < countObjectOfType; j++)
            {
                Vector3 randomposition = new Vector3(Random.Range(_playerPosition.x - 1500f, _playerPosition.x + 1500f), Random.Range(_playerPosition.y - 1500f, _playerPosition.y + 1500f), Random.Range(_playerPosition.z - 1500f, _playerPosition.z + 2500f));
                asteroidOnScene.Add(Instantiate(_gj, randomposition, Quaternion.identity));
            }
        }
        PoolObjects();
        StartCoroutine(CreateObjects());
    }
}
