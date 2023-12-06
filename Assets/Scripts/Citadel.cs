using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citadel : MonoBehaviour
{
    [SerializeField] private float _waiterBuy = 2f;
    [SerializeField] private UnitWorker _unitWorker;
    
    private static Queue<Resource> s_resources;
    private static Queue<UnitWorker> s_unitWorkers;
    
    private Builder _builder;

    public static void AddResource(ref Resource resource)
    {
        if (CheckFreeResource(resource))
        {
            if (s_resources.Contains(resource))
            {
                s_resources.Enqueue(resource);
            }
        }
    }

    private static bool CheckFreeResource(Resource resource)
    {
        if (resource.isWorkerBusy == false)
        {
            return CheckFreeWorker(resource);
        }

        return resource.isWorkerBusy;
    }

    private static bool CheckFreeWorker(Resource resource)
    {
        if (s_unitWorkers.TryPeek(out UnitWorker unitWorker))
        {
            resource.isWorkerBusy = true;
            s_unitWorkers.Dequeue().DragResource(resource);
            return false;
        }

        resource.isWorkerBusy = false;
        return true;
    }

    public void AddUnitWorker(UnitWorker worker)
    {
        s_unitWorkers.Enqueue(worker);
        worker.SetPosition(transform.GetChild(1).position);
    }

    public bool AddQueueWorker(UnitWorker worker)
    {
        s_unitWorkers.Enqueue(worker);

        while (s_resources.Count > 0)
        {
            CheckFreeResource(s_resources.Dequeue());
        }
        
        return false;
    }

    public Citadel BuildBase(PointBuild point)
    {
        return _builder.CreateCitadel(point);
    }
    
    private void Awake()
    {
        s_resources = new();
        s_unitWorkers = new();
        _builder = GetComponent<Builder>();

        UnitWorker[] workers = FindObjectsByType<UnitWorker>(FindObjectsSortMode.None);

        for (int i = 0; i < workers.Length; i++)
            s_unitWorkers.Enqueue(workers[i]);

        StartCoroutine(BuyManager());
    }

    private IEnumerator BuyManager()
    {
        var waiteTimer = new WaitForSeconds(_waiterBuy);
        
        while (enabled)
        {
            if (CameraClicker.s_flagBuild)
            {
                if (MoneyManager.TryBuyCitadel())
                {
                    CreateCitadel();
                }
            }
            else
            {
                if (MoneyManager.TryBuyWorker())
                {
                    CreateUnit();
                }
            }

            yield return waiteTimer;
        }
    }

    private void CreateCitadel()
    {
        if (s_unitWorkers.TryDequeue(out UnitWorker unitWorker))
        {
            unitWorker.BuildCitadel(CameraClicker.s_flagBuild.transform.position);
        }
    }

    private void CreateUnit()
    {
        UnitWorker unit = _builder.CreateUnit(transform.GetChild(1).position, _unitWorker);
        s_unitWorkers.Enqueue(unit);
    }
}