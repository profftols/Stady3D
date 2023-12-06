using System.Collections;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField] private float _waiterScan;
    [SerializeField] private bool _scan = true;
    
    private void Start()
    {
        StartCoroutine(FindResource());
    }

    private IEnumerator FindResource()
    {
        var waitTimer = new WaitForSeconds(_waiterScan);

        while (_scan)
        {
            Resource[] resources = FindObjectsByType<Resource>(FindObjectsSortMode.None);
            
            if (resources != null)
            {
                for (int i = 0; i < resources.Length; i++)
                {
                    if (resources[i].isBusy == false && resources[i].isWorkerBusy == false)
                    {
                        Citadel.AddResource(ref resources[i]);
                    }
                }
            }

            yield return waitTimer;
        }
    }
}
