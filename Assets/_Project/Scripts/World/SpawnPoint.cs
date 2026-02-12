using UnityEngine;

/// <summary>
/// Marks a position in the scene where the player (or other entity) can spawn.
/// Used by SceneLoader or game init to place the player when loading a scene.
/// </summary>
public class SpawnPoint : MonoBehaviour
{
    [Header("Identity")]
    [Tooltip("Optional id (e.g. 'default', 'bed', 'door_exterior'). Leave empty for default spawn.")]
    [SerializeField] private string spawnId = "default";

    /// <summary>World position and rotation for spawning.</summary>
    public Vector3 Position => transform.position;
    public Quaternion Rotation => transform.rotation;

    public string SpawnId => spawnId;
}
