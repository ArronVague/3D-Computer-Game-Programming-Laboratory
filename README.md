# 3D游戏编程与设计

## 目录

[lab01-让非专业人士制作游戏](w01-introduction)

[lab02-小组策划](w02-nature-of-game)

[lab03-游戏循环和mvc结构](w03-discrete-simulation-basic)

[lab05-创建游戏世界1](w05-building-game-world/PriestsAndDevils)

[lab06-创建游戏世界2](w06-building-game-world/PriestsAndDevils-ActionSeparate)

[lab08-物理引擎与碰撞1](w08-physics-and-collisions/HitUFO)

## 考试（可能）

- 画砖墙

- 改正交投影（Camera Projection）

- Camera摄像机的使用

## 一些吐槽

### gitee的draw.io

没有适配长名字的仓库，提交.drawio时要求输入文件名，却因为仓库名太长而导致输入框隐藏。

直接检查元素找到那一块前端代码，将仓库名改短。

### Folder name

Avoid using spaces if possible. I tried to use path as

```bash
../../lab05/Priests and Devils/README.md
```

It worked in marktext, but not in github

The final solution is to replace spaces with `%20` beacause github will automatically replace spaces in path with `%20`.

### 预制件Prefabs

不能删除挂载的组件！如

```csharp
Destory(Object.GetComponent<MoveOut>());
```

