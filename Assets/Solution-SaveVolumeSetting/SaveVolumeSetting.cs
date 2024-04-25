
using UnityEngine;
using UnityEngine.UI;

namespace Solution.SaveVolumeSetting {
    public class SaveVolumeSetting : MonoBehaviour {

        [Header("播放器")]
        [SerializeField] private AudioSource audioSource;

        [Header("音量控制")]
        [SerializeField] private Slider slider_Volume;
        [SerializeField] private Text text_Volume;
        [SerializeField] private Button btn_SaveVolume;

        [Header("播放器控制")]
        [SerializeField] private Text text_Time;
        [SerializeField] private Image image_ProgressBar;
        [SerializeField] private Button btn_Play;
        [SerializeField] private Button btn_Stop;

        private const string VolumeKey = "Volume-Master";

        void Start() {
            //讀取音量資料
            float volume;
            if (PlayerPrefs.HasKey(VolumeKey)) {
                //存檔有紀錄過音量時，取出音量值
                volume = PlayerPrefs.GetFloat(VolumeKey);
            } else {
                //沒有資料時，設定成0.5 (50%)，避免一開始就太大聲
                volume = 0.5f;
            }
            slider_Volume.value = volume;
            OnValueChanged_Slider_Volume(volume);
            //音量拉桿登記
            slider_Volume.onValueChanged.RemoveAllListeners();
            slider_Volume.onValueChanged.AddListener(OnValueChanged_Slider_Volume);
            //存檔按鈕登記
            btn_SaveVolume.onClick.RemoveAllListeners();
            btn_SaveVolume.onClick.AddListener(OnClick_Btn_SaveVolume);
            //按鈕播放登記
            btn_Play.onClick.RemoveAllListeners();
            btn_Play.onClick.AddListener(OnClick_Btn_Play);
            btn_Stop.onClick.RemoveAllListeners();
            btn_Stop.onClick.AddListener(OnClick_Btn_Stop);
        }

        void Update() {
            //播放進度顯示
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

        /// <summary>
        /// 儲存音量
        /// </summary>
        private void OnClick_Btn_SaveVolume() {
            //取得現在拉桿的音量
            float volume = slider_Volume.value;
            //指定值給設定檔
            PlayerPrefs.SetFloat(VolumeKey, volume);
            //儲存設定檔
            PlayerPrefs.Save();
        }

        #endregion
        #region  -> Volume音量拉桿

        /// <summary>
        /// AudioMixer拉桿更改值
        /// </summary>
        /// <param name="value"></param>
        private void OnValueChanged_Slider_Volume(float value) {
            audioSource.volume = value;
            text_Volume.text = $"{value * 100:F0}%";
        }

        #endregion

    }
}