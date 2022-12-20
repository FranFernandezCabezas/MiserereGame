using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [TextArea(3, 10)]
    [SerializeField] public Text infoText;
    [SerializeField] private UIManager uiManager;

    private bool isPlayerHolding;

    private void Start()
    {

    }

    private void OnMouseDown()
    {
        uiManager.PickUpActive(sprite);
    }
}
