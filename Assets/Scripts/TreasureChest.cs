using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TreasureChest : Unlockable, Interactable {

    public float xRotAmount = -70f;
    public bool isOpen = false;
    private Vector3 _initialRotation;
    private Transform _lid;


    private void Start()
    {
        _lid = transform.GetChild(0);
        _initialRotation = _lid.transform.localRotation.eulerAngles;
    }

    public void Action()
    {
        if (!DOTween.IsTweening(transform))
            OpenLid(!isOpen);
    }

    public void OpenLid(bool open)
    {
        if (!locked)
        {
            if (open)
            {
                if (!isOpen)
                {
                    Vector3 wantedRot = _initialRotation;
                    wantedRot.x += xRotAmount;
                    _lid.transform.DOLocalRotate(wantedRot, 1f).OnComplete(() => isOpen = true);
                }
            }
            else
            {
                if (isOpen)
                {
                    Vector3 wantedRot = Vector3.zero;
                    _lid.transform.DOLocalRotate(wantedRot, 1f).OnComplete(() => isOpen = false);
                }
            }
        }
    }
}
