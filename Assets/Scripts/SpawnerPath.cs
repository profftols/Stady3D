using System.Collections;
using UnityEngine;

public class SpawnerPath : MonoBehaviour
{
    [SerializeField] private Resource _resource;
    [SerializeField] private Transform _path;

    private Transform[] _paths;
    private float _wait = 1f;
    private int _maxValue = 20;
    
    private void Start()
    {
        _paths = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _paths[i] = _path.GetChild(i);
        }

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var waitTimer = new WaitForSeconds(_wait);
        int resource = 0;
        
        while (_maxValue > ++resource)
        {
            var pathSpawn = _paths[Random.Range(0, _path.childCount)];
            Instantiate(_resource, pathSpawn);
            yield return waitTimer;
        }
    }
}
