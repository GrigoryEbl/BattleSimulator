using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] private float _delay = 0.3f;

    private float _elapsedTime;

    private void Update()
    {
        if (_elapsedTime > 0)
            _elapsedTime -= Time.deltaTime;
    }

    private void OnTriggerStay(Collider other)
    {
        if (_elapsedTime <= 0 && other.TryGetComponent(out Unit unit))
        {
            _elapsedTime = _delay;
            Debug.Log("”рон от лавы!");
        }
    }
}