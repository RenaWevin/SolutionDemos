
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Solution.ControllVolumeOfLotsAudioSources {
    public class Core : MonoBehaviour {

        //音源喇叭列表
        public static List<AudioSource> audioSources = new List<AudioSource>();

        public static float volume;

        //音量控制
        [Header("音量控制")]
        [SerializeField] private Slider slider_Volume;
        [SerializeField] private Text text_Volume;

        //聲音播放按鈕
        [Header("聲音播放按鈕")]
        [SerializeField] private List<Button> btns_Play = new List<Button>();

        //啟動時執行
        private void Awake() {
            volume = slider_Volume.value;
            for (int i = 0; i < btns_Play.Count; i++) {
                int j = i;
                btns_Play[i].onClick.RemoveAllListeners();
                btns_Play[i].onClick.AddListener(delegate {
                    audioSources[j].Play();
                });
            }
        }



    }
}