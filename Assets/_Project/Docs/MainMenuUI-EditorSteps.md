# Main Menu UI — What to Do in the Unity Engine

Do these steps **in the Unity Editor** only. No code required for the layout.

---

## 1. Open the scene

- **File → Open Scene** → open `Assets/Scenes/StartMenuUI.unity`  
  (or use menu **Echoes Memory → Open Start Menu Scene and Setup UI** to open it and add the UI in one go)

---

## 2. Add the UI in one go (recommended)

- Top menu: **Echoes Memory → Open Start Menu Scene and Setup UI**
- This creates: Canvas, EventSystem, title “Echoes Memory”, **Start** and **Quit** buttons, and wires them to the script.
- **File → Save Scene** (Ctrl+S / Cmd+S).

Skip to **Step 5** if you used this.

---

## 3. Or build the menu by hand

### Canvas

- **Hierarchy** → right‑click → **UI → Canvas**
- Unity creates a **Canvas** and an **EventSystem** if needed.
- Select **Canvas**:
  - **Canvas Scaler** (Inspector): **UI Scale Mode** = **Scale With Screen Size**, **Reference Resolution** 1920×1080, **Match** = 0.5.

### Title

- Right‑click **Canvas** → **UI → Text - TextMeshPro** (or **Text** if you use legacy UI).
- Rename to **Title**.
- **Rect Transform**: use anchor presets to center (e.g. top-center or middle-center), set width/height (e.g. 600×80), adjust **Pos Y** (e.g. 120).
- Set **Text** content to **Echoes Memory** and font size (e.g. 36).

### Start button

- Right‑click **Canvas** → **UI → Button - TextMeshPro** (or **Button**).
- Rename to **StartButton**.
- **Rect Transform**: center anchor, set width/height (e.g. 220×50), **Pos Y** (e.g. 20).
- Change the child **Text** to **Start**.

### Quit button

- Right‑click **Canvas** → **UI → Button - TextMeshPro** (or **Button**).
- Rename to **QuitButton**.
- **Rect Transform**: center anchor, width/height (e.g. 220×50), **Pos Y** (e.g. -50).
- Change the child **Text** to **Quit**.

### Hook up the script

- Create empty GameObject: **Hierarchy** → right‑click → **Create Empty**, name it **MainMenuController**.
- **Add Component** → search **Main Menu UI** (script from `_Project/Scripts/UI`).
- Select **StartButton** → in **Button** component, **On Click ()** → **+** → drag **MainMenuController** into the object field → choose **MainMenuUI → OnStartClicked ()**.
- Select **QuitButton** → **On Click ()** → **+** → drag **MainMenuController** → **MainMenuUI → OnQuitClicked ()**.
- Select **MainMenuController** → set **First Scene Name** (e.g. `Boot` or `Home_Interior`) when you have that scene.

---

## 4. Make it scale on different resolutions

- Select **Canvas**.
- **Canvas Scaler**: keep **Scale With Screen Size**, **Reference Resolution** 1920×1080, **Match** 0.5.
- For each UI element (title, buttons), set **Rect Transform** anchors to the desired position (e.g. center) so they stay in place when the window is resized.

---

## 5. Use this scene as the first screen

- **File → Build Settings**.
- Add **StartMenuUI** if it’s not in the list (drag the scene from the Project window).
- Drag **StartMenuUI** to the **top** of the Scenes In Build list so it’s the first scene.
- Press Play to start the game from the main menu.

---

## 6. Optional polish in the Editor

- **Canvas** or a full-screen **Image** under it: set a background colour or sprite.
- **Button** components: set **Normal / Highlighted / Pressed** colours in the Inspector.
- **Title**: choose Font, Size, Color in the Text (or TextMeshPro) component.

No code needed for any of the above; everything is done in the Engine (Hierarchy, Inspector, Build Settings).
