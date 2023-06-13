using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] int _bossLife = 100;
    [SerializeField] BossEffect _effect;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _bossLife--;
        print(_bossLife);
        if (_bossLife <= 0)
        {  
            _effect.BossEffectController();
            Destroy(this.gameObject);
        }
    }
}
