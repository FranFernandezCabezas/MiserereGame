using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUIHandler : MonoBehaviour
{
    [Tooltip("Determines the distance within the object and the player to show the pointer of the UI")]
    [SerializeField] private float rayDistance;
    [SerializeField] private GameObject pointer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
        {
            if (hit.transform.CompareTag("Interactable"))
            {
                pointer.SetActive(true);
            }
            else
            {
                pointer.SetActive(false);
            }
        } else
        {
            pointer.SetActive(false);
        }
    }
}
