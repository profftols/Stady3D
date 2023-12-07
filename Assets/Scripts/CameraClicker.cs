using UnityEngine;

public class CameraClicker : MonoBehaviour
{
    public static PointBuild s_FlagBuild { get; private set; }
    
    [SerializeField] private PointBuild pointBuild;
    [SerializeField] private LayerMask _groundLayer;
    
    private Citadel _citadel;
    private bool _isHighlighted;
    private float maxDistance = 100f;
    
    private void Update()
    {
        Select();
        SetFlag();
    }

    private void Select()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, maxDistance))
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
                    if (s_FlagBuild != null)
                    {
                        s_FlagBuild.transform.position = hit.point;
                    }
                    else
                    {
                        s_FlagBuild = Instantiate(pointBuild, hit.point, Quaternion.identity);
                    }
                }
            }
        }
    }
}
