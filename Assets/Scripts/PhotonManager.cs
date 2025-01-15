using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Com.Yeonho.BbyD
{
    public class PhotonManager : MonoBehaviourPunCallbacks
    {
        #region Private Serializable
        [SerializeField]
        private byte _maxPlayerPerRoom = 4;
        [SerializeField]
        private GameObject _controlPanel;
        [SerializeField]
        private GameObject _progressLabel;
        #endregion

        #region Private Field

        private string _gameVersion = "1";

        #endregion

        #region MonoBehaviour CallBacks

        private void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }
        private void Start()
        {
            _progressLabel.SetActive(false);
            _controlPanel.SetActive(true);
        }
        #endregion

        #region Public Method

        public void Connect()
        {
            _progressLabel.SetActive(true);
            _controlPanel.SetActive(false);

            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                PhotonNetwork.GameVersion = _gameVersion;
                PhotonNetwork.ConnectUsingSettings();
            }
        }

        #endregion

        #region MonoBehaviourPunCallbacks Callbacks
        public override void OnConnectedToMaster()
        {
            Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
            PhotonNetwork.JoinRandomRoom();
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");
            PhotonNetwork.CreateRoom(null,new RoomOptions { MaxPlayers = _maxPlayerPerRoom});
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            _progressLabel.SetActive(false);
            _controlPanel.SetActive(true);

            Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
        }

        #endregion
    }
}
