using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Image finishBtn;
    public int level = 0;
    public static GameManager instance;
    private bool _isFinish;
    
    public bool isFinish
    {
        get => _isFinish;
        set
        {
            _isFinish = value;
            if(_isFinish == true)
            {
                finishBtn.gameObject.SetActive(true);
            }
        }
    }
    private void Awake()
    {
        //GameManager[] objs = GameObject.FindObjectsOfType<GameManager>();
        //if (objs.Length > 1)
        //{
        //    Destroy(this.gameObject);
        //}

        //if (instance == null)
            instance = this;
        //DontDestroyOnLoad(this.gameObject);
        //Debug.Log(SceneManager.sceneCountInBuildSettings);
            
    }
    public void NextLevel()
    {
        if (level >= SceneManager.sceneCountInBuildSettings - 1)
        {
            level = 0;
        }
        else
            level++;
        finishBtn.gameObject.SetActive(false);
        SceneManager.LoadScene(level);
    }
}
