using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _Player;
    [SerializeField] GameObject _button;
    public bool _isGameOver = false;

    
    void Start()
    {
        _button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_isGameOver)
        {
            StartCoroutine(DelayTime());
        }
    }

    public void IsGemeOver()
    {
        _isGameOver = true;
    }

    public void OnClick()
    {
        print("aaa");
    }

    public IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(1f);
        _button.SetActive(true);
        Time.timeScale = 0;
    }

}
