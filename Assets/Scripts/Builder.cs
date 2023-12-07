using UnityEngine;

[RequireComponent(typeof(Citadel))]
[RequireComponent(typeof(MoneyManager))]
public class Builder : MonoBehaviour
{
        private Citadel _citadel;
        private MoneyManager _money;
        
        private void Start()
        {
            _citadel = GetComponent<Citadel>();
            _money = GetComponent<MoneyManager>();
        }
        
        public UnitWorker CreateUnit(Vector3 position, UnitWorker unit)
        {
            _money.BuyWorker();
            UnitWorker unitWorker = Instantiate(unit, position, Quaternion.identity);
            return unitWorker;
        }
    
        public Citadel CreateCitadel(PointBuild point)
        {
            float height = 0.01f;
            
            var set = new Vector3(point.transform.position.x, point.transform.position.y + height,
                point.transform.position.z);
            
            _money.BuyCitadel();
            Citadel citadel = Instantiate(_citadel, set, Quaternion.identity);
            Destroy(point.gameObject);
            return citadel;
        }
    
}
