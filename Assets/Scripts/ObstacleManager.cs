using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] 
    private GameObject _player;
    [SerializeField] 
    private GameObject[] _obstacles;

    private int _obstacleIndex;
    private readonly int _distanceToNextObstacle = 50;

    private int _playerPositionIndex = -1;

    private void Start()
    {
        InstantiateObstacle();
    }

    private void Update()
    {
        if (_playerPositionIndex != (int)_player.transform.position.y / 25)
        {
            InstantiateObstacle();
            _playerPositionIndex = (int)_player.transform.position.y / 25;
        }
    }

    private void InstantiateObstacle()
    {
        var randomObstacle = Random.Range(0, _obstacles.Length);
        var newObstacle = Instantiate(_obstacles[randomObstacle],
            new Vector3(0, _obstacleIndex * _distanceToNextObstacle), Quaternion.identity);
        newObstacle.transform.SetParent(transform);

        _obstacleIndex++;
    }
}