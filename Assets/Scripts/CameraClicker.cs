using UnityEngine;
using UnityEngine.Serialization;

public class CameraClicker : MonoBehaviour
{
    public static PointBuild FlagBuild { get; private set; }
    
    [SerializeField] private PointBuild _pointBuild;
    [SerializeField] private LayerMask _groundLayer;
    
    private Citadel _citadel;
    private bool _isHighlighted;
    private float _maxDistance = 100f;
    
    private void Update()
    {
        Select();
        SetFlag();
    }

    private void Select()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, _maxDistance))
            {
                if (hit.collider.TryGetComponent<Citadel>(out Citadel citadel))
                {
                    _isHighlighted = true;
                    _citadel = citadel;
                }
                else
                {
                    _isHighlighted = false;
                    _citadel = null;
                }
            }
        }
    }
    
    private void SetFlag()
    {
        if (_isHighlighted)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100,
                        _groundLayer))
                {
                    if (FlagBuild != null)
                    {
                        FlagBuild.transform.position = hit.point;
                    }
                    else
                    {
                        FlagBuild = Instantiate(_pointBuild, hit.point, Quaternion.identity);
                    }
                }
            }
        }
    }
}
