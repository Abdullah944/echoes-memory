using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace EchoesMemory.Editor
{
    /// <summary>
    /// Sets up the Home_Interior scene with EventSystem, SpawnPoint, and Room/Bed/Door placeholders.
    /// Run: Echoes Memory > Setup Home_Interior Scene
    /// </summary>
    public static class SetupHomeInteriorScene
    {
        private const string ScenePath = "Assets/_Project/Scenes/Home_Interior.unity";
        private const string MenuPath = "Echoes Memory/Setup Home_Interior Scene";

        [MenuItem(MenuPath)]
        public static void Setup()
        {
            var scene = EditorSceneManager.OpenScene(ScenePath, OpenSceneMode.Single);
            if (!scene.IsValid())
            {
                Debug.LogError($"Scene not found: {ScenePath}");
                return;
            }

            // EventSystem (for UI when we add controls hint)
            if (Object.FindFirstObjectByType<EventSystem>() == null)
            {
                var es = new GameObject("EventSystem");
                es.AddComponent<EventSystem>();
                es.AddComponent<StandaloneInputModule>();
                Undo.RegisterCreatedObjectUndo(es, "Create EventSystem");
            }

            // SpawnPoint — where the player will spawn (e.g. by the bed)
            if (Object.FindFirstObjectByType<SpawnPoint>() == null)
            {
                var spawn = new GameObject("SpawnPoint");
                spawn.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);
                spawn.AddComponent<SpawnPoint>();
                Undo.RegisterCreatedObjectUndo(spawn, "Create SpawnPoint");
            }

            // Room structure: Room (parent) -> Bed, Door (placeholders for Phase 3)
            var room = GameObject.Find("Room");
            if (room == null)
            {
                room = new GameObject("Room");
                Undo.RegisterCreatedObjectUndo(room, "Create Room");

                var bed = new GameObject("Bed");
                bed.transform.SetParent(room.transform);
                bed.transform.localPosition = new Vector3(-2f, 0f, 0f); // left side
                Undo.RegisterCreatedObjectUndo(bed, "Create Bed");

                var door = new GameObject("Door");
                door.transform.SetParent(room.transform);
                door.transform.localPosition = new Vector3(3f, 0f, 0f); // right side
                Undo.RegisterCreatedObjectUndo(door, "Create Door");
            }

            EditorSceneManager.MarkSceneDirty(scene);
            EditorSceneManager.SaveScene(scene);
            Debug.Log("Home_Interior setup complete: EventSystem, SpawnPoint, Room (Bed, Door). Add Global Light 2D from GameObject > Light > Global Light 2D if needed.");
        }
    }
}
