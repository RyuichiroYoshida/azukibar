using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _Player;
    [SerializeField] GameObject _button;
    [System.NonSerialized] public bool _isGameOver = false;

    [System.NonSerialized] public float score = 0;

    [SerializeField] BossController _bossController;


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
        SceneManager.LoadScene("TitleScene");
    }

    public IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(1f);
        _button.SetActive(true);
        Time.timeScale = 0;
    }

    public void ScoreUper()
    {
        if (_bossController._bossEffectEnd == true)
        {
            score += 10000;
        }
        else
        {
            score += 1000;
        }
        print(score);
    }
}
