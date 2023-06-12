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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform player = GetComponent<Transform>();
        if (player == null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, _bossSpeed * Time.deltaTime);
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
