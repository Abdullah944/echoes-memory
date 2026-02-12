# Home_Interior Scene — What’s Included

First scene after the main menu. Hero starts here; you can teach controls before the first level.

## Run setup once (in Unity)

- Menu: **Echoes Memory → Setup Home_Interior Scene**
- This adds to the scene:
  - **EventSystem** (for UI, e.g. controls hint)
  - **SpawnPoint** (with `SpawnPoint.cs`) at (0,0,0) — where the player will spawn
  - **Room** (empty parent) with **Bed** and **Door** (placeholder empties for Phase 3)

## Optional in the Editor

- **GameObject → Light → Global Light 2D** — if the scene is too dark (2D URP).
- Move **Bed** / **Door** in the Hierarchy to match your layout; add sprites or prefabs later.

## Next steps (from TODO)

- Phase 1: Add **Player** prefab, **PlayerMovement**, camera follow; spawn the player at **SpawnPoint** when the scene loads.
- Phase 3: **Bed** interaction (intro), **Door** transition to next scene.
