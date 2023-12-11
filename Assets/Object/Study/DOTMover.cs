using UnityEngine;
using DG.Tweening;

public class DOTMover : MonoBehaviour
{
    [SerializeField] private float _coordinateY;
    
    private int _setLoops = -1;
    private float _dutation = 3f;
    
    private void Start()
    {
        Vector3 position = transform.position;
        Vector3 newPosition = new Vector3(position.x, position.y + _coordinateY, position.z);
        
        transform.DOMove(newPosition, _dutation).SetLoops(_setLoops, LoopType.Yoyo);
    }
}
