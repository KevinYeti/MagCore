# API说明

## 概念

### 游戏(Game)
一场2-10人的对战. 游戏目的为尽可能占领资源.

### 玩家(Player)
代表程序员参加游戏的代码所获得的唯一ID.

### 单元(Cell)
代表资源的最小单位, 描述一个单元的方式为X,Y坐标.

### 行(Row)
Y坐标相同的所有单元构成一行.

### 地图(Map)
一局游戏所有的单元组成一张地图.

### 基地(Base)
基地是玩家的基础领地, 所有基地被其他玩家占领, 被判为负.


## 胜利目标
尽可能多地占领单元, 占据其他玩家的领地.


## 规则
- 加入游戏, 会随机分配一个单元作为基地.
- 只能攻击自己领地相邻的单元.
- 占领不同的单元所需要的时间不同. 简单的说, 该单元被占领时间越长, 攻击它的所需时间越短.
- 所有基地被占, 判负. 同时清空所有其他被占单元.
- 每个玩家具有能量, 每秒自动获得当前占领单元数20%的能量, 每次攻击单元消耗当前10%的能量. 能量初始值为10, 上限100.
- 每个玩家只能最多同时进行2个动作.


## 测试脚本
[PostMan脚本下载](/script/MagCore.postman_collection.json)


## 如何开始
1. 阅读API文档， 理解游戏概念
2. 随意使用任何编程语言， 实现通过调用API来操作游戏动作
3. 编写自己的进攻或防守策略， 在游戏开始后与其他玩家的AI对决


## API

### 服务器BaseUrl
ht<span></span>tp://api.magcore.clawit.com/

### 状态说明
[数据结构概念及状态说明](/docs/cn/DataMap_CN.md)

### 游戏
[创建游戏](/docs/cn/CreateGame_CN.md)

[获取游戏列表](/docs/cn/GameList_CN.md)

[加入游戏](/docs/cn/JoinGame_CN.md)

[开始游戏](/docs/cn/StartGame_CN.md)

[获取游戏详细](/docs/cn/GetGame_CN.md)

### 玩家
[创建新玩家](/docs/cn/CreatePlayer_CN.md)

[获取玩家信息](/docs/cn/GetPlayer_CN.md)

### 地图
[获取地图信息](/docs/cn/GetMap_CN.md)

[攻击单元](/docs/cn/Attack_CN.md)


## SDK & Demo
[C# SDK](/src/sdk/MagCore.Sdk)

[Demo AI](/src/sdk/JustRush)
