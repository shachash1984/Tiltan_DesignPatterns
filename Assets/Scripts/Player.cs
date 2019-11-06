using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Player : MonoBehaviour {

    
    static public Player S;
    private Transform _playerCam;
    private Coroutine fadeCoroutine;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Text _mainText;
    [SerializeField] private Image _blueKey;
    [SerializeField] private Image _yellowKey;
    private List<string> _keys = new List<string>();

    private void Awake()
    {
        S = this;
        _blueKey.gameObject.SetActive(false);
        _yellowKey.gameObject.SetActive(false);
    }

    private void Start()
    {
        SetMainText("Find the Teddybear...");
        _playerCam = transform.GetChild(0);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            DoAction();
    }

    public void DoAction()
    {
        RaycastHit hit;
        Ray ray = new Ray(_playerCam.position, _playerCam.forward);
        if(Physics.Raycast(ray, out hit, 3f ,_layerMask))
        {
            Interactable i = hit.collider.GetComponent<Interactable>();
            if (i != null)
            {
                i.Action();
                Unlockable u = hit.collider.GetComponent<Unlockable>();
                if (u)
                    UseKey(u);
            }
        }
    }

    public void SetMainText(string str)
    {
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);
        DOTween.KillAll();
        _mainText.text = "";
        _mainText.DOFade(1f, 0f);
        _mainText.DOText(str, 1f);
        fadeCoroutine = StartCoroutine(FadeOutText());
    }

    IEnumerator FadeOutText()
    {
        yield return new WaitForSeconds(3f);
        _mainText.DOFade(0f, 1f);
    }

    public void AddKeyToInventory(int index, Key k)
    {
        if (index == 0)
            _blueKey.gameObject.SetActive(true);
        else
            _yellowKey.gameObject.SetActive(true);

        _keys.Add(k.key);
    }

    public void UseKey(Unlockable u)
    {
        foreach (string s in _keys)
        {
            if (s == u.key)
                u.Unlock(s);
        }
    }

    public void AddKey(string key)
    {
        _keys.Add(key);
    }


}
