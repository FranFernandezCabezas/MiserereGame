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
            Destroy(this);
        }
        DontDestroyOnLoad(gameObject);
    }
    #endregion

<<<<<<< Updated upstream
    [SerializeField] private bool isGameStarted, isGameOver;
=======
>>>>>>> Stashed changes
    [SerializeField] private UIManager uiManager;
    [Space(10)]
    [Header("Game state booleans")]
    [SerializeField] public bool isGameStarted, isGameOver, isGamePaused;
    [Space(10)]
    [SerializeField] private PickUp currentPickUp;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameStarted && currentPickUp != null && Input.GetKeyDown(KeyCode.E))
        {
            uiManager.ShowExtraInfo(currentPickUp.infoText.text);
        }
    }
<<<<<<< Updated upstream
=======



    public void StartGame()
    {
        isGameStarted = true;
    }

    public void MakeGameOver()
    {
        isGameOver = true;
    }
>>>>>>> Stashed changes
}
