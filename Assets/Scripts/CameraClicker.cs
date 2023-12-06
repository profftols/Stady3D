using UnityEngine;

public class CameraClicker : MonoBehaviour
{
    [SerializeField] private PointBuild pointBuild;
    [SerializeField] private LayerMask _groundLayer;
    
    public static PointBuild s_flagBuild { get; private set; }
    private bool _isHighlighted;
    private Citadel _citadel;
    
    private void Update()
    {
        Select();
        SetFlag();
    }

    private void Select()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100))
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
                    if (s_flagBuild != null)
                    {
                        s_flagBuild.transform.position = hit.point;
                    }
                    else
                    {
                        s_flagBuild = Instantiate(pointBuild, hit.point, Quaternion.identity);
                    }
                }
            }
        }
    }
}
