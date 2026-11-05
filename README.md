# tetris

Windows・macOS・Linux で動くデスクトップ版のテトリス。

## 動作環境

- Windows・macOS・Linux
- .NET SDK 10.0 以上

## インストール

配布物は無い。ソースから起動する。

1. .NET SDK 10.0 以上をインストールする。
2. リポジトリをクローンする。
3. リポジトリのルートで `dotnet run --project Tetris.Avalonia` を実行する。

## 使い方

次のキーで操作する。

| キー | 操作 |
| :- | :- |
| ← / → / ↓ | 移動 |
| ↑ | ハードドロップ |
| Z / X | 左回転 / 右回転 |
| Space | プレイ中はホールド。ゲームオーバーと一時停止中は開始・再開 |
| P | 一時停止 |
| R | 一時停止中のリセット |
| Esc | プレイ中は一時停止。一時停止中とゲームオーバーでは終了 |

## 開発

道具は「インストール」の 1. と同じである。

```sh
dotnet build Tetris.sln
dotnet test Tetris.sln
```
