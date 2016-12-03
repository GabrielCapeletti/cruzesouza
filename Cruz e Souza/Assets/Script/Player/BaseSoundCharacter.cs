using UnityEngine;

namespace Core {
    public class BaseSoundCharacter : MonoBehaviour {

        public AudioClip[] jumpSFX;
        public AudioClip[] walkSFX;
        public AudioClip[] edgeGrabSFX;
        public AudioClip[] ladderClimbSFX;
        public AudioClip[] highPunchSFX;
        public AudioClip[] lowPunchSFX;

        public void SFXJump(float volume) {
            PlaySFX(jumpSFX, volume);
        }

        public void SFXWalk(float volume) {
            PlaySFX(walkSFX, volume);
        }

        public void SFXEdgeGrab(float volume) {
            PlaySFX(edgeGrabSFX, volume);
        }

        public void SFXLadderClimb(float volume) {
            PlaySFX(ladderClimbSFX, volume);
        }

        public void SFXHighPunch(float volume) {
            PlaySFX(highPunchSFX, volume);
        }

        public void SFXLowPunch(float volume) {
            PlaySFX(lowPunchSFX, volume);
        }

        void PlaySFX (AudioClip[] clips, float volumeScale)
		{
			if (volumeScale == 0)
				volumeScale = 1;
			int randomIndex = Random.Range (0, clips.Length);
//			PoolDictionary.GetInstance ((int)PoolMap.SOUND_MANAGER).GetObject (this.gameObject).GetComponent<EffectSoundCoroutine> ().PlayAndDestroy (clips [randomIndex], volumeScale);
		}

	}
}


