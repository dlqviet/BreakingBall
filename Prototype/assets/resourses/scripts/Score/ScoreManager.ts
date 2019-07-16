const {ccclass, property} = cc._decorator;

@ccclass
export default class ScoreManager extends cc.Component {

    @property(cc.Prefab)
    m_scoreEffect: cc.Prefab = null;
    @property(cc.Label)
    m_scoreLabel: cc.Label = null;
    @property(cc.Node)
    m_scoreBoard: cc.Node = null;
    @property(cc.Label)
    m_scoreOnBoard: cc.Label = null;
    @property(cc.Label)
    m_highScore: cc.Label = null;

    score = 0;
    bestScore = 0;
    scorePool = null;

    onLoad() {
        this.scorePool = new cc.NodePool('ScoreEffect');
    }

    ResetScore() {
        this.score = 0;
        this.m_scoreLabel.string = this.score.toString();
    }

    GainScore(pos) {
        this.score += 1;
        this.m_scoreLabel.string = this.score.toString();
        this.node.getComponent('AudioManager').PlayScoreSound();
        var fx = this.SpawnScoreFX();
        this.node.addChild(fx.node);
        fx.node.setPosition(pos);
        fx.play();
        
    }

    SpawnScoreFX() { 
        var fx;
        if (this.scorePool.size() > 0) {
            fx = this.scorePool.get();
            return fx.getComponent('ScoreEffect');
        } else {
            fx = cc.instantiate(this.m_scoreEffect).getComponent('ScoreEffect');
            fx.init(this);
            return fx;
        }
    }

    DespawnScoreFX(scoreFX) {
        this.scorePool.put(scoreFX);
    }

    DisplayScoreBoard() {
        var currentScore = this.score;
        this.bestScore = cc.sys.localStorage.getItem(this.m_highScore);
        if (this.bestScore == 0 || currentScore > this.bestScore){
            this.bestScore = currentScore;
        }
        cc.sys.localStorage.setItem(this.m_highScore, this.bestScore);
        this.m_highScore.string = this.bestScore.toString();
        this.m_scoreOnBoard.string = currentScore.toString();
    }
}
