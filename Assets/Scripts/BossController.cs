using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] public int _bossLife = 100;
    [SerializeField] BossEffect _effect;
    [SerializeField] Transform _playerTransform;

    [System.NonSerialized] public bool _bossEffectEnd = false;

    [SerializeField] GameManager _gameManager;
    [SerializeField] GameObject _enemyBulletPrefab;

    void Start()
    {
        GameObject _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (_bossEffectEnd == true)
        {
            _gameManager.ScoreUper();
            _gameManager.IsGameClear();
            Destroy(this.gameObject);
        }

        if (_effect._bossArrive == true)
        { 
            float x = transform.position.x - _playerTransform.position.x;
            print(x);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            _bossLife--;
            print(_bossLife);
            _effect._bossArrive = true;
            if (_bossLife <= 0)
            {
                _effect._bossDead = true;
            }
        }
    }
}
