using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static int s_Money { get; private set; }
    public static int s_PriceCitadel { get; private set; } = 5;
    private static int s_priceWorker = 2;

    public static bool TryBuyWorker()
    {
        return s_Money >= s_priceWorker;
    }

    public static bool TryBuyCitadel()
    {
        return s_Money >= s_PriceCitadel;
    }

    public void ReceiveMoney()
    {
        s_Money++;
        Debug.Log(s_Money);
    }

    public void BuyWorker()
    {
        s_Money -= s_priceWorker;
    }

    public void BuyCitadel()
    {
        s_Money -= s_PriceCitadel;
    }
}
