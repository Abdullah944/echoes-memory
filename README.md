# Echoes Memory — 2D Top-Down Adventure (Unity)

A Zelda-inspired 2D top-down adventure game.
Story: A boy wakes up with no memories and explores Kuwait-inspired lands, starting in the desert.

Engine: Unity (2D)
Language: C#
Platform: Steam (PC)

---

## 🎯 Project Goal (MVP)

Playable demo with:
- Start at home (bed intro)
- Leave home
- Enter desert
- Fight enemies
- Collect memory fragment
- Save game

---

## 📁 Folder Structure

Assets/
 └── _Project/
     ├── Scenes/
     ├── Prefabs/
     ├── Scripts/
     │   ├── Core/
     │   ├── Player/
     │   ├── Combat/
     │   ├── Interact/
     │   ├── UI/
     │   └── World/
     ├── Art/
     ├── Audio/
     └── ScriptableObjects/

---

## ✅ DEVELOPMENT TODO LIST

---

# PHASE 0 — Setup

- [x] Create project folders
- [ ] Setup Input System
- [ ] Setup Cinemachine
- [ ] Create scenes:
  - Boot
  - Home_Interior
  - Home_Exterior
  - Desert_A
- [ ] Create SceneLoader system

---

# PHASE 1 — Player Movement

- [ ] Create Player prefab
- [ ] Add Rigidbody2D + Collider2D
- [ ] Implement 8-direction movement
- [ ] Store LastFacingDirection
- [ ] Setup camera follow

Files:
- PlayerMovement.cs

---

# PHASE 2 — Combat (Sword)

- [ ] Create IDamageable interface
- [ ] Create PlayerCombat
- [ ] Create SwordHitbox prefab
- [ ] Add cooldown system
- [ ] Add knockback
- [ ] Create PlayerHealth
- [ ] Create EnemyChaser
- [ ] Create EnemyHealth

Files:
- PlayerCombat.cs
- SwordHitbox.cs
- EnemyHealth.cs
- EnemyChaser.cs

---

# PHASE 3 — Interaction + Dialogue

- [ ] Create IInteractable interface
- [ ] Create PlayerInteractor
- [ ] Create DialogueManager
- [ ] Create intro bed interaction
- [ ] Create door transitions

Files:
- PlayerInteractor.cs
- DialogueManager.cs

---

# PHASE 4 — World Loading

- [ ] Create SpawnPoint system
- [ ] Create scene fade system
- [ ] Implement spawn after load

Files:
- SceneLoader.cs
- SpawnPoint.cs

---

# PHASE 5 — Desert MVP

- [ ] Build desert map
- [ ] Add enemy spawns
- [ ] Add ranged enemy
- [ ] Add memory item pickup
- [ ] Add locked gate
- [ ] Add reward

---

# PHASE 6 — Quest + Memory System

- [ ] Create QuestManager
- [ ] Create MemoryManager
- [ ] Add objective UI
- [ ] Add journal screen

Files:
- QuestManager.cs
- MemoryManager.cs

---

# PHASE 7 — Tools (After MVP)

- [ ] Bomb system
- [ ] Boomerang system
- [ ] Bow system

---

# PHASE 8 — Save System

- [ ] JSON save file
- [ ] Save on doors
- [ ] Manual save at bed
- [ ] Load on boot

Files:
- SaveSystem.cs

---

# PHASE 9 — Steam Release

- [ ] Settings menu
- [ ] Resolution options
- [ ] Controller support
- [ ] Build pipeline

---

## 🔁 Daily Git Workflow

Before work:
