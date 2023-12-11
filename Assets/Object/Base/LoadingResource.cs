using System;
using UnityEngine;

public class LoadingResource : MonoBehaviour
{
    public static Action<Citadel> CreateObject;
    
    private MoneyManager _manager;
    private Citadel _citadel;
    private int countWorker;

    private void Start()
    {
        _manager = GetComponentInParent<MoneyManager>();
        _citadel = GetComponentInParent<Citadel>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Resource resource))
        {
            Destroy(resource.gameObject);
            _manager.ReceiveMoney();
            CreateObject?.Invoke(_citadel);
            countWorker++;
        }
    }

    public void SetWorkerHome(UnitWorker worker)
    {
        if (countWorker > 0)
        {
            countWorker--;
            _citadel.AddQueueWorker(worker);
        }
    }
}