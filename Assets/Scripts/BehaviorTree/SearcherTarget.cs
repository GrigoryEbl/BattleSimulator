
using UnityEngine;

public class SearcherTarget : MonoBehaviour
{
    [SerializeField] private Transform _enemySquad;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    public Transform GetTarget()
    {
        Transform[] enemiesPositions = new Transform[_enemySquad.childCount];
        float[] distance = new float[_enemySquad.childCount];

        for (int i = 0; i < _enemySquad.childCount; i++)
        {
            enemiesPositions[i] = _enemySquad.GetChild(i);
            distance[i] = Vector3.Distance(_transform.position, enemiesPositions[i].position);
        }

        enemiesPositions = SortDistance(enemiesPositions);
        print(enemiesPositions[0].gameObject.name);
        return enemiesPositions[0];
    }

    private Transform[] SortDistance(Transform[] unitsPosition)
    {
        Transform temp;

        for (int i = 0; i < unitsPosition.Length; i++)
        {
            for (int j = i + 1; j < unitsPosition.Length; j++)
            {
                if (Vector3.Distance(_transform.position, unitsPosition[i].position) > Vector3.Distance(_transform.position, unitsPosition[j].position))
                {
                    temp = unitsPosition[i];
                    unitsPosition[i] = unitsPosition[j];
                    unitsPosition[j] = temp;
                }
            }
        }

        return unitsPosition;
    }
}
