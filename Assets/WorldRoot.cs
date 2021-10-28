using UnityEngine;

/// <summary>
/// Global world state that effects a multitude of entities anywhere in the scene.
/// Can be automatically referenced by deriving from <see cref="WorldEntity"/>.
/// </summary>
public class WorldRoot : MonoBehaviour
{
    /// <summary>
    /// Current direction of wind in degrees [0°-360°)
    /// </summary>
    [Range(0f, 359.9999f)]
    public float windDirection = 0;

    /// <summary>
    /// A quaternion that is correctly rotated according to the current wind
    /// </summary>
    public Quaternion windRotation => Quaternion.Euler(0, -windDirection + 90, 0);
}
