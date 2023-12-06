using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingResource : MonoBehaviour
{
    public Vector3 position { get; private set; }
    private MoneyManager _manager;

    private void Start()
    {
        position = transform.position;
        _manager = GetComponentInParent<MoneyManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Resource resource))
        {
            Destroy(resource.gameObject);
            _manager.ReceiveMoney();
        }
    }
}
