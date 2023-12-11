using UnityEngine;
using DG.Tweening;

public class DOTRotater : MonoBehaviour
{
    [SerializeField] private float _rotateY = 1f;
    
    private int _setLoops = -1;
    private float _dutation = 3f;
    private float _defauldRotate = 0f;
    
    private void Start()
    {
        transform.DORotate(new Vector3(_defauldRotate, _rotateY, _defauldRotate), _dutation).SetLoops(_setLoops, LoopType.Yoyo);
    }
}
