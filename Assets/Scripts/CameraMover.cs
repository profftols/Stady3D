using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private void Update()
    {
        Mover();
    }

    private void Mover()
    {
        Vector3 mover = transform.position;

        if (Input.GetKey(KeyCode.S))
            mover.x += Time.deltaTime * _speed;

        if (Input.GetKey(KeyCode.W))
            mover.x -= Time.deltaTime * _speed;

        if (Input.GetKey(KeyCode.D))
            mover.z += Time.deltaTime * _speed;

        if (Input.GetKey(KeyCode.A))
            mover.z -= Time.deltaTime * _speed;

        transform.position = mover;
    }
}
