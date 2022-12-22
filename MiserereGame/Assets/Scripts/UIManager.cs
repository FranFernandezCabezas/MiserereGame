using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{


    [Header("Pause menu Canvas")]
    [SerializeField] private Canvas pauseMenuCanvas;
    [Space(10)]
    [SerializeField] private Canvas textCanvas;
    [SerializeField] private TMP_Text text;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        if (gameManager != null) gameManager.StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameManager.isGameStarted && !gameManager.isGameOver)
        {
            ManagePauseMenu();
        }
    }

    public void ShowPickUpText(string pickUpText)
    {
        gameManager.PauseGame();
        textCanvas.gameObject.SetActive(true);
        text.text = pickUpText;
    }

    public void ClosePickUpText()
    {
        textCanvas.gameObject.SetActive(false);
        text.text = "";
        gameManager.ResumeGame();
    }


    public void ManagePauseMenu()
    {
        if (pauseMenuCanvas.isActiveAndEnabled)
        {
            gameManager.ResumeGame();
            CloseUICanvas(pauseMenuCanvas);
        }
        else
        {
            gameManager.PauseGame();
            OpenUICanvas(pauseMenuCanvas);
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
