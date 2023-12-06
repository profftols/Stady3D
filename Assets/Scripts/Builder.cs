using UnityEngine;

public class Builder : MonoBehaviour
{
        private Citadel _citadel;
        private MoneyManager _money;
        
        public UnitWorker CreateUnit(Vector3 position, UnitWorker unit)
        {
            _money.BuyWorker();
            UnitWorker unitWorker = Instantiate(unit, position, Quaternion.identity);
            return unitWorker;
        }
    
        public Citadel CreateCitadel(PointBuild point)
        {
            var set = new Vector3(point.transform.position.x, point.transform.position.y + 0.01f,
                point.transform.position.z);
            
            _money.BuyCitadel();
            Citadel citadel = Instantiate(_citadel, set, Quaternion.identity);
            Destroy(point.gameObject);
            return citadel;
        }
    
        private void Start()
        {
            _citadel = GetComponent<Citadel>();
            _money = GetComponent<MoneyManager>();
        }
}
