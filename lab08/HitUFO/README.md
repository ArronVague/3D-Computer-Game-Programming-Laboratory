# lab08-物理引擎与碰撞1

鼠标打飞碟（Hit UFO）

- 使用对象池管理飞碟对象。
- 使用ScriptableObject配置不同的飞碟。
- 使用物理引擎管理飞碟飞行路径。

对象池技术

用一个或多个集合存储某类有限的对象实例。它在承担对象创建和回收的职责过程中，

- 按一定策略缓存一定数量的对象。
- 在客户请求创建对象时，优先使用已有的对象，并恰当初始化。如果没有缓存对象，再创建对象。
- 在对象使用完后，并不立即回收，而是先放回缓冲池，如果有请求则立即转为使用，已减少创建成本。在系统空闲时，按一定策略回收。

**案例研究：“鼠标打飞碟”游戏设计**

游戏需求：

- 分多个 round ， 每个 round 都是 n 个 trail；
- 每个 trail 的飞碟的色彩，大小；发射位置，速度，角度，每次发射飞碟数量不一；。
- 鼠标击中得分，得分按色彩、大小、速度不同计算，计分规则自由定