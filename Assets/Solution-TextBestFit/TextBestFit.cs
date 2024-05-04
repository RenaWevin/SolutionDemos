
using UnityEngine;
using UnityEngine.UI;

namespace Solution.TextBestFit {
    public class TextBestFit : MonoBehaviour {

        [SerializeField] private Text Text_BestFit;
        [SerializeField] private Text Text_NoBestFit;
        [SerializeField] private Button Button_NormalText;
        [SerializeField] private Button Button_VeryLongText;
        [SerializeField] private Button Button_AnimationText;

        private const string CONST_str_NormalText = "文字";
        private const string CONST_str_VeryLongText = "如果是勇者欣梅爾的話\n他一定顯示得出來的";

        private int nowSubstringLength = -1;
        private float cooldown = 0f;

        void Start() {
            nowSubstringLength = -1;
            Button_NormalText.onClick.RemoveAllListeners();
            Button_NormalText.onClick.AddListener(OnClick_Button_NormalText);
            Button_VeryLongText.onClick.RemoveAllListeners();
            Button_VeryLongText.onClick.AddListener(OnClick_Button_VeryLongText);
            Button_AnimationText.onClick.RemoveAllListeners();
            Button_AnimationText.onClick.AddListener(OnClick_Button_AnimationText);
        }

        void Update() {
            if (nowSubstringLength >= 0 && nowSubstringLength < CONST_str_VeryLongText.Length) {
                if (cooldown <= 0f) {
                    nowSubstringLength++;
                    string substring = CONST_str_VeryLongText.Substring(0, nowSubstringLength);
                    ShowText(substring);
                    cooldown = 0.15f;
                } else {
                    cooldown -= Time.deltaTime;
                }
            }
        }

        private void OnClick_Button_NormalText() {
            nowSubstringLength = -1;
            ShowText(CONST_str_NormalText);
        }

        private void OnClick_Button_VeryLongText() {
            nowSubstringLength = -1;
            ShowText(CONST_str_VeryLongText);
        }

        private void OnClick_Button_AnimationText() {
            nowSubstringLength = 0;
        }

        private void ShowText(string text) {
            Text_BestFit.text = text;
            Text_NoBestFit.text = text;
        }

    }
}