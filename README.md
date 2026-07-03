# Mini GTA IV - Sandbox City Game

## Overview
Mini GTA IV is an open-world sandbox game built with Unity. Experience the thrill of a crime-filled city with cars, missions, police chases, and weapons.

## Features
✅ Open-world city exploration
✅ Vehicle driving system
✅ Mission-based gameplay
✅ Police pursuit system (Wanted Level)
✅ Combat and weapons system
✅ NPC enemies
✅ Money and score system
✅ High-quality graphics

## Game Systems
- **Player Control**: Walk, run, aim, shoot
- **Vehicle System**: Drive cars, realistic physics
- **Police System**: Wanted levels, police chases
- **Combat**: Shoot enemies, take damage
- **Missions**: Various objectives to complete
- **UI**: Money, score, wanted level display

## Installation
1. Clone the repository
2. Open with Unity 2022.3 or higher
3. Import all assets
4. Build for Android or Play in Editor

## Building APK
1. File → Build Settings
2. Select Android
3. Player Settings → Configure
4. Build APK

## Controls
- **WASD**: Move
- **Mouse**: Look around
- **Left Click**: Shoot
- **E**: Pickup weapon
- **F**: Enter car
- **Space**: Brake (in car)
- **ESC**: Pause

## Project Structure
```
Assets/
├── Scripts/
│   ├── Manager/
│   │   ├── GameManager.cs
│   │   ├── UIManager.cs
│   │   └── PoliceManager.cs
│   ├── Player/
│   │   └── PlayerController.cs
│   ├── Vehicle/
│   │   └── CarController.cs
│   ├── Enemy/
│   │   ├── EnemyController.cs
│   │   └── PoliceController.cs
│   └── Mission/
│       └── MissionManager.cs
├── Prefabs/
├── Scenes/
└── Assets/
```

## Author
Created by Copilot

## License
MIT License
