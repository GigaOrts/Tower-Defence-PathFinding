using System.Collections;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] [Range(0, 50)] private int _poolSize = 5;
    [SerializeField] [Range(0.1f, 30f)] private float _spawnTimer;

    private GameObject[] _pool;

    private void Awake()
    {
        PopulatePool();
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void PopulatePool()
    {
        _pool = new GameObject[_poolSize];

        for (int i = 0; i < _pool.Length; i++)
        {
            _pool[i] = Instantiate(_enemyPrefab, transform);
            _pool[i].SetActive(false);
        }
    }

    void EnableObjectInPool()
    {
        for (int i = 0; i < _pool.Length; i++)
        {
            if(_pool[i].activeInHierarchy == false)
            {
                _pool[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(_spawnTimer);
        }
    }
}
