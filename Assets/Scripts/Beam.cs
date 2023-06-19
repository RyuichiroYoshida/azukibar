using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    [SerializeField] float _beamSpeed = 10f;
    [SerializeField] float _lifeTime = 5f;
    [SerializeField] int _beamHitCount = 15;
    float _time = 0;

    [SerializeField] GameObject _effectPrefab;
    void Start()
    {
        
    }

    void Update()
    {
        _time += Time.deltaTime;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * _beamSpeed;

        if (_time > _lifeTime)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _beamHitCount--;
            Instantiate(_effectPrefab, transform.position, Quaternion.identity);
            if (_beamHitCount <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
