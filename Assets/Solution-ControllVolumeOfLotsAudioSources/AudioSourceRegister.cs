
using UnityEngine;
using UnityEngine.UI;

namespace Solution.ControllVolumeOfLotsAudioSources {
    public class AudioSourceRegister : MonoBehaviour {

        AudioSource audioSource;

        [SerializeField] private Button btn_Play;

        /// <summary>
        /// 將自己加到列表中並且註冊事件
        /// </summary>
        private void Awake() {
            audioSource = this.GetComponent<AudioSource>();
            if (audioSource != null) {
                audioSource.volume = Core.volume;
                Core.audioSources.Add(audioSource);
            }
            btn_Play.onClick.AddListener(OnClick_Btn);
        }

        /// <summary>
        /// 從列表中移除自己
        /// </summary>
        private void OnDestroy() {
            if (audioSource != null) {
                Core.audioSources.Remove(audioSource);
            }
        }

        private void OnClick_Btn() {
            audioSource.Play();
        }

    }
}