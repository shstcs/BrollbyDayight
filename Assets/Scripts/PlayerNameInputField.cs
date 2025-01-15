using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Com.Yeonho.BbyD
{
    [RequireComponent(typeof(TMP_InputField))]
    public class PlayerNameInputField : MonoBehaviour
    {
        #region Private Constants

        const string playerNamePrefKey = "PlayerName";

        #endregion

        #region MonoBehaviour CallBacks
        void Start()
        {
            string defaultName = string.Empty;
            InputField _inputField = GetComponent<InputField>();
            if(_inputField != null)
            {
                if(PlayerPrefs.HasKey(playerNamePrefKey))
                {
                    defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                    _inputField.name = defaultName;
                }
            }

            PhotonNetwork.NickName = defaultName;
        }

        #endregion

        #region Public Method

        public void SetPlayerName(string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                Debug.LogError("Player Name is null or Empty");
                return;
            }
            PhotonNetwork.NickName = value;
            PlayerPrefs.SetString(playerNamePrefKey, value);
        }

        #endregion
    }

}