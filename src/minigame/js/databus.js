import Pool from './base/pool'

let instance

/**
 * 全局状态管理器
 */
export default class DataBus {
  constructor() {
    if ( instance )
      return instance

    instance = this

    this.pool = new Pool()

    this.reset()
  }

  reset() {
    this.baseUrl = 'http://localhost:8000/'
    //this.baseUrl = 'http://api.magcore.clawit.com/'
    this.scene = 'menu'
    this.score      = 0
    this.gameOver   = false
    this.gcode      = ''
    this.gid        = ''
    this.game       = undefined
    this.players    = undefined

    this.frame      = 0
    //this.bullets    = []
    //this.enemys     = []
    //this.animations = []
  }

  // /**
  //  * 回收敌人，进入对象池
  //  * 此后不进入帧循环
  //  */
  // removeEnemey(enemy) {
  //   let temp = this.enemys.shift()

  //   temp.visible = false

  //   this.pool.recover('enemy', enemy)
  // }

  // /**
  //  * 回收子弹，进入对象池
  //  * 此后不进入帧循环
  //  */
  // removeBullets(bullet) {
  //   let temp = this.bullets.shift()

  //   temp.visible = false

  //   this.pool.recover('bullet', bullet)
  // }
}