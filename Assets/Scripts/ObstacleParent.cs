using UnityEngine;

public class ObstacleParent : MonoBehaviour
{
    private readonly int _distanceY = 60;
    private Player _player;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }
    
    private void Update()
    {
        if (_player.transform.position.y - transform.position.y > _distanceY)
        {
            Destroy(gameObject);
        }
    }
}