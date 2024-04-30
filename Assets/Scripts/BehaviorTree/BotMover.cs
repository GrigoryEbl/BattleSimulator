using UnityEngine;

[RequireComponent(typeof(BotInput))]
//[RequireComponent(typeof(SearcherTarget))]
public class BotMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    //private SearcherTarget _searcherTarget;
    private Transform _transform;
    private BotInput _botInput;

    private void Awake()
    {
        _transform = transform;
        _botInput = GetComponent<BotInput>();
        //_searcherTarget = GetComponent<SearcherTarget>();

        //_searcherTarget.GetTarget();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _transform.Translate(_botInput.MovementInput * _speed * Time.deltaTime);
    }
}
