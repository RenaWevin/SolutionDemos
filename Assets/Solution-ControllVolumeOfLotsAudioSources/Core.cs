
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Solution.ControllVolumeOfLotsAudioSources {
    public class Core : MonoBehaviour {

        //音源喇叭列表
        public static List<AudioSource> audioSources = new List<AudioSource>();
        //音量值 範圍0.00~1.00
        public static float volume;

        //音量控制
        [Header("音量控制")]
        [SerializeField] private Slider slider_Volume;
        [SerializeField] private Text text_Volume;

        //啟動時執行
        private void Awake() {
            volume = 0.5f; //預設50%
            slider_Volume.onValueChanged.RemoveAllListeners();
            slider_Volume.onValueChanged.AddListener(OnValueChanged_VolumeSlider);
            slider_Volume.value = volume;
            OnValueChanged_VolumeSlider(volume);
        }

        private void OnValueChanged_VolumeSlider(float v) {
            volume = v;
            text_Volume.text = $"{v * 100:F0}%";
            for (int i = 0; i < audioSources.Count; i++) {
                audioSources[i].volume = v;
            }
        }

    }
}