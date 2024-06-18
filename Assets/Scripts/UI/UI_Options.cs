using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Options : MonoBehaviour
{
    [SerializeField] private Button saveButton;

    private void Start()
    {
        saveButton.onClick.AddListener(Save);
    }

    public void Save()
    {
        SaveManager.instance.SaveGame();
    }
}
