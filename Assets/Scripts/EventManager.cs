using UnityEngine;

public class EventManager : MonoBehaviour
{
    private void OnEnable()
    {
        LoadingResource.CreateObject += Create;
    }

    private void OnDisable()
    {
        LoadingResource.CreateObject -= Create;
    }

    private void Create(Citadel citadel)
    {
        if (CameraClicker.FlagBuild)
        {
            if (MoneyManager.TryBuyCitadel())
            {
                citadel.CreateCitadel();
            }
        }
        else
        {
            if (MoneyManager.TryBuyWorker())
            {
                citadel.CreateUnit();
            }
        }
    }
}
