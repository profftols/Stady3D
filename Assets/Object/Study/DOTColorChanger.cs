using UnityEngine;
using DG.Tweening;

public class DOTColorChanger : MonoBehaviour
{
    [SerializeField] private Material _material;

    private int _setLoops = -1;
    private float _dutation = 3f;
    
    void Start()
    {
        _material.color = Color.red;
        _material.DOColor(Color.cyan, _dutation).SetLoops(_setLoops, LoopType.Yoyo);
    }
}
