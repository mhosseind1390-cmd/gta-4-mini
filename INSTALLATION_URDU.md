# Mini GTA IV - دستورالعمل نصب

## 🎮 نحوه استفاده از پروژه

### مرحله 1: دانلود فایل‌ها
1. تمام فایل‌های Scripts را دانلود کنید
2. درخت فایل‌ها را رعایت کنید

### مرحله 2: ساختار پروژه
```
gta-4-mini/
├── Assets/
│   ├── Scripts/
│   │   ├── Manager/
│   │   ├── Player/
│   │   ├── Vehicle/
│   │   ├── Enemy/
│   │   ├── Mission/
│   │   ├── Weapon/
│   │   ├── World/
│   │   ├── Animation/
│   │   ├── Audio/
│   │   ├── UI/
│   │   ├── Camera/
│   │   ├── Effects/
│   │   ├── NPC/
│   │   ├── Dialogue/
│   │   ├── Quest/
│   │   ├── Configuration/
│   │   └── Editor/
│   ├── Prefabs/
│   └── Scenes/
├── ProjectSettings/
├── .github/
│   └── workflows/
└── README.md
```

### مرحله 3: Unity میں کھولیں
1. Unity Hub کھولیں
2. نیا پروژہ بنائیں (2022.3 LTS)
3. فائل کو زیپ سے نکالیں
4. Scripts کو صحیح جگہ رکھیں

### مرحله 4: مہم تشکیلات
1. تمام Manager Scripts کو Scene میں شامل کریں
2. TextMeshPro import کریں
3. Prefabs بنائیں
4. Build Settings تیار کریں

### مرحله 5: بنائیں
```
File → Build Settings → Android → Build APK
```

## 🎯 کلیدی نکات

✅ **تمام Manager Singletons ہیں**
✅ **DontDestroyOnLoad استعمال کریں**
✅ **Tags مقرر کریں**: Player, Enemy, Police, Pickup
✅ **Layers سیٹ کریں**: UI, Player, Enemy, Vehicle

## 📞 مسائل حل کریں

**Scripts کام نہیں کر رہے:**
- Console میں errors چیک کریں
- تمام references assign کریں
- Tags اور Layers صحیح ہیں تو دیکھیں

**UI نہیں دیکھ رہا:**
- TextMeshPro imported ہے؟
- Canvas موجود ہے؟
- UIManager reference ہے؟

