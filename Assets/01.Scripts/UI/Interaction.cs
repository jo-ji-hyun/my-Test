using System;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public int id;
    public static event Action<int> OnStartDialogued;
    
    public GameObject interactionPanel;
    public GameObject TextPanel;

    private bool _playerInRange = false;

    private void Start()
    {
        interactionPanel.SetActive(false);
    }

    private void OnTriggerEnter2D()
    {
        interactionPanel.SetActive(true);
        _playerInRange = true;
    }

    private void OnTriggerExit2D()
    {
        interactionPanel.SetActive(false);
        _playerInRange = false;
    }

    private void Update()
    {
        if (_playerInRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TextPanel.SetActive(true);
                OnStartDialogued?.Invoke(id);
            }
        }
    }
}
