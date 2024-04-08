using UnityEngine;

public class DisplayManager : MonoBehaviour
{
    private const float MAP_X = 100.0f;
    private const float MAP_Y = 100.0f;

    private float _minX;
    private float _maxX;
    private float _minY;
    private float _maxY;

    private Vector2 _leftDown;
    private Vector2 _rightDown;

    private float _width;

    private void Awake()
    {
        InitDisplayBound();
    }

    private void InitDisplayBound()
    {
        var vertExtent = Camera.main.orthographicSize;
        var horizExtent = vertExtent * Screen.width / Screen.height;


        _minX = horizExtent - MAP_X / 2.0f;
        _maxX = MAP_X / 2.0f - horizExtent;
        _minY = vertExtent - MAP_Y / 2.0f;
        _maxY = MAP_Y / 2.0f - vertExtent;

        _leftDown = new Vector2(_maxX - 50, _maxY - 50);
        _rightDown = new Vector2(_minX + 50, _minY - 50);

        _width = _rightDown.x - _leftDown.x;
    }

    public float GetWidth()
    {
        return _width;
    }
}