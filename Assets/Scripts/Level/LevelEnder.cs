using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelEnder : MonoBehaviour
{
    private readonly WaitForSeconds _delay = new WaitForSeconds(5f);

    [SerializeField] private Button _startButton;
    [SerializeField] private Transform _enemySpawner;
    [SerializeField] private Transform _playerSpawner;

    [Header("Result Panels")]
    [SerializeField] private GameObject _drawPanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _congratulationsPanel;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(StartTryEndLevel);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(StartTryEndLevel);
    }

    private void StartTryEndLevel()
    {
        StartCoroutine(TryEndLevel());
    }

    private IEnumerator TryEndLevel()
    {
        while (_enemySpawner.childCount != 0 && _playerSpawner.childCount != 0)
            yield return _delay;

        if (_enemySpawner.childCount == 0 && _playerSpawner.childCount == 0)
        {
            _drawPanel.SetActive(true);
        }
        else
        {
            _congratulationsPanel.SetActive(_enemySpawner.childCount == 0);
            _gameOverPanel.SetActive(_playerSpawner.childCount == 0);
        }
    }
}