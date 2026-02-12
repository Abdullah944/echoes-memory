using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.Events;

namespace EchoesMemory.Editor
{
    /// <summary>
    /// Adds a full Main Menu UI (Canvas, title, Start/Quit buttons) to the current scene.
    /// Open your main menu scene (e.g. StartMenuUI) then run: Echoes Memory > Setup Main Menu UI in Scene
    /// </summary>
    public static class CreateMainMenuUI
    {
        private const string MenuPath = "Echoes Memory/Setup Main Menu UI in Scene";
        private const string OpenAndSetupPath = "Echoes Memory/Open Start Menu Scene and Setup UI";

        [MenuItem(OpenAndSetupPath)]
        public static void OpenStartMenuSceneAndSetup()
        {
            const string scenePath = "Assets/_Project/Scenes/Start_MenuUI.unity";
            var scene = EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);
            if (scene.IsValid())
                SetupMainMenuInCurrentScene();
            else
                Debug.LogError($"Scene not found: {scenePath}. Run '{MenuPath}' in your main menu scene instead.");
        }

        [MenuItem(MenuPath)]
        public static void SetupMainMenuInCurrentScene()
        {
            // Ensure we have an EventSystem
            if (Object.FindFirstObjectByType<EventSystem>() == null)
            {
                var eventSystemGo = new GameObject("EventSystem");
                eventSystemGo.AddComponent<EventSystem>();
                eventSystemGo.AddComponent<StandaloneInputModule>();
                Undo.RegisterCreatedObjectUndo(eventSystemGo, "Create EventSystem");
            }

            // Create Canvas
            var canvasGo = new GameObject("Canvas");
            var canvas = canvasGo.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasGo.AddComponent<CanvasScaler>().SetScaleWithScreenSize(1920, 1080);
            canvasGo.AddComponent<GraphicRaycaster>();

            var canvasTransform = canvasGo.transform;

            // Title
            var titleGo = CreateText("Title", "Echoes Memory", canvasTransform, 0, 120, 600, 80, 36);

            // Buttons
            var startButton = CreateButton("StartButton", "Start", canvasTransform, 0, 20, 220, 50);
            var quitButton = CreateButton("QuitButton", "Quit", canvasTransform, 0, -50, 220, 50);

            // Controller with MainMenuUI
            var controllerGo = new GameObject("MainMenuController");
            var mainMenuUI = controllerGo.AddComponent<MainMenuUI>();

            // Wire buttons (persistent so it saves in the scene)
            UnityEditor.Events.UnityEventTools.AddVoidPersistentListener(startButton.onClick, mainMenuUI.OnStartClicked);
            UnityEditor.Events.UnityEventTools.AddVoidPersistentListener(quitButton.onClick, mainMenuUI.OnQuitClicked);

            Undo.RegisterCreatedObjectUndo(canvasGo, "Create Main Menu UI");
            Undo.RegisterCreatedObjectUndo(controllerGo, "Create MainMenuController");

            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
            Debug.Log("Main Menu UI added to the current scene. Save the scene (Ctrl+S) to keep changes.");
        }

        private static GameObject CreateText(string name, string text, Transform parent, float x, float y, float w, float h, int fontSize = 24)
        {
            var go = new GameObject(name);
            go.transform.SetParent(parent, false);

            var rect = go.AddComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.5f, 0.5f);
            rect.anchorMax = new Vector2(0.5f, 0.5f);
            rect.pivot = new Vector2(0.5f, 0.5f);
            rect.anchoredPosition = new Vector2(x, y);
            rect.sizeDelta = new Vector2(w, h);

            var textComp = go.AddComponent<Text>();
            textComp.text = text;
            textComp.fontSize = fontSize;
            textComp.alignment = TextAnchor.MiddleCenter;
            textComp.color = Color.white;

            return go;
        }

        private static Button CreateButton(string name, string label, Transform parent, float x, float y, float w, float h)
        {
            var go = new GameObject(name);
            go.transform.SetParent(parent, false);

            var rect = go.AddComponent<RectTransform>();
            rect.anchorMin = new Vector2(0.5f, 0.5f);
            rect.anchorMax = new Vector2(0.5f, 0.5f);
            rect.pivot = new Vector2(0.5f, 0.5f);
            rect.anchoredPosition = new Vector2(x, y);
            rect.sizeDelta = new Vector2(w, h);

            var image = go.AddComponent<Image>();
            image.color = new Color(0.2f, 0.2f, 0.3f, 0.9f);

            var button = go.AddComponent<Button>();

            var labelGo = new GameObject("Text");
            labelGo.transform.SetParent(go.transform, false);
            var labelRect = labelGo.AddComponent<RectTransform>();
            labelRect.anchorMin = Vector2.zero;
            labelRect.anchorMax = Vector2.one;
            labelRect.offsetMin = Vector2.zero;
            labelRect.offsetMax = Vector2.zero;
            var labelText = labelGo.AddComponent<Text>();
            labelText.text = label;
            labelText.fontSize = 28;
            labelText.alignment = TextAnchor.MiddleCenter;
            labelText.color = Color.white;

            return button;
        }

        private static void SetScaleWithScreenSize(this CanvasScaler scaler, int refWidth, int refHeight)
        {
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(refWidth, refHeight);
            scaler.matchWidthOrHeight = 0.5f;
        }
    }
}
