using UnityEngine;

[RequireComponent(typeof(UnitWorker))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speedMove;

    private UnitWorker _unit;
    private Vector3 _target;

    private void Start()
    {
        _unit = GetComponent<UnitWorker>();
        _target = _unit.SetHome();
    }

    private void Update()
    {
        GoTarget();
    }

    public bool TrySetCoordinateResource(Vector3 target)
    {
        _target = target;
        return true;
    }

    public bool TrySetCoordinateBuild(Vector3 target)
    {
        _target = target;
        return true;
    }

    public bool SetHome(Vector3 position)
    {
        _target = position;
        return false;
    }

    public bool SetTargetLoad()
    {
        _target = _unit.GetLoad();
        return true;
    }

    private void GoTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target,
            _speedMove * Time.deltaTime);
        transform.right = _target - transform.position;
    }
}