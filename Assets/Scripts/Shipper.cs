using UnityEngine;

public class Shipper : MonoBehaviour
{
    public bool IsCargoFull { get; private set; }
    private UnitWorker _unit;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Resource resource))
        {
            if (resource.IsWorkerBusy && _unit.TryCheckResource(resource))
            {
                resource.transform.SetParent(transform);
                resource.transform.position = transform.position;
                IsCargoFull = true;
                resource.IsBusy = true;
            }
        }
    }

    public void Unload()
    {
        IsCargoFull = false;
    }

    private void Start()
    {
        _unit = GetComponentInParent<UnitWorker>();
    }
}
