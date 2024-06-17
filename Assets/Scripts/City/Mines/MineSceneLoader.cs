using UnityEngine;
using UnityEngine.SceneManagement;

public class MineSceneLoader : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene((int)SceneNames.Mines, LoadSceneMode.Additive);
    }
}