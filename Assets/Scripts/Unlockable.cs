using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlockable : MonoBehaviour {

    public string key;
    public bool locked = true;

    public bool Unlock(string k)
    {
        if (k.Equals(key))
        {
            locked = false;
            return true;
        }
        return false;
    }
}
