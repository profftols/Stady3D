using UnityEngine;

[RequireComponent(typeof(UnitWorker))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    
    private Shipper _shipper;
    private UnitWorker _unit;
    private Vector3 _loadResource;
    private Vector3 _target;
    private Vector3 _startPosition;
    private Vector3 _pathBuild;
    private bool _isCollect;
    private bool _isBuild;

    private void Start()
    {
        _shipper = GetComponentInChildren<Shipper>();
        _unit = GetComponent<UnitWorker>();
        _loadResource = FindAnyObjectByType<LoadingResource>(FindObjectsInactive.Exclude).transform.position;
        _startPosition = transform.position;
    }

    private void Update()
    {
        if (_isBuild == false)
        {
            if (_isCollect)
            {
                if (_shipper.IsCargoFull == false)
                {
                    GoTarget();
                }
                else
                {
                    Carry();
                }
            }
            else
            {
                GoBack();
            }
        }
        else
        {
            GoBuild();
        }
    }
    
    public bool TrySetCoordinateResource(Vector3 target)
    {
        _target = target;
       return _isCollect = true;
    }

    public bool TrySetCoordinateBuild(Vector3 target)
    {
        _pathBuild = target;
        return _isBuild = true;
    }

    public bool SetNewPosition(Vector3 position)
    {
        _startPosition = position;
        return _isCollect;
    }

    private void GoBuild()
    {
        transform.position = Vector3.MoveTowards(transform.position, _pathBuild, _speedMove * Time.deltaTime);

        if (_pathBuild == transform.position)
        {
            _isBuild = false;
        }
    }
    
    private void GoTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target,
            _speedMove * Time.deltaTime);
        transform.right = _target - transform.position;
    }

    private void Carry()
    {
        transform.position =
            Vector3.MoveTowards(transform.position, _loadResource, _speedMove * Time.deltaTime);
        transform.right = _loadResource - transform.position;

        if (transform.position == _loadResource)
        {
            if (_shipper.IsCargoFull)
            {
                _isCollect = _unit.Released();
                _shipper.Unload();
            }
        }
    }

    private void GoBack()
    {
        transform.position = Vector3.MoveTowards(transform.position, _startPosition, _speedMove * Time.deltaTime);
    }
}
