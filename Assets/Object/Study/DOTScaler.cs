using UnityEngine;
using DG.Tweening;

public class DOTScaler : MonoBehaviour
{
    [SerializeField] private float _endScale;
    
    private int _setLoops = -1;
    private float _dutation = 3f;
    
    private void Start()
    {
        transform.DOScale(_endScale, _dutation).SetLoops(_setLoops, LoopType.Yoyo);
    }
}
