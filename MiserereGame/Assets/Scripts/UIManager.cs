using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
<<<<<<< Updated upstream
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
=======


    [Header("Pause menu Canvas")]
    [SerializeField] private Canvas pauseMenuCanvas;
    private GameManager gameManager;

    [Header("Sprite Canvas")]
    [SerializeField] private Canvas spriteCanvas;
    [SerializeField] private Image spriteImage;
>>>>>>> Stashed changes


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        
=======
        if (Input.GetKeyDown(KeyCode.P) && gameManager.isGameStarted && !gameManager.isGameOver)
        {
            ManagePauseMenu();
        }
    }

    public void PickUpActive(Sprite sprite)
    {
        spriteImage = spriteCanvas.GetComponentInChildren<Image>();
        spriteImage.sprite = sprite;
    }

    public void ShowExtraInfo(string info)
    {

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
>>>>>>> Stashed changes
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
        gameManager.isGamePaused = false;
        SceneManager.LoadScene(sceneInt);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
