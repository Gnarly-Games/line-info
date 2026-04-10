# Gnarly Games Line Info

This is the UPM-packaged version of the `LineInfo` folder.

## Installation

Add the following entry to your Unity `Packages/manifest.json` file:

```json
{
  "dependencies": {
    "line-info": "https://github.com/Gnarly-Games/line-info.git#v1.0.0"
  }
}
```

## Contents

- `Runtime/Scripts/LineInfoManager.cs`
- `Runtime/Scripts/LineInfoItem.cs`
- `Runtime/Prefabs/LineInfoManager.prefab`
- `Runtime/Prefabs/LineInfoItem.prefab`

## Usage

1. Add the `LineInfoManager.prefab` prefab to your scene.
2. Call `GnarlyGames.LineInfo.LineInfoManager.Show("Message", 1f);` wherever needed.

The package works with `UGUI` and `TextMeshPro`. Since the animation behavior is built into the package, it does not require an additional tween package.
