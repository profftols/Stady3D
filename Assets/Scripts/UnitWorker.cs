using UnityEngine;

public class UnitWorker : MonoBehaviour
{
    [SerializeField] private Builder _builder;
    
    public bool isWork { get; private set; }
    private Citadel _citadel;
    private Vector3 _pathBuild;
    private Mover _mover;
    private Resource _resource;

    public void DragResource(Resource target)
    {
        _resource = target;
        isWork = _mover.TrySetCoordinateResource(target.transform.position);
    }

    public bool TryCheckResource(Resource resource)
    {
        return _resource == resource;
    }

    public void BuildCitadel(Vector3 target)
    {
        isWork = _mover.TrySetCoordinateBuild(target);
    }

    public bool Released()
    {
        return isWork = _citadel.AddQueueWorker(this);
    }

    public void SetPosition(Vector3 position)
    {
        isWork = _mover.SetNewPosition(position);
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
