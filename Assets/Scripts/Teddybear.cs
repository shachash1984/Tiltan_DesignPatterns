using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teddybear : MonoBehaviour, Interactable {

    public void Action()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        Player.S.SetMainText("Congratulations!\nYou have found the Teddybear!");
    }
}
