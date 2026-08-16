# SteelBound | 3D FPS Unity Game
3D First-Person Shooter game built in C# and Unity Engine.

<img width="1920" height="1062" alt="image" src="https://github.com/user-attachments/assets/c7f92ada-1eac-4d93-b857-f9dd292a443c" />



## Technical Features

* **Kinematic State Machine Player Controller:** Custom character movement script handling ground detection, sprint dynamics, airborne physics, wall-running mechanics, and slope handling.
* **Modular Weapon Architecture:** Hit raycasting system supporting unique recoil profiles, dynamic damage falloff based on distance, and procedural reload states.
* **NavMesh Enemy AI:** Enemy navigation system leveraging Unity NavMesh with state-based aggression and target pathfinding scaled to player performance.

---

## Code Architecture & Structure

The repository is organized to highlight software logic without bulk engine assets:

```text
Scripts/
├── Player/       # State machine, movement physics, camera controls
├── Weapons/      # Raycast shooting logic, recoil patterns, ammo management
└── AI/           # NavMesh pathfinding, state behaviors, target tracking
```
## Player Controls

<img width="952" height="323" alt="image" src="https://github.com/user-attachments/assets/84e2813f-5a1b-464c-b3f2-e1fde32032f9" />

## Dynamic Enemies with Unique Attacks and Patterns

<img width="936" height="477" alt="image" src="https://github.com/user-attachments/assets/6eba0273-f3da-42ed-a223-9d9206a20d25" />

<img width="1710" height="920" alt="image" src="https://github.com/user-attachments/assets/247bfe32-b84e-421d-ba79-fc52275ac459" />

<img width="1672" height="941" alt="Steel21" src="https://github.com/user-attachments/assets/af477959-2c46-4c08-9af1-b0580cd071f2" />

## Attributions & Credits

* **Engine:** [Unity Engine](https://unity.com/) by **Unity Technologies**
* **Environment & Map Assets:** [LowPoly Mysterious Dungeon](https://assetstore.unity.com/) by **peanar**
* **Weapons & Ammunition Prefabs:** [Free Pack - Gun](https://assetstore.unity.com/) by **PolyOne Studio**
* **Audio & Sound Effects:** [AudioRoom](https://assetstore.unity.com/) by **DATARAM57**
* **Visual & Particle Effects:** [Legacy Particle Pack](https://assetstore.unity.com/) by **Unity Technologies**








