using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class VideoAd : MonoBehaviour
{
    [SerializeField] private Menu _menu;

    private Button _lockableButton;

    public void Show(Button lockableButton, UnityAction<int> moneyAction, int money)
    {
        _lockableButton = lockableButton;
        Agava.YandexGames.VideoAd.Show(OnOpenCallback, () => moneyAction?.Invoke(money), OnCloseCallback);
    }

    private void OnOpenCallback()
    {
        _menu.StopTime();
        _menu.StopMusic();

        _lockableButton.interactable = false;
    }

    private void OnCloseCallback()
    {
        _menu.ContinueTime();
        _menu.ContinueMusic();

        _lockableButton.interactable = true;
    }
}