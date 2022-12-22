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

    private int puzzlesSolved;
    public UIManager UIManager { get { return uiManager; } }
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        isGameStarted = true;
        isGameOver = false;
        isGamePaused = false;
        puzzlesSolved = 0;
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        isGamePaused = true;
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isGamePaused = false;
    }
    public void MakeGameOver()
    {
        isGameOver = true;
    }

    public void PuzzleSolved()
    {
        switch(puzzlesSolved)
        {
            case 0:
                break; case 1: break; default: break;
        }
    }
}
