
using LitJson;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Solution.SaveGameInJsonTextFile {

    public class SaveGameInJsonTextFile : MonoBehaviour {

        //玩家本體Transform
        [SerializeField] private Transform player;

        //現在位置
        [SerializeField] private Text text_Position;
        //存讀檔按鈕
        [SerializeField] private Button btn_Save;
        [SerializeField] private Button btn_Load;
        [SerializeField] private Button btn_OpenSaveFolder;
        //存讀檔訊息
        [SerializeField] private Text text_SaveLoadInfo;

        //檔案路徑
        private string FilePath => Path.Combine(Application.persistentDataPath, "PlayerPosition.pos");

        void Start() {
            btn_Save.onClick.RemoveAllListeners();
            btn_Save.onClick.AddListener(SaveGame);
            btn_Load.onClick.RemoveAllListeners();
            btn_Load.onClick.AddListener(LoadGame);
            btn_OpenSaveFolder.onClick.RemoveAllListeners();
            btn_OpenSaveFolder.onClick.AddListener(OpenSaveFolder);
        }

        void Update() {
            Vector3 pos = player.position;
            text_Position.text = $"X: {pos.x:F2}\nY: {pos.y:F2}\nZ: {pos.z:F2}";
        }

        /// <summary>
        /// 存檔
        /// </summary>
        private void SaveGame() {
            try {
                //取得玩家座標
                Vector3 pos = player.position;
                //準備存檔資料格式
                var saveData = new SaveData();
                saveData.positionX = pos.x;
                saveData.positionY = pos.y;
                saveData.positionZ = pos.z;
                //將資料轉換成json文字格式
                var dataJson = JsonMapper.ToJson(saveData);
                //寫入檔案
                File.WriteAllText(FilePath, dataJson);

                text_SaveLoadInfo.text = $"[{DateTime.Now}] 存檔完成";
            } catch (Exception e) {
                //出現無法預期的問題，列出Error
                Debug.LogError(e);
                text_SaveLoadInfo.text = $"[{DateTime.Now}] 存檔失敗";
            }
        }

        /// <summary>
        /// 讀檔
        /// </summary>
        private void LoadGame() {
            try {
                //檢查檔案是否存在
                if (File.Exists(FilePath)) {
                    //檔案存在時
                    Vector3 pos = Vector3.zero;
                    //進行讀取(檔案中的文字)
                    string data_raw = File.ReadAllText(FilePath);
                    //將json文字轉換成座標
                    var saveData = JsonMapper.ToObject<SaveData>(data_raw);
                    pos.x = saveData.positionX;
                    pos.y = saveData.positionY;
                    pos.z = saveData.positionZ;
                    //代回玩家身上
                    player.position = pos;

                    text_SaveLoadInfo.text = $"[{DateTime.Now}] 讀檔完成";
                } else {
                    text_SaveLoadInfo.text = $"[{DateTime.Now}] 檔案不存在";
                }
            } catch (Exception e) {
                //出現無法預期的問題，列出Error
                Debug.LogError(e);
                text_SaveLoadInfo.text = $"[{DateTime.Now}] 讀檔失敗";
            }
        }

        /// <summary>
        /// 打開存檔資料夾
        /// </summary>
        private void OpenSaveFolder() {
            Application.OpenURL(Application.persistentDataPath);
        }
    }
}