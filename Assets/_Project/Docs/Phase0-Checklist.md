# Phase 0 — Setup (one by one, best practice)

Use this list in order. Check off in the README when done.

---

## 1. Create project folders — DONE

- [x] _Project with Scenes, Prefabs, Scripts, Art, Audio, Docs, Editor, ScriptableObjects.

---

## 2. Setup Input System — **NEXT**

**Best practice (Unity docs + web):**

- [ ] **Player Settings:** Edit → Project Settings → Player → Other Settings → **Active Input Handling** = **Input System Package (New)** or **Both**. (Your project has `activeInputHandler: 1` = new Input System.)
- [ ] **Input System settings:** Edit → Project Settings → **Input System Package**. If you see **Create settings asset**, click it once. Then leave **Update Mode** as default unless you need fixed-timestep input.
- [ ] **Project-wide Actions:** Edit → Project Settings → Input System Package → **Input Actions**. Either **Create and assign a default project-wide Action Asset** (Unity’s default) **or** assign your existing **InputSystem_Actions** asset so it’s the project-wide one. You already have `InputSystem_Actions.inputactions` with Player (Move, Attack, Interact, etc.) — assign that if you prefer it over the built-in default.
- [ ] **UI + new Input System:** Scenes that use UI need an EventSystem with **Input System UI Input Module** (not only Standalone Input Module). Add component **Input System UI Input Module** to the EventSystem in Start_MenuUI and Home_Interior if you use the new Input System for UI.

**Optional:** Right‑click `InputSystem_Actions.inputactions` → **Generate C# Class** for type-safe access in code.

When the above is done, mark **Setup Input System** in the README TODO.

---

## 3. Setup Cinemachine

- [ ] Package Manager → install **Cinemachine** (com.unity.cinemachine).
- [ ] In gameplay scenes (e.g. Home_Interior): add **Cinemachine Virtual Camera**, set Follow to the Player transform (when you have the player). Use 2D if your game is 2D.

---

## 4. Create scenes

- [x] Home_Interior (created; use **Echoes Memory → Setup Home_Interior Scene** once).
- [ ] Boot (optional; can be a minimal init scene).
- [ ] Home_Exterior.
- [ ] Desert_A.

Create via File → New Scene, save under **Assets/_Project/Scenes/**. Add each to Build Settings / Scene List.

---

## 5. Create SceneLoader system

- [ ] Script **SceneLoader.cs** in **Scripts/Core**: load scene by name (e.g. `SceneManager.LoadSceneAsync`), optional fade. MainMenuUI can call it; later, doors and triggers call it with a target scene name and optional spawn id.

---

**Current next step:** Do **Setup Input System** (section 2) in Unity, then move to **Setup Cinemachine** (section 3).
