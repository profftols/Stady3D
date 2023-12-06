using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shipper : MonoBehaviour
{
    public bool isCargoFull { get; private set; }
    private UnitWorker _unit;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Resource resource))
        {
            if (resource.isWorkerBusy && _unit.TryCheckResource(resource))
            {
                resource.transform.SetParent(transform);
                resource.transform.position = transform.position;
                isCargoFull = true;
                resource.isBusy = true;
            }
        }
    }

    public void Unload()
    {
        isCargoFull = false;
    }

    private void Start()
    {
        _unit = GetComponentInParent<UnitWorker>();
    }
}
