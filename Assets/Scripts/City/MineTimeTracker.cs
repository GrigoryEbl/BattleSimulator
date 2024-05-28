using UnityEngine;

public class MineTimeTracker : MonoBehaviour
{
    public static MineTimeTracker Instance;

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
}
