using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    [SerializeField] private Vector3 _rotationSpeed;
    
    void Update()
    {
        transform.Rotate(_rotationSpeed * Time.deltaTime, Space.Self);
    }
}
