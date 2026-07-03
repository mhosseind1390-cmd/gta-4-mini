# Mini GTA IV - Complete Project Files

## 📥 تمام فایل‌های دانلود شده

اگر تمام فایل‌ها دانلود کردید، برای دسترسی به:

### 🎬 Scene Setup
1. **MainScene.unity** بسازید:
   - 3D Scene
   - Plane برای ground
   - Directional Light
   - Canvas برای UI

### 🤖 Managers درخت Scene
```
GameObject: GameManager
  - Script: GameManager.cs

GameObject: UIManager
  - Script: UIManager.cs
  - Child: Canvas
    - Panel: Pause Menu
    - Panel: Game Over
    - Text: Money Display
    - Text: Score Display
    - Text: Wanted Level

GameObject: SoundManager
  - Script: SoundManager.cs
  - AudioSource: Music (loop)
  - AudioSource: SFX

GameObject: PoliceManager
  - Script: PoliceManager.cs

GameObject: MissionManager
  - Script: MissionManager.cs

GameObject: QuestSystem
  - Script: QuestSystem.cs

GameObject: DialogueSystem
  - Script: DialogueSystem.cs

GameObject: ParticleEffectManager
  - Script: ParticleEffectManager.cs

GameObject: CityGenerator
  - Script: CityGenerator.cs
```

### 👤 Player Setup
```
GameObject: Player (Capsule)
  - Script: PlayerController.cs
  - Script: AnimationController.cs
  - Rigidbody (not kinematic)
  - Capsule Collider
  - Tag: "Player"
  - Children:
    - Camera (Main)
    - WeaponController
```

### 🚗 Vehicle Setup
```
GameObject: Car (Cube scaled)
  - Script: CarController.cs
  - Rigidbody (not kinematic)
  - Box Collider
  - Children (Wheels - 4x Cylinders):
    - FrontLeft
    - FrontRight
    - BackLeft
    - BackRight
```

### 👾 Enemy Setup
```
GameObject: Enemy (Capsule)
  - Script: EnemyController.cs
  - Script: AnimationController.cs
  - Rigidbody (not kinematic)
  - Capsule Collider
  - Tag: "Enemy"
  - Animator (if available)
```

### 🚔 Police Setup
```
GameObject: Police (Capsule)
  - Script: PoliceController.cs
  - Script: AnimationController.cs
  - Rigidbody (not kinematic)
  - Capsule Collider
  - Tag: "Police"
  - Animator (if available)
```

### 💰 Pickup Setup
```
GameObject: Pickup (Sphere)
  - Script: PickupController.cs
  - Rigidbody (is kinematic)
  - Sphere Collider (is trigger)
  - Tag: "Pickup"
```

## ⚙️ Tags و Layers

### Tags to Create
- Player
- Enemy
- Police
- Pickup
- Vehicle
- Building

### Layers to Create
- Player
- Enemy
- Police
- Vehicle
- Building
- Ground
- UI

## 🎨 بعد از نصب

1. **تمام فایل‌ها درست جا دارند**
2. **Scene setup مطابق guide کنید**
3. **Prefabs بسازید**
4. **Tags و Layers کنفیگ کنید**
5. **Build کنید**

## 📱 Build for Android

```
File → Build Settings
- Scenes In Build: MainScene.unity
- Platform: Android
- Architecture: ARM64
- Build: Build APK
```

## ✅ نقاط بررسی

- [ ] تمام Scripts imported
- [ ] Scene hierarchy صحیح
- [ ] Tags و Layers defined
- [ ] Managers در scene
- [ ] Canvas با UI elements
- [ ] Prefabs یا Scene GameObjects
- [ ] Build Settings configure
- [ ] Android SDK path

