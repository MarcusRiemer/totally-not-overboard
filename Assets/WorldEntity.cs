using UnityEngine;

public class WorldEntity : MonoBehaviour
{
    protected WorldRoot worldRoot;

    protected void Start()
    {
        worldRoot = transform.root.GetComponentInChildren<WorldRoot>();
        Debug.Assert(worldRoot != null, $"{GetType().Name} has no world");
        
        WorldStart();
    }

    protected virtual void WorldStart()
    {
        
    }
}