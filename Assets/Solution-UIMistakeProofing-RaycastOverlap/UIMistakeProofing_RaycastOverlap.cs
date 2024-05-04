
using UnityEngine;
using UnityEngine.UI;

namespace Solution.UIMistakeProofing_RaycastOverlap {
    public class UIMistakeProofing_RaycastOverlap : MonoBehaviour {

        [SerializeField] private CanvasGroup CanvasGroup_Panel;
        [SerializeField] private Text Text_Count;
        [SerializeField] private Image Image_Cover;
        [SerializeField] private Button Button_OpenPanel;
        [SerializeField] private Button Button_OpenPanelWithCover;
        [SerializeField] private Button Button_ClosePanel;

        private int openCount = 0;

        void Start() {
            Button_OpenPanel.onClick.RemoveAllListeners();
            Button_OpenPanel.onClick.AddListener(OnClick_Button_OpenPanel);
            Button_OpenPanelWithCover.onClick.RemoveAllListeners();
            Button_OpenPanelWithCover.onClick.AddListener(OnClick_Button_OpenPanelWithCover);
            Button_ClosePanel.onClick.RemoveAllListeners();
            Button_ClosePanel.onClick.AddListener(OnClick_Button_ClosePanel);
            openCount = 0;
        }

        private void OnClick_Button_OpenPanel() {
            //開啟面板、但是沒有擋板
            ShowPanel(true);
            Image_Cover.enabled = false;
        }

        private void OnClick_Button_OpenPanelWithCover() {
            //開啟面板、同時也有擋板
            ShowPanel(true);
            Image_Cover.enabled = true;
        }

        private void OnClick_Button_ClosePanel() {
            //關閉面板與擋板
            ShowPanel(false);
            Image_Cover.enabled = false;
        }

        /// <summary>
        /// 顯示或關閉面板
        /// </summary>
        /// <param name="isShow"></param>
        private void ShowPanel(bool isShow) {
            //根據狀況開關CanvasGroup底下的所有UI功能
            CanvasGroup_Panel.alpha = isShow ? 1 : 0; //true時為1，false時為0
            CanvasGroup_Panel.interactable = isShow;
            CanvasGroup_Panel.blocksRaycasts = isShow;
            //如果是開啟事件，則次數+1，並且顯示
            if (isShow) {
                openCount += 1;
                Text_Count.text = openCount.ToString();
            }
        }

    }
}