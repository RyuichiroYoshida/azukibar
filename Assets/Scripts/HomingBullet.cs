using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    [SerializeField] float _homingSpeed = 15f;
    [SerializeField] float _lifeTime = 5f;
    float _time = 0;
    GameObject _enemy;

    [SerializeField] GameObject _effectPrefab;

    void Start()
    {
        
    }

    void Update()
    {
        _enemy = GameObject.FindGameObjectWithTag("Enemy");

        _time += Time.deltaTime;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        print("homing");
        rb.velocity = new Vector2(_enemy.transform.position.x, _enemy.transform.position.y) * _homingSpeed;

        if (_time > _lifeTime)
        {
            Destroy(this.gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Instantiate(_effectPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);

        }
    }
}
