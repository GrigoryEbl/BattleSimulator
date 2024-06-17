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
        GameSaver.SetDefaultSettings();
    }

    [ContextMenu("SetFinalLevel")]
    public void SetFinalLevel()
    {
        GameSaver.SetLevel(5);
        GameSaver.SetMap(7);
    }

    [ContextMenu("CaptureScreenshot")]
    public void CaptureScreenshot()
    {
        ScreenCapture.CaptureScreenshot("Tutorial.png");
    }
}