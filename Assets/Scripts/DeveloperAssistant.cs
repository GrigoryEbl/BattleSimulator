using Lean.Localization;
using UnityEngine;

public class DeveloperAssistant : MonoBehaviour
{
    [ContextMenu("SetEnglish")]
    public void SetEnglish() => LeanLocalization.SetCurrentLanguageAll("English");

    [ContextMenu("SetTurkish")]
    public void SetTurkish() => LeanLocalization.SetCurrentLanguageAll("Turkish");

    [ContextMenu("SetRussian")]
    public void SetRussian() => LeanLocalization.SetCurrentLanguageAll("Russian");

    [ContextMenu("Reset")]
    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetInt(GameSaver.CurrentLevel, 1);
        PlayerPrefs.SetInt(GameSaver.CurrentMap, 3);

        PlayerPrefs.SetFloat(GameSaver.Volume, 1f);

        PlayerPrefs.SetString("SoldierHouse", true.ToString());
        PlayerPrefs.SetString(gameObject.name, true.ToString());

        PlayerPrefs.Save();
    }

    [ContextMenu("SetFinalLevel")]
    public void SetFinalLevel()
    {
        PlayerPrefs.SetInt(GameSaver.CurrentLevel, 5);
        PlayerPrefs.SetInt(GameSaver.CurrentMap, 7);
        PlayerPrefs.Save();
    }

    [ContextMenu("CaptureScreenshot")]
    public void CaptureScreenshot()
    {
        ScreenCapture.CaptureScreenshot("Tutorial.png");
    }
}