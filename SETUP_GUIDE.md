# Mini GTA IV - Setup Guide

## Prerequisites
- Unity 2022.3 or higher
- Android SDK (for mobile build)
- Visual Studio or any C# IDE

## Installation Steps

### 1. Clone Repository
```bash
git clone https://github.com/mhosseind1390-cmd/gta-4-mini.git
cd gta-4-mini
```

### 2. Open in Unity
1. Open Unity Hub
2. Click "Add" and select the project folder
3. Open with Unity 2022.3+

### 3. Import Required Packages
- TextMesh Pro (for UI)
- Standard Assets (if needed)

### 4. Create Scene
1. Create new 3D scene: `Assets/Scenes/MainScene.unity`
2. Add GameObjects from prefabs
3. Configure settings

### 5. Build Settings
1. File → Build Settings
2. Add Scene to Build
3. Select Platform: Android or PC
4. Configure Player Settings

### 6. Build APK (Android)
1. File → Build Settings
2. Select Android
3. Click "Build APK"
4. Choose output folder
5. Wait for build to complete

### 7. Install on Phone
- Copy APK to phone
- Enable "Unknown Sources" in Settings
- Tap APK to install

## Project Structure

```
gta-4-mini/
├── Assets/
│   ├── Scripts/
│   │   ├── Manager/
│   │   ├── Player/
│   │   ├── Vehicle/
│   │   ├── Enemy/
│   │   ├── Input/
│   │   └── Configuration/
│   ├── Prefabs/
│   ├── Scenes/
│   └── Assets/
├── ProjectSettings/
├── README.md
└── SETUP_GUIDE.md
```

## Game Controls

### Keyboard Controls (PC)
- **WASD**: Move character
- **Mouse**: Look around
- **Left Click**: Shoot
- **E**: Pickup weapon
- **F**: Enter car
- **Space**: Brake (in car)
- **ESC**: Pause game

### Mobile Controls (Android)
- **Left Joystick**: Move
- **Right Joystick**: Aim
- **Shoot Button**: Fire weapon
- **Action Button**: Interact
- **Pause Button**: Pause game

## Troubleshooting

### Scripts not working
- Check if GameManager, UIManager are in the scene
- Verify all prefabs have correct tags ("Player", "Enemy", "Police")
- Check Console for errors

### UI not showing
- Make sure Canvas is created
- TextMeshPro assets are imported
- UI elements have correct script references

### Build fails
- Check Android SDK path
- Update to latest Unity version
- Clear Library folder and reimport

## Features Implemented

✅ Player movement and camera control
✅ Vehicle system (cars)
✅ Enemy AI
✅ Police chase system
✅ Wanted level system
✅ Combat/shooting
✅ Money and score system
✅ Mission system
✅ UI and HUD
✅ Game pause/resume
✅ Game over screen

## Future Enhancements

- [ ] More weapon types
- [ ] More vehicle types
- [ ] Mini-map
- [ ] Multiplayer support
- [ ] Advanced AI
- [ ] More missions
- [ ] Improved graphics
- [ ] Sound effects
- [ ] Music system

## Support

For issues or questions, open an issue on GitHub.
