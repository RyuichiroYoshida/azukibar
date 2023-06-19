using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgression : MonoBehaviour
{
    [SerializeField] float _gameSpeed = 5f;

    [SerializeField] GameManager _manager;
    [SerializeField] PlayerController _playerController;
    [SerializeField] BossEffect _effect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_effect._bossDead != true)
        {
            transform.position += new Vector3(Time.deltaTime * _gameSpeed, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _playerController.PlayerEffect();

            _manager.IsGemeOver();

            Destroy(collision.gameObject);
        }
    }
}
