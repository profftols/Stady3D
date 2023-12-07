using UnityEngine;

public class Shipper : MonoBehaviour
{
    private UnitWorker _unit;
    public bool IsCargoFull { get; private set; }
    
    private void Start()
    {
        _unit = GetComponentInParent<UnitWorker>();
    }
    
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

}
