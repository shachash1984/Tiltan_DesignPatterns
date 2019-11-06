using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockablePanel : MonoBehaviour {

    public int index;
    private InputField _nameInputField;
    private InputField _keyInputField;
    private InputField _commentInputField;
    public const float TILE_SIZE = 5f;
    public const float WAIT_TIME = 3.5f;

    private void Awake()
    {
        Init();
    }

    private void OnMouseDown()
    {
        ControlPanelManager.S.SelectPanel(this);
    }

    private void Init()
    {
        _nameInputField = transform.GetChild(1).GetComponent<InputField>();
        _keyInputField = transform.GetChild(3).GetComponent<InputField>();
        _commentInputField = transform.GetChild(5).GetComponent<InputField>();
        
    }

    public void DisableFields()
    {
        _nameInputField.interactable = false;
        _keyInputField.interactable = false;
        _commentInputField.interactable = false;
    }

    public void ChangeColor(Color c)
    {
        GetComponent<Image>().color = c;
    }
}

