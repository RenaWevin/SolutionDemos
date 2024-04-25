
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Solution.AudioMixerVSVolume {
    public class AudioMixerVSVolume : MonoBehaviour {

        [SerializeField] private AudioSource audioSource;

        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private Slider slider_AudioMixer;
        [SerializeField] private Text text_AudioMixer;

        [SerializeField] private Slider slider_Volume;
        [SerializeField] private Text text_Volume;

        [SerializeField] private Text text_Time;
        [SerializeField] private Image image_ProgressBar;
        [SerializeField] private Button btn_Play;
        [SerializeField] private Button btn_Stop;

        private void Start() {
            slider_AudioMixer.onValueChanged.RemoveAllListeners();
            slider_AudioMixer.onValueChanged.AddListener(OnValueChanged_Slider_AudioMixer);
            OnValueChanged_Slider_AudioMixer(slider_AudioMixer.value);

            slider_Volume.onValueChanged.RemoveAllListeners();
            slider_Volume.onValueChanged.AddListener(OnValueChanged_Slider_Volume);
            OnValueChanged_Slider_Volume(slider_Volume.value);

            btn_Play.onClick.RemoveAllListeners();
            btn_Play.onClick.AddListener(OnClick_Btn_Play);
            btn_Stop.onClick.RemoveAllListeners();
            btn_Stop.onClick.AddListener(OnClick_Btn_Stop);
        }

        private void Update() {
            float now = audioSource.time;
            float length = audioSource.clip.length;
            text_Time.text = $"時間軸 {now:F1} / {length:F1}";
            image_ProgressBar.fillAmount = now / length;
        }

        #region  -> 按鈕

        private void OnClick_Btn_Play() {
            audioSource.Play();
        }

        private void OnClick_Btn_Stop() {
            audioSource.Stop();
        }

        #endregion
        #region  -> AudioMixer

        /// <summary>
        /// AudioMixer滑條更改值
        /// </summary>
        /// <param name="value"></param>
        private void OnValueChanged_Slider_AudioMixer(float value) {
            audioMixer.SetFloat("Master", value);
            text_AudioMixer.text = $"{value:F0}db";
        }

        #endregion
        #region  -> Volume音量

        /// <summary>
        /// AudioMixer滑條更改值
        /// </summary>
        /// <param name="value"></param>
        private void OnValueChanged_Slider_Volume(float value) {
            audioSource.volume = value;
            text_Volume.text = $"{value:F2}\n{(value * 100):F0}%";
        }

        #endregion

    }
}