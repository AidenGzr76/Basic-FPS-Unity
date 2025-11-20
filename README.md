# Basic FPS Maze Prototype

[![Play on itch.io](https://img.shields.io/badge/Play_on-itch.io-fa5c5c?style=for-the-badge&logo=itch.io&logoColor=white)](https://gazoram.itch.io/simple-fps)

A fundamental 3D First-Person Shooter (FPS) project...

A fundamental 3D First-Person Shooter (FPS) project built with **Unity** and **C#**.
This project was developed to demonstrate core game development concepts including **Enemy AI State Machines**, **Physics-based interactions**, and **Modular Input Systems**.

![Simple FPS Gif](https://github.com/user-attachments/assets/1c419c67-0c55-4a5b-8261-3cd091e8de03)

## 🎮 Key Features

### Core Gameplay
* **FPS Controller:** Smooth movement, mouse look, and physics interaction.
* **Combat System:** Raycast-based shooting mechanics with realistic reloading logic and ammo management.
* **Health System:** Player health management with interactable healing pickups (Health Packs).

### Enemy AI (Finite State Machine)
The enemies are driven by a custom State Machine utilizing **Unity NavMesh** for pathfinding. Behaviors include:
* **Patrol:** Roaming the maze between waypoints.
* **Chase/Engage:** Detecting the player within range and switching to combat mode.
* **Attack:** Shooting mechanics with custom animations.
* **Flee/Die:** Reacting to damage and death states.

### Environment & Visuals
* **Maze Design:** A classic maze structure optimized for close-quarters combat.
* **Lighting:** Implementation of real-time shadows and baked lighting for atmosphere.
* **Animation:** Full Mecanim setup for enemies (Walk, Run, Shoot, Die).

## 🛠 Technical Stack

* **Engine:** Unity 2022 (or your specific version)
* **Language:** C#
* **AI:** Unity NavMesh & Custom FSM
* **Input:** Unity Input System
* **Version Control:** Git & GitHub

## 🕹️ Controls

| Key | Action |
| :--- | :--- |
| **W, A, S, D** | Movement |
| **Mouse** | Look / Aim |
| **Left Click** | Shoot |
| **R** | Reload |
| **Space** | Jump |

## 🚀 Future Improvements
* Adding sound effects (SFX) for shooting and footsteps.
* Implementing a UI manager for Ammo/Health display.
* Expanding the maze with verticality (stairs/floors).

---
*This project is part of my portfolio for Unity Development.*
