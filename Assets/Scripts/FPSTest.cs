using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSTest : MonoBehaviour
{
    public static FPSTest Instance;

    [SerializeField] private TMP_Text _fpsText;

    private float _fps;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (this != Instance)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        _fps = 1.0f / Time.deltaTime;
        _fpsText.text = $"FPS:{(int)_fps}";
    }
}
