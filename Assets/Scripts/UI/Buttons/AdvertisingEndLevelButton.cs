using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AdvertisingEndLevelButton : MonoBehaviour
{
    [SerializeField] private VideoAd _videoAd;
    [SerializeField] private TunableSceneLoader _sceneLoader;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(FinishLevel);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(FinishLevel);
    }

    private void FinishLevel()
    {
        //Добавить сохранение прогресса

#if UNITY_WEBGL && !UNITY_EDITOR
        _videoAd.Show(_button, _sceneLoader.Load);
#else
        _sceneLoader.Load();
#endif
    }
}