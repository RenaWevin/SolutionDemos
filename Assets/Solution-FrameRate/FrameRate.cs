
using UnityEngine;
using UnityEngine.UI;

namespace Solution.FrameRate {
    public class FrameRate : MonoBehaviour {

        [Header("FPS選項")]
        [SerializeField] private Button btn_UnlimitedFPS;
        [SerializeField] private Button btn_FPS15;
        [SerializeField] private Button btn_FPS30;
        [SerializeField] private Button btn_FPS60;

        [Header("狀態")]
        [SerializeField] private Text text_FrameRate;

        void Start() {
            //將按鈕註冊事件，分別註冊不同的FPS量
            btn_UnlimitedFPS.onClick.RemoveAllListeners();
            btn_UnlimitedFPS.onClick.AddListener(delegate { ChangeFPS(-1); }); //-1表示無上限
            btn_FPS15.onClick.RemoveAllListeners();
            btn_FPS15.onClick.AddListener(delegate { ChangeFPS(15); }); //FPS 15
            btn_FPS30.onClick.RemoveAllListeners();
            btn_FPS30.onClick.AddListener(delegate { ChangeFPS(30); }); //FPS 30
            btn_FPS60.onClick.RemoveAllListeners();
            btn_FPS60.onClick.AddListener(delegate { ChangeFPS(60); }); //FPS 60
        }

        void Update() {
            //計算目前fps
            float fps = 1 / Time.unscaledDeltaTime;
            //顯示fps
            text_FrameRate.text = $"目前fps: {fps:F0}\n設定fps: {Application.targetFrameRate}";
        }

        /// <summary>
        /// 更改FPS
        /// </summary>
        /// <param name="fps"></param>
        private void ChangeFPS(int fps) {
            Application.targetFrameRate = fps;
        }

    }
}