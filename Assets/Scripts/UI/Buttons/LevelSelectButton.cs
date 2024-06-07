using System;
using UnityEngine;
using UnityEngine.UI;
using YG;

[RequireComponent(typeof(Button))]
public class LevelSelectButton : MonoBehaviour
{
    [Range(3, 7)]
    [Tooltip("3 - Forest, 4 - Volcanic, 5 - Tropics, 6 - Winter, 7 - Castle")]
    [SerializeField] private int _sceneNumber;

    [Range(1, 5)]
    [SerializeField] private int _levelNumber;
    [SerializeField] private SelectiveSceneLoader _sceneLoader;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(SelectLevel);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(SelectLevel);
    }

    private void SelectLevel()
    {
        YandexGame.savesData.CurrentLevel = _levelNumber;
        YandexGame.SaveProgress();

        _sceneLoader.SelectScene(_sceneNumber);
        _sceneLoader.Load();
    }
}