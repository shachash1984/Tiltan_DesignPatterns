using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UPersian;
using System;

public class ControlPanelManager : MonoBehaviour {

    static public ControlPanelManager S;
    static UnlockablePanel selectedPanel;
    public GameObject unlockablePanelPrefab;
    public List<UnlockablePanel> unlockablePanels = new List<UnlockablePanel>();
    public InputField questNameInputField;
    [SerializeField] private RectTransform _listContent;
    [SerializeField] private GameObject _messagePanel;
    [SerializeField] private Text _messageHeadline;
    [SerializeField] private Text _messageContent;
    [SerializeField] private Text _errorContent;
    [SerializeField] private Text _unlockableCounter;


    private void Awake()
    {
        if (S != null)
            Destroy(gameObject);
        S = this;
        DismissMessage();
    }

    private void Start()
    {
        UpdateUnlockableCounter();
    }

    private void DisplayMessage(string hl, string content, string error = "")
    {
        _messageHeadline.text = hl;
        _messageContent.text = content;
        _errorContent.text = error;
        _messagePanel.SetActive(true);
    }

    public void DismissMessage()
    {
        _messagePanel.SetActive(false);
    }

    public void Save()
    {
        Debug.Log("Quest Saved... (not really)");
        Clear();
        DisplayMessage("Quest saved", "New quest saved successfully");
    }

    public void AddPanel()
    {
        GameObject newPanel = Instantiate(unlockablePanelPrefab, _listContent.position, Quaternion.identity, _listContent);
        Vector3 wantedPos = _listContent.position;
        newPanel.transform.localPosition = wantedPos;
        UnlockablePanel up = newPanel.GetComponent<UnlockablePanel>();
        unlockablePanels.Add(up);
        unlockablePanels[unlockablePanels.Count-1].index = unlockablePanels.IndexOf(up);
        UpdateUnlockableCounter();
    }


    public void RemoveSelectedPanel()
    {
        if (selectedPanel)
        {
            
            unlockablePanels.Remove(selectedPanel);
            Destroy(selectedPanel.gameObject);
            selectedPanel = null;
            UpdateUnlockableCounter();
        }
        else
            DisplayMessage("No panel selected", "Please select panel to remove");
    }

    public void SelectPanel(UnlockablePanel up)
    {
        if (selectedPanel)
            selectedPanel.ChangeColor(Color.white);
        selectedPanel = up;
        selectedPanel.ChangeColor(Color.green);
    }

    public void AllignPanel(UnlockablePanel sip)
    {
        if (unlockablePanels.Count > 1)
            sip.transform.localPosition = unlockablePanels[unlockablePanels.IndexOf(sip) - 1].transform.localPosition;
    }

    public void Clear()
    {
        foreach (UnlockablePanel sip in unlockablePanels)
        {
            Destroy(sip.gameObject);
        }
        unlockablePanels.Clear();
        questNameInputField.text = "";
    }

    public void UpdateUnlockableCounter()
    {
        _unlockableCounter.text = unlockablePanels.Count.ToString();
    }
}
