using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{


    [Header("Pause menu Canvas")]
    [SerializeField] private Canvas pauseMenuCanvas;


    #region Singleton installments
    public static UIManager Instance;
    private GameManager gameManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance.pauseMenuCanvas == null)
            {
                Instance.pauseMenuCanvas = pauseMenuCanvas;
            }
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && gameManager.isGameStarted && !gameManager.isGameOver)
        {
            ManagePauseMenu();
        }
    }

    public void ManagePauseMenu()
    {
        if (pauseMenuCanvas.isActiveAndEnabled)
        {
            CloseUICanvas(pauseMenuCanvas);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            gameManager.isGamePaused = false;
        }
        else
        {
            OpenUICanvas(pauseMenuCanvas);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            gameManager.isGamePaused = true;
        }
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
