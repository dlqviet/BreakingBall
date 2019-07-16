const {ccclass, property} = cc._decorator;

@ccclass
export default class PlatformBehavior extends cc.Component {

    @property(cc.Color)
    m_color: cc.Color[] = [];

    @property(cc.Animation)
    m_breakAnimation: cc.Animation = null;

    @property m_limitBreak: number = 0;

    collisionTime = 0;
    breakTime = 0;

    

    onLoad(){
        this.breakTime = this.m_limitBreak;
    }

    BreakBrick() {
        this.node.getChildByName('PerfectPoint').getComponent(cc.Animation).play('breaking');
        this.node.getComponent(cc.Animation).play('breaking');
        this.node.runAction(cc.sequence(cc.fadeOut(0.3), cc.callFunc(() => {this.node.destroy();}, this)));
    }

    OnBreak() {
        var pos = this.node.getPosition();
        this.node.parent.parent.parent.getComponent('ScoreManager').GainScore(pos);
    }

    onCollisionEnter(other, self) {
        switch (other.tag) {
            case 0:
            {
                switch(self.tag) {
                    case 5:
                    {
                        if (!this.node.parent.parent.getChildByName('Ball').getComponent('BallManager').powerFull)
                        {
                            this.node.parent.parent.getChildByName('Ball').getComponent('BallManager').comboStack = 0;
                            this.collisionTime ++;
                            if (this.collisionTime == this.m_limitBreak)
                            {
                                this.OnBreak();
                                this.scheduleOnce(this.BreakBrick, 0.2);
                                this.collisionTime = 0;
                            }
                            if (this.collisionTime == this.m_limitBreak - this.breakTime + 1)
                            {
                                this.node.color = this.m_color[this.m_limitBreak - this.breakTime];
                                this.breakTime--;
                            }
                            break;    
                        }
                        else
                        {
                            this.OnBreak();
                            this.scheduleOnce(this.BreakBrick, 0.2);
                            this.collisionTime = 0;
                            break;   
                        }
                    }
                    case 6:
                    {
                        if (this.node.parent.parent.getChildByName('Ball').getComponent('BallManager').powerFull)
                        {
                            this.OnBreak();
                            this.scheduleOnce(this.BreakBrick, 0.2);
                            this.collisionTime = 0;
                            break;   
                        }
                    }
                    case 7:
                    {
                        if (!this.node.parent.parent.getChildByName('Ball').getComponent('BallManager').powerFull)
                        {
                            this.node.parent.parent.getChildByName('Ball').getComponent('BallManager').comboStack++;
                        }
                        this.OnBreak();
                        this.scheduleOnce(this.BreakBrick, 0.2);
                        this.collisionTime = 0;
                        break; 
                    }
                }
            }
        }
        switch (other.tag) {
            case 1:
            {
                switch(self.tag) {
                    case 5:
                    {
                        this.node.parent.parent.parent.getComponent('GameManager').GameOver();
                        break;
                    }   
                }
            }
        }
    }
}
