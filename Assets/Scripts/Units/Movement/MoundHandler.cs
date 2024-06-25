using BehaviorDesigner.Runtime;
using BS.Units;
using UnityEngine;

[RequireComponent(typeof(RagdollHandler))]
public class MoundHandler : MonoBehaviour
{
    private readonly float _delay = 10f;

    private float _delayCounter;
    private RagdollHandler _unitRagdoll;
    private BehaviorTree _behaviorTree;

    private void Awake()
    {
        _unitRagdoll = GetComponent<RagdollHandler>();
        _behaviorTree = GetComponent<BehaviorTree>();
    }

    private void Update()
    {
        if (_delayCounter > 0)
            _delayCounter -= Time.deltaTime;
    }

    public void Fell()
    {
        if (_delayCounter > 0 || _behaviorTree.enabled == false)
            return;

        _unitRagdoll.TurnOn(true);
        _delayCounter = _delay;
    }
}