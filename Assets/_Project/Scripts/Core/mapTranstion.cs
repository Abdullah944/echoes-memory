//? From the video: trigger changes camera boundary and nudges player in a direction. No E, automatic on enter.
//? Cooldown prevents the other waypoint from firing right after and pulling the hero back.

using UnityEngine;
using Cinemachine;

public class MapTransition : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] PolygonCollider2D mapBoundary;
    [SerializeField] CinemachineConfiner2D confiner;

    [Header("Player nudge")]
    [SerializeField] Direction direction = Direction.Up;
    [SerializeField] float additivePos = 2f;

    [Header("Cooldown")]
    [Tooltip("Seconds before another waypoint can trigger (stops hero being pulled back).")]
    [SerializeField] float cooldownSeconds = 0.5f;

    static float lastTransitionTime;

    public enum Direction { Up, Down, Left, Right }

    void Awake()
    {
        if (confiner == null)
            confiner = FindObjectOfType<CinemachineConfiner2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        if (Time.time - lastTransitionTime < cooldownSeconds) return;

        lastTransitionTime = Time.time;

        if (mapBoundary != null && confiner != null)
            confiner.m_BoundingShape2D = mapBoundary;

        UpdatePlayerPosition(collision.gameObject);
    }

    void UpdatePlayerPosition(GameObject player)
    {
        Vector3 newPos = player.transform.position;
        switch (direction)
        {
            case Direction.Up:   newPos.y += additivePos; break;
            case Direction.Down: newPos.y -= additivePos; break;
            case Direction.Left: newPos.x -= additivePos; break;
            case Direction.Right: newPos.x += additivePos; break;
        }
        player.transform.position = newPos;
    }
}