using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    int _score = 0;
    bool hasKey = false;
    int _sceneNum = 0;

    [SerializeField] GameObject _scoreText;

    public static GameState Instance;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Instance = this;

    }

    void Update()
    {
        if(Input.GetButtonDown("Submit")){
            MenuStart();
            MenuEnd();
        }
    }

    public void IncreaseScore(int amount)
    {
        _score += amount;
        _scoreText.GetComponent<Text>().text = "Score: " + _score;
    }

    public void KeyRetrieve()
    {
        hasKey = true;
    }


    public void KeyCheck()
    {
        if(hasKey == true){
            hasKey = false;
            _sceneNum = _sceneNum + 1;
            SceneManager.LoadScene(_sceneNum, LoadSceneMode.Single);
        }
    }

    public void MenuStart()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0){
            _sceneNum = _sceneNum + 1;
            SceneManager.LoadScene(_sceneNum, LoadSceneMode.Single);
        }
    }

    public void MenuEnd()
    {
        if(SceneManager.GetActiveScene().buildIndex == 11){
            _score = 0;
            _sceneNum = 0;
            SceneManager.LoadScene(_sceneNum, LoadSceneMode.Single);
            Destroy(gameObject);
            Destroy(_scoreText);
        }
    }

}
