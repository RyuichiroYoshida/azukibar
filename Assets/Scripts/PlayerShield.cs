using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    [SerializeField] int _shieldLife = 100;
    [SerializeField] Transform _playerTransform;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(_playerTransform.position.x + 5, _playerTransform.position.y, _playerTransform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet" || collision.gameObject.tag == "Enemy")
        {
        _shieldLife--;
        }
    }
}
