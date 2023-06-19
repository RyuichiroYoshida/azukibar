using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 5f;

    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] GameObject _homingBulletPrefab;
    [SerializeField] GameObject _beamPrefab;

    [SerializeField] float _bulletCoolTime = 2;
    [SerializeField] float _homingBulletCoolTime = 10;
    [SerializeField] float _beamCoolTime = 1;

    float _nomalBulletTime = 0;
    float _homingBulletTime = 0;
    float _beamTime = 0;

    bool playerShieldBreak = false;

    public GameManager _gameManager;
    public PlayerShield _playerShield;

    [SerializeField] GameObject _effectPrefab;
    void Start()
    {
        
    }
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * _speed;


        _nomalBulletTime += Time.deltaTime;
        _homingBulletTime += Time.deltaTime;
        _beamTime += Time.deltaTime;

        Vector3 localPos = transform.localPosition;
        localPos.x += 2;
        if (_nomalBulletTime > _bulletCoolTime)
        {
            Instantiate(_bulletPrefab, new Vector3(localPos.x, localPos.y, localPos.z), Quaternion.Euler(0, 0, 90f));
            _nomalBulletTime = 0;
        }

        if (_homingBulletTime > _homingBulletCoolTime)
        {
            float randomY = Random.Range(-1, 1);
            //Instantiate(_homingBulletPrefab, new Vector3(localPos.x - 2, localPos.y - randomY, localPos.z), Quaternion.identity);
            _homingBulletTime = 0;
        }

        if (Input.GetButton("Jump"))
        {
            print("Space");
            if (_beamTime > _beamCoolTime)
            {
                Instantiate(_beamPrefab, new Vector3(localPos.x, localPos.y, localPos.z), Quaternion.identity);
                _beamTime = 0;
                print("SpaceTime");
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            _playerShield.ShieldBreak();
            if (playerShieldBreak == true)
            {
                PlayerEffect();

                _gameManager.IsGemeOver();

                Destroy(this.gameObject);
            }
        }
    }

    public void PlayerEffect()
    {
        Instantiate(_effectPrefab, transform.position, Quaternion.identity);
    }

    public void PlayerShield()
    {
        playerShieldBreak = true;
    }
}
