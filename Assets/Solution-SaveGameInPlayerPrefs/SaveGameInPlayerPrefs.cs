
using UnityEngine;
using UnityEngine.UI;

namespace Solution.SaveGameInPlayerPrefs {

    public class SaveGameInPlayerPrefs : MonoBehaviour {

        //玩家本體Transform
        [SerializeField] private Transform player;

        //現在位置
        [SerializeField] private Text text_Position;
        //存讀檔按鈕
        [SerializeField] private Button btn_Save;
        [SerializeField] private Button btn_Load;
        //存讀檔訊息
        [SerializeField] private Text text_SaveLoadInfo;

        private const string Key_PlayerPositionX = "PlayerPositionX";
        private const string Key_PlayerPositionY = "PlayerPositionY";
        private const string Key_PlayerPositionZ = "PlayerPositionZ";

        void Start() {
            btn_Save.onClick.RemoveAllListeners();
            btn_Save.onClick.AddListener(SaveGame);
            btn_Load.onClick.RemoveAllListeners();
            btn_Load.onClick.AddListener(LoadGame);
        }

        void Update() {
            Vector3 pos = player.position;
            text_Position.text = $"X: {pos.x:F2}\nY: {pos.y:F2}\nZ: {pos.z:F2}";
        }

        /// <summary>
        /// 存檔
        /// </summary>
        private void SaveGame() {
            Vector3 pos = player.position;
            PlayerPrefs.SetFloat(Key_PlayerPositionX, pos.x);
            PlayerPrefs.SetFloat(Key_PlayerPositionY, pos.y);
            PlayerPrefs.SetFloat(Key_PlayerPositionZ, pos.z);
            PlayerPrefs.Save();
            text_SaveLoadInfo.text = $"[{System.DateTime.Now}] 存檔完成";
        }

        /// <summary>
        /// 讀檔
        /// </summary>
        private void LoadGame() {
            Vector3 pos;
            pos.x = PlayerPrefs.GetFloat(Key_PlayerPositionX, 0f);
            pos.y = PlayerPrefs.GetFloat(Key_PlayerPositionY, 0f);
            pos.z = PlayerPrefs.GetFloat(Key_PlayerPositionZ, 0f);
            player.position = pos;
            text_SaveLoadInfo.text = $"[{System.DateTime.Now}] 讀檔完成";
        }

    }
}