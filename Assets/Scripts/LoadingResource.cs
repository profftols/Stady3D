using UnityEngine;

public class LoadingResource : MonoBehaviour
{
    private MoneyManager _manager;

    private void Start()
    {
        _manager = GetComponentInParent<MoneyManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Resource resource))
        {
            Destroy(resource.gameObject);
            _manager.ReceiveMoney();
        }
    }
}
