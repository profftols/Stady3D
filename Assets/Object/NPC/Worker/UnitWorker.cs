using UnityEngine;

[RequireComponent(typeof(Mover))]
public class UnitWorker : MonoBehaviour
{
    private Citadel _citadel;
    private Mover _mover;
    private Resource _resource;
    public bool IsWork { get; private set; }

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _citadel = FindAnyObjectByType<Citadel>();
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

        if (other.TryGetComponent(out LoadingResource load))
        {
            load.SetWorkerHome(this);
        }
    }

    public Vector3 SetHome()
    {
        return _citadel.UnitHome();
    }
    
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

    public void SetPosition(Vector3 position)
    {
        IsWork = _mover.SetHome(position);
    }

    public Vector3 GetLoad()
    {
        return _citadel.GetLoadResource();
    }
}
