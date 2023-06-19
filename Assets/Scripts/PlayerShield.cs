using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    [SerializeField] int _shieldLife = 100;
    [SerializeField] Transform _playerTransform;

    [SerializeField] GameObject child;

    public PlayerController playerController;

    void Start()
    {
        child.SetActive(false);
    }

    
    void Update()
    {
        if (_shieldLife <= 0)
        {
            playerController.PlayerShield();

            print("break");
            child.SetActive(true);

            StartCoroutine(ShieldBreakEffect());

        }
    }

    public void ShieldBreak()
    {
        _shieldLife--;
    }

    IEnumerator ShieldBreakEffect()
    {
        child.SetActive(true);
        Destroy(gameObject);
        yield return new WaitForSeconds(1);
        //child.SetActive(false);

    }
}
