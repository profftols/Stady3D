using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static int s_money { get; private set; }
    public static int s_priceCitadel { get; private set; } = 5;
    private static int s_priceWorker = 2;

    public void ReceiveMoney()
    {
        s_money++;
        Debug.Log(s_money);
    }

    public void BuyWorker()
    {
        s_money -= s_priceWorker;
    }

    public void BuyCitadel()
    {
        s_money -= s_priceCitadel;
    }

    public static bool TryBuyWorker()
    {
        return s_money >= s_priceWorker;
    }

    public static bool TryBuyCitadel()
    {
        return s_money >= s_priceCitadel;
    }
}
