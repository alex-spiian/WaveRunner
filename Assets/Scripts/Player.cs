﻿using DefaultNamespace;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] 
    private GameObject _gameManager;

    [SerializeField] 
    private float _xSpeed;
    [SerializeField] 
    private float _ySpeed;
    [SerializeField] 
    private int _ySpeedMax;
    [SerializeField] 
    private int _yAccelerationForce;
    [SerializeField] 
    private int _yDecelerationForce;

    [SerializeField] 
    private GameObject _fxDead;
    [SerializeField] 
    private GameObject _fxColorChange;

    [SerializeField] 
    private AudioClip _deadClip;
    [SerializeField] 
    private AudioClip _itemClip;
    
    private Rigidbody2D _rigidbody;
    private float _angle;
    private float _mapWidth;
    private bool _isDead;
    private AudioSource _audioSource;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();

        _mapWidth = _gameManager.GetComponent<DisplayManager>().GetWidth();
    }

    private void Update()
    {
        if (_isDead) return;

        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 position = transform.position;
        position.x = Mathf.Cos(_angle) * (_mapWidth * 0.45f);
        position.y += _ySpeed * Time.deltaTime;
        transform.position = position;
        
        _angle += Time.deltaTime * _xSpeed;

        if (Input.GetMouseButton(0))
        {
            if (_rigidbody.velocity.y < _ySpeedMax)
            {
                _rigidbody.AddForce(new Vector2(0, _yAccelerationForce));
            }
        }
        else
        {
            if (_rigidbody.velocity.y > 0)
            {
                _rigidbody.AddForce(new Vector2(0, -_yDecelerationForce));
            }
            else
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(GameTags.Instance.ItemColorChange))
        {
            var itemFxGameObject =
                Instantiate(_fxColorChange, other.gameObject.transform.position, Quaternion.identity);
            Destroy(itemFxGameObject, 0.5f);
            Destroy(other.gameObject.transform.parent.gameObject);
            
            ColorManager.Instance.ChangeBackgroundColor();
            ScoreManager.Instance.AddScore();
            _audioSource.PlayOneShot(_itemClip, 1);
        }

        if (other.gameObject.CompareTag(GameTags.Instance.Ostacle) && _isDead == false)
        {
            _isDead = true;

            var deadFx = Instantiate(_fxDead, transform.position, Quaternion.identity);
            Destroy(deadFx, 0.5f);

            _rigidbody.velocity = new Vector2(0, 0);
            _rigidbody.isKinematic = true;

            _gameManager.GetComponent<GameManager>().GameOver();
            _audioSource.PlayOneShot(_deadClip, 1);
        }
    }
}