package main

import "time"

// 静态服务器属性
type StaticServerAttributes struct {
	ServerID             int       // 服务器ID
	ServerName           string    // 服务器名称
	ServerRegion         string    // 服务器所在的区域
	MaxOnlinePlayers     int       // 服务器最大在线人数
	MaxRegisteredPlayers int       // 服务器最大注册人数
	MaxQueuePlayers      int       // 服务器最大排队人数
	ServerStartTime      time.Time // 服务器开服时间
	CustomParameters     string    // 服务器自定义参数(json)
	ServerStatus         bool      // 服务器开关状态 (开启/关闭)
	MainServerID         int       // 主服ID
	ServerType           string    // 服务器类型 (运营、测试、废弃)
	ServerTags           []string  // 服务器标签
}

// 动态服务器属性
type DynamicServerAttributes struct {
	CurrentOnlinePlayers     int  // 服务器当前在线人数
	CurrentRegisteredPlayers int  // 服务器当前注册人数
	CurrentQueuePlayers      int  // 服务器当前排队人数
	IsHeartbeatMaintained    bool // 服务器是否保持心跳
}
