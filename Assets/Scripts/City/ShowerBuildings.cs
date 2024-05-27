using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class ShowerBuildings : MonoBehaviour
{
   public void Show()
    {
        for (int i = 0; i < YandexGame.savesData.OpenedBuildings.Count; i++)
        {
            print(YandexGame.savesData.OpenedBuildings[i]);
        }
    }
}
