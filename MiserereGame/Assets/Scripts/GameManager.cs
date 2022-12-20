using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singleton installments
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    [SerializeField] public bool isGameStarted, isGameOver, isGamePaused;
    [SerializeField] private UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        isGamePaused = false;
        isGameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        isGameStarted = true;
    }

    public void MakeGameOver()
    {
        isGameOver = true;
    }
}
