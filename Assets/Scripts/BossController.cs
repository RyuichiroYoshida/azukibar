using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] int _bossLife = 100;
    [SerializeField] BossEffect _effect;

    [System.NonSerialized] public bool _bossEffectEnd = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_bossEffectEnd == true)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
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
