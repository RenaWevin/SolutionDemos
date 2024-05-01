
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Solution.ResolutionAndFullscreen {
    public class ResolutionAndFullscreen : MonoBehaviour {

        [Header("選項")]
        [SerializeField] private Dropdown dropdown_Resolutions;
        [SerializeField] private Toggle Toggle_IsFullscreen;

        [Header("狀態")]
        [SerializeField] private Text text_ResolutionAndFullscreenState;

        [Header("應用選項")]
        [SerializeField] private Button btn_Apply;

        //支援的解析度
        private readonly List<Resolution> resolutions = new List<Resolution>();

        void Start() {
            //註冊按鍵
            btn_Apply.onClick.RemoveAllListeners();
            btn_Apply.onClick.AddListener(OnClick_ApplyResolution);
            //處理解析度列表
            resolutions.Clear();
            resolutions.AddRange(Screen.resolutions);
            //為下拉選單處理選項：轉化解析度為選項的字串、找尋下拉選單現在應該在哪個選項上
            List<string> options = new List<string>();
            int dropdownIndex = 0;
            for (int i = 0; i < resolutions.Count; i++) {
                //文字格式：寬 x 高
                //效果等同於 resolutions[i].width.ToString() + " x " + resolutions[i].height.ToString();
                options.Add($"{resolutions[i].width} x {resolutions[i].height}");
                //如果寬高都相同，則選擇這個
                if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height) {
                    dropdownIndex = i;
                }
            }
            //將選項加入下拉選單
            dropdown_Resolutions.ClearOptions();
            dropdown_Resolutions.AddOptions(options);
            //將下拉選單目前選擇的編號代入
            dropdown_Resolutions.value = dropdownIndex;
            //將目前是否為全螢幕的勾勾反映成目前的狀態
            Toggle_IsFullscreen.isOn = Screen.fullScreen;
        }

        /// <summary>
        /// 更新顯示
        /// </summary>
        void Update() {
            //更新下方的文字狀態
            UpdateDisplay_ResolutionAndFullscreenState();
        }

        /// <summary>
        /// 點擊應用設定
        /// </summary>
        private void OnClick_ApplyResolution() {
            //解析度
            Resolution selectedResolution = resolutions[dropdown_Resolutions.value];
            //是否全螢幕
            bool isFullscreen = Toggle_IsFullscreen.isOn;
            //將設定應用到遊戲本體中
            Screen.SetResolution(selectedResolution.width, selectedResolution.height, isFullscreen);
        }

        /// <summary>
        /// 更新顯示狀態
        /// </summary>
        private void UpdateDisplay_ResolutionAndFullscreenState() {
            text_ResolutionAndFullscreenState.text = $"目前解析度：{Screen.width} x {Screen.height} / 全螢幕狀態：{Screen.fullScreen}";
        }

    }
}