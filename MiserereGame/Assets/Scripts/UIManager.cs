using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    #region Singleton installments
    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Methods to open and close the menus of the UI
    public void OpenUICanvas(Canvas canvas)
    {
        canvas.gameObject.SetActive(true);
    }

    public void CloseUICanvas(Canvas canvas)
    {
        canvas.gameObject.SetActive(false);
    }


    public void LoadScene(int sceneInt)
    {
        SceneManager.LoadScene(sceneInt);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
