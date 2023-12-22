# 3D游戏编程与设计

## 目录

[lab01-让非专业人士制作游戏](w01-introduction)

[lab02-小组策划](w02-nature-of-game)

[lab03-游戏循环和mvc结构](w03-discrete-simulation-basic)

[lab05-创建游戏世界1](w05-building-game-world/PriestsAndDevils)

[lab06-创建游戏世界2](w06-building-game-world/PriestsAndDevils-ActionSeparate)

[lab08-物理引擎与碰撞1](w08-physics-and-collisions/HitUFO)

[lab11-模型与动画2](w11-models-and-animations)

## 考试（可能）

- ~~画砖墙~~（要写代码不考）
- 改正交投影（Camera Projection）
  - 四、游戏对象与图形基础
- Camera摄像机的使用
  - 四、游戏对象与图形基础
- Has Exit Time
- 飘雪
- 火焰尾巴
- 走马灯
- 不编程
- 粒子系统
  - render
  - emission

## 操作技能汇总

1. 使用简单物体，如 plane，cube 等搭建游戏场景，添加代码产生移动、旋转等运动
2. 使用双摄相机制作，如鸟瞰图，局部细节放大图
3. 切换天空，使用指定按键，定时，或菜单按钮
4. 鼠标点击指定物体，创建或删除指定简单物体（如 cube）
5. 使用动画机控制模型动作
6. 制作简单动画
7. 使用指定 标准资源库 动作，赋予特定人物模型，
8. 简单粒子制作，例如：下雪，火把等
9. UI动画，例如：遮罩制作与滚动文字
10. 简单菜单制作，即可采用 IMGUI 技术 也 可以采用 uGUI 技术。选中菜单产生效果或动作

## 课件中unity的相关操作

二、离散仿真引擎基础

- 红色正方体
  - cube
  - material
- prefabs
- scenes

三、空间与运动

- 旋转
- 贴图

四、游戏对象与图形基础

- 摄像机
  - 投影
  - 双摄相机“鸟瞰图”
- 天空盒
- 音频
  - 立体声
- 地形编辑
  - 刷子
  - 种树
  - 种草
- 第三人称预制


## 一些吐槽

### 预制件Prefabs

不能删除挂载的组件！如

```csharp
Destory(Object.GetComponent<MoveOut>());
```

### 关于博客以及代码注释

翻学长学姐的博客和代码总是吐槽写得不完整，缺斤少两，光给个代码怎么运行。理解、质疑、成为。还是希望这个仓库能给大伙带来帮助。

## 资源

[太阳系贴图](https://www.solarsystemscope.com/textures/)
