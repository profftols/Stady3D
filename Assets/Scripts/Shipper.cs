using UnityEngine;

public class Shipper : MonoBehaviour
{
    private UnitWorker _unit;
    private Mover _mover;
    
    private void Start()
    {
        _unit = GetComponentInParent<UnitWorker>();
        _mover = GetComponentInParent<Mover>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Resource resource))
        {
            if (resource.IsWorkerBusy && _unit.TryCheckResource(resource))
            {
                resource.transform.SetParent(transform);
                resource.transform.position = transform.position;
                resource.IsBusy = _mover.SetTargetLoad();
            }
        }
    }
}
