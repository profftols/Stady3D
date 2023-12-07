using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static int Money { get; private set; }
    public static int PriceCitadel { get; private set; } = 5;
    private static int _priceWorker = 2;

    public static bool TryBuyWorker()
    {
        return Money >= _priceWorker;
    }

    public static bool TryBuyCitadel()
    {
        return Money >= PriceCitadel;
    }

    public void ReceiveMoney()
    {
        Money++;
    }

    public void BuyWorker()
    {
        Money -= _priceWorker;
    }

    public void BuyCitadel()
    {
        Money -= PriceCitadel;
    }
}
