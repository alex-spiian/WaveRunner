using UnityEngine;

public class VerticalMovingObstacle : MonoBehaviour
{
    [SerializeField] private float _durationInOneWay;
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private float _currentTime;

    private void Start()
    {
        _startPosition = transform.position;
        _endPosition = _startPosition;
        _startPosition.y += 5;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        var progress = Mathf.PingPong(_currentTime, _durationInOneWay) / _durationInOneWay;

        transform.position = Vector3.Lerp(_startPosition, _endPosition, progress);
    }
}