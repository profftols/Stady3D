using UnityEngine;

public class Listener : MonoBehaviour
{
    [SerializeField] private Invoker _invoker;

    private void OnInvokerDisabled()
    {
        transform.localScale = new Vector3(2, 2, 2);
    }
    
    

    private void OnEnable()
    {
        _invoker.Disabled += OnInvokerDisabled;
    }
    
    private void OnDisable()
    {
        _invoker.Disabled -= OnInvokerDisabled;
    }
}
