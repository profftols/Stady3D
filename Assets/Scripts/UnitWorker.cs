using UnityEngine;

public class UnitWorker : MonoBehaviour
{
    public bool IsWork { get; private set; }
    
    [SerializeField] private Builder _builder;
    
    private Citadel _citadel;
    private Vector3 _pathBuild;
    private Mover _mover;
    private Resource _resource;

    public void DragResource(Resource target)
    {
        _resource = target;
        IsWork = _mover.TrySetCoordinateResource(target.transform.position);
    }

    public bool TryCheckResource(Resource resource)
    {
        return _resource == resource;
    }

    public void BuildCitadel(Vector3 target)
    {
        IsWork = _mover.TrySetCoordinateBuild(target);
    }

    public bool Released()
    {
        return IsWork = _citadel.AddQueueWorker(this);
    }

    public void SetPosition(Vector3 position)
    {
        IsWork = _mover.SetNewPosition(position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PointBuild point))
        {
            if (MoneyManager.TryBuyCitadel())
            {
                _citadel.BuildBase(point).AddUnitWorker(this);
            }
        }
    }

    private void Start()
    {
        _mover = GetComponent<Mover>();
        _citadel = FindAnyObjectByType<Citadel>();
    }
}
