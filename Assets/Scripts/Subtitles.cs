using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Subtitles : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI subtitleText = default;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private GameObject _bg;

    public static Subtitles instance;

    private void Awake()
    {
        instance = this;
        ClearSubtitle(); 
        
    }

    public void SetSubtitle(string subtitle, float delay)
    {
        subtitleText.text = subtitle;
        _name.text = "Jason:";
        if(!_bg.activeSelf)
            _bg.SetActive(true);
        StartCoroutine(ClearAfterSeconds(delay));
    }
    
    public void ClearSubtitle()
    {
        subtitleText.text = "";
        _name.text = "";
        _bg.SetActive(false);
    }

    private IEnumerator ClearAfterSeconds(float delay)
    {
        yield return new WaitForSeconds(delay);
        ClearSubtitle();
    }
    
}
