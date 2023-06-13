using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEffect : MonoBehaviour
{
    [SerializeField] GameObject _effectPrefab;
    bool _bossDead = false;
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if (_bossDead == true)
        {
            for (int i = 1; i <= 10; i++)
            {
                StartCoroutine(BossEffects());
            }
        }
    }

    public void BossEffectController()
    {
        bool _bossDead = true;
        print(_bossDead);
    }
    public IEnumerator BossEffects()
    {
        Vector3 localPos = this.gameObject.transform.localPosition;
        float effectPointX = Random.Range(-10f, 10f);
        float effectPointY = Random.Range(-10f, 10f);
        localPos.x += effectPointX;
        localPos.y += effectPointY;
        Instantiate(_effectPrefab, new Vector3(localPos.x, localPos.y, localPos.z), Quaternion.identity);
        yield return new WaitForSeconds(1);
    }
}
