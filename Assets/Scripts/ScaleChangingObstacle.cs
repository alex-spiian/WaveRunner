using UnityEngine;

public class ScaleChangingObstacle : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Vector3 _startScale;
    [SerializeField] private Vector3 _endScale;
    private float _currentTime;

    private void Update()
    {
        _currentTime += Time.deltaTime;

        var progress = Mathf.PingPong(_currentTime, _duration) / _duration;

        transform.localScale = Vector3.Lerp(_startScale, _endScale, progress);
    }
}
