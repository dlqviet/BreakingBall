const {ccclass, property} = cc._decorator;

@ccclass
export default class AudioManager extends cc.Component {

    @property(cc.AudioClip)
    m_collisionAudio: cc.AudioClip = null;
    @property(cc.AudioClip)
    m_dropAudio: cc.AudioClip = null;
    @property(cc.AudioClip)
    m_scoreAudio: cc.AudioClip = null;
    @property(cc.AudioClip)
	m_jumpAudio: cc.AudioClip = null;

    PlayJumpSound() {
        cc.audioEngine.playEffect(this.m_jumpAudio, false);
    }

    PlayCollisionSound() {
        cc.audioEngine.playEffect(this.m_collisionAudio, false);
    }

    PlayDropSound() {
        cc.audioEngine.playEffect(this.m_dropAudio, false);
    }

    PlayScoreSound() {
        cc.audioEngine.playEffect(this.m_scoreAudio, false);
    }
}
