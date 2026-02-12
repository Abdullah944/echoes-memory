# Echoes Memory — Cursor Project Rules (Unity 2D)

## Project Overview
- Game: Echoes Memory
- Genre: 2D Top-Down Adventure (Zelda-like)
- Engine: Unity
- Language: C#
- Platform: Steam (PC)
- Art Style: Pixel / Cartoon
- Hero: Black hair, Kuwaiti dishdasha
- Movement: 8-direction (diagonal allowed)
- Input: Unity New Input System
- Animator: Already set up (do not redesign unless asked)

---

## Learning Sources (Follow These)
Use organization and best practices from:

- https://youtu.be/qsIiFsddGV4
- https://youtu.be/N3jOOm--TTg
- https://youtu.be/Ld7V4547d3s
- https://youtu.be/amSzqkMEcbU
- https://youtu.be/oLRINAn0cuw
- https://youtu.be/kV06GiJgFhc
- https://youtu.be/Vt8aZDPzRjI

When generating code, extract patterns from these videos and follow them.

---

## Core Rules (Always Follow)

- Keep systems simple and scalable.
- Do not over-engineer.
- No unnecessary refactors.
- Do not modify Animator assets unless requested.
- Respect existing project structure.
- One class per file.

---

## Architecture Standard (State Machine)

Always use a scalable player state machine:

### Main Components
- PlayerController
- PlayerStateMachine
- PlayerBaseState
- PlayerStateFactory
- PlayerIdleState
- PlayerMoveState

### State API
Each state must implement:
- Enter()
- Exit()
- HandleInput()
- LogicUpdate()
- PhysicsUpdate()

Prepare for future states:
- Pickup
- Attack
- ToolUse
- Hurt

---

## Input System Rules

- Use Unity Input System.
- Use PlayerInput + InputActions.
- "Move" action returns Vector2.
- Read input in Update.
- Cache input for FixedUpdate.

---

## Movement Rules

- 8-direction movement (diagonal allowed).
- Normalize movement if magnitude > 1.
- Apply movement in FixedUpdate using Rigidbody2D.
- Use MovePosition or velocity.
- Track FacingDirection (Vector2).
- Keep last facing direction when input = zero.

---

## Animator Rules

Animator is already configured.

Do not rename parameters.

Use existing parameters to:
- Control idle / walk
- Set facing direction
- Set movement state

Typical logic:
- IsMoving = input != Vector2.zero
- Direction = FacingDirection

---

## Folder Structure (Required)

Assets/_Project/Scripts/
  Player/
    PlayerController.cs
    StateMachine/
      PlayerStateMachine.cs
      PlayerBaseState.cs
      PlayerStateFactory.cs
    States/
      PlayerIdleState.cs
      PlayerMoveState.cs

---

## Development Workflow

Before coding:
1. Read existing scripts.
2. Follow existing patterns.
3. Plan minimal changes.
4. Implement.
5. Explain how to test in Unity.

After coding:
- Ensure project compiles.
- No warnings.
- No broken references.

---

## Git & Unity Hygiene

- Visible Meta Files enabled.
- Force Text serialization.
- Use Unity .gitignore.
- Do not commit Library / Temp / Logs.

---

## Forbidden Practices

Do NOT:
- Use GameObject.Find / FindObjectOfType
- Create states every frame
- Put physics in Update
- Hardcode input strings
- Change Animator assets without permission

---

## AI Behavior

When assisting this project:

- Follow this file strictly.
- Prioritize maintainability.
- Prefer clarity over cleverness.
- Ask only if something blocks progress.
- Otherwise, choose the simplest solution.

---

## Current Focus

> Player core systems:
> State Machine
> Movement
> Animation Sync
> Tool Pickup (next)****