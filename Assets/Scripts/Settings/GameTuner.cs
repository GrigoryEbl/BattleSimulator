using UnityEngine;

public class GameTuner : MonoBehaviour
{
    private void Awake()
    {
        if (!PlayerPrefs.HasKey(gameObject.name))
            SetDefaultSettings();
    }

    private void SetDefaultSettings()
    {
        PlayerPrefs.SetInt(GameSaver.CurrentLevel, 1);
        PlayerPrefs.SetInt(GameSaver.CurrentMap, 3);

        PlayerPrefs.SetString("SoldierHouse", true.ToString());
        PlayerPrefs.SetString(gameObject.name, true.ToString());

        PlayerPrefs.Save();
    }
}