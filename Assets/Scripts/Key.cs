using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, Interactable {

    public int index;
    public string key;

    public void Action()
    {
        FindKey();
    }

    public void FindKey()
    {
        gameObject.SetActive(false);
        Player.S.SetMainText(string.Format("You have found a {0}.", name));
        Player.S.AddKeyToInventory(index, this);
    }
}
