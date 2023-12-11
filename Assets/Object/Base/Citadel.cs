using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Builder))]
public class Citadel : MonoBehaviour
{
    private static Queue<Resource> _resources;
    private static Queue<UnitWorker> _unitWorkers;
    
    [SerializeField] private UnitWorker _unitWorker;
    
    private Builder _builder;
    
    private void Awake()
    {
        _resources = new();
        _unitWorkers = new();
        _builder = GetComponent<Builder>();

        UnitWorker[] workers = FindObjectsByType<UnitWorker>(FindObjectsSortMode.None);

        for (int i = 0; i < workers.Length; i++)
            _unitWorkers.Enqueue(workers[i]);
    }

    public static void AddResource(ref Resource resource)
    {
        if (CheckFreeResource(resource))
        {
            if (_resources.Contains(resource))
            {
                _resources.Enqueue(resource);
            }
        }
    }

    private static bool CheckFreeResource(Resource resource)
    {
        if (resource.IsWorkerBusy == false)
        {
            return CheckFreeWorker(resource);
        }

        return resource.IsWorkerBusy;
    }

    private static bool CheckFreeWorker(Resource resource)
    {
        if (_unitWorkers.TryPeek(out UnitWorker unitWorker))
        {
            resource.IsWorkerBusy = true;
            _unitWorkers.Dequeue().DragResource(resource);
            return false;
        }

        resource.IsWorkerBusy = false;
        return true;
    }

    public void AddUnitWorker(UnitWorker worker)
    {
        _unitWorkers.Enqueue(worker);
        worker.SetPosition(transform.GetChild(1).position);
    }

    public Vector3 GetLoadResource()
    {
        return transform.GetChild(0).position;
    }

    public void AddQueueWorker(UnitWorker worker)
    {
        _unitWorkers.Enqueue(worker);
        worker.SetPosition(transform.GetChild(1).position);

        while (_resources.Count > 0)
        {
            CheckFreeResource(_resources.Dequeue());
        }
    }

    public Citadel BuildBase(PointBuild point)
    {
        return _builder.CreateCitadel(point);
    }

    public Vector3 UnitHome()
    {
        return transform.GetChild(1).position;
    }

    public void CreateCitadel()
    {
        if (_unitWorkers.TryDequeue(out UnitWorker unitWorker))
        {
            unitWorker.BuildCitadel(CameraClicker.FlagBuild.transform.position);
        }
    }

    public void CreateUnit()
    {
        UnitWorker unit = _builder.CreateUnit(transform.GetChild(1).position, _unitWorker);
        _unitWorkers.Enqueue(unit);
    }
}