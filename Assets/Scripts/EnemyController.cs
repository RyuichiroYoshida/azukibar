using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int _bossLife = 10;
    public float _bossSpeed = 5f;
    public Transform _player;

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.position, _bossSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _bossLife--;
        print(_bossLife);
        if (_bossLife <= 0 )
        {
            Destroy(this.gameObject);
        }
    }
}
