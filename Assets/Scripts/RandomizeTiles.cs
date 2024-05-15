using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeTiles : MonoBehaviour
{
    private void Awake()
    {
        float[] grads = new float[4] { 0f, 90f, 180f, 270f };

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).transform.rotation = Quaternion.Euler(0, grads[Random.Range(0, 4)], 0);
        }
    }
}
