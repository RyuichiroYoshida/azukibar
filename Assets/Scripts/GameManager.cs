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
    [System.NonSerialized] public bool _isGameClear = false;
    [System.NonSerialized] public float _score = 0;

    [SerializeField] BossController _bossController;
    [SerializeField] Text _scoreText;


    void Start()
    {
        _button.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //Text scoreText = FindObjectOfType<Text>();
        
        _scoreText.text = _score.ToString();

        if (_isGameOver)
        {
            StartCoroutine(DelayTime());
        }

        if (_isGameClear)
        {
            print("gameclear");
        }
    }

    public void IsGemeOver()
    {
        _isGameOver = true;
    }

    public void IsGameClear()
    {
        _isGameClear = true;
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
            _score += 10000;
        }
        else
        {
            _score += 1000;
        }
        print(_score);
    }
}
