using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Drawer : MonoBehaviour, Interactable {

    public float xOpen = 0.3f;
    public bool isOpen = false;
    private Vector3 _initialPosition;
    

    private void Start()
    {
        _initialPosition = transform.localPosition;
    }

    public void Action()
    {
        if (!DOTween.IsTweening(transform))
            OpenDrawer(!isOpen);
    }

    public void OpenDrawer(bool open)
    {
        if (open)
        {
            if (!isOpen)
                transform.DOLocalMoveX(transform.localPosition.x + xOpen, 1f).OnComplete(()=> isOpen = true);
            
        }
        else
        {
            if(isOpen)
                transform.DOLocalMoveX(transform.localPosition.x - xOpen, 1f).OnComplete(() => isOpen = false);
        }
    }
}
