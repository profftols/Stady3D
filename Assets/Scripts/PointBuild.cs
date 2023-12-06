using UnityEngine;

public class PointBuild : MonoBehaviour
{
    [SerializeField] private LayerMask _groundLayer;
    
    private bool _isHighlighted;
    private PointBuild _point;

    private void Update()
    {
        PathFlag();
    }

    private void PathFlag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100))
            {
                if (hit.collider.TryGetComponent<Citadel>(out Citadel citadel))
                {
                    _isHighlighted = true;
                }
                else
                {
                    _isHighlighted = false;
                }
            }
        }

        if (_isHighlighted)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100,
                        _groundLayer))
                {
                    if (_point != null)
                    {
                        transform.position = hit.point;
                    }
                    else
                    {
                        _point = Instantiate(this, hit.point, Quaternion.identity);
                    }
                }
            }
        }
    }
}
