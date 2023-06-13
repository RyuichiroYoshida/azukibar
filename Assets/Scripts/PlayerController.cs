using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] float _bulletCoolTime = 2;
    float _time = 0;

    public GameManager _gameManager;

    [SerializeField] GameObject _effectPrefab;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * _speed;


        _time += Time.deltaTime;
        if (Input.GetAxisRaw("Jump") == 1)
        {
            Vector3 localPos = transform.localPosition;
            localPos.x += 1;
            if (_time > _bulletCoolTime)
            {
                Instantiate(_bulletPrefab, new Vector3(localPos.x, localPos.y, localPos.z), Quaternion.identity);
                _time = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Instantiate(_effectPrefab, transform.position, Quaternion.identity);

            _gameManager.IsGemeOver();

            Destroy(this.gameObject);
        }
    }
}
