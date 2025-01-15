using System;
using UnityEngine;

namespace Com.Yeonho.BbyD
{
    public class Manager : MonoBehaviour
    {
        private static Manager _instance;
        public static Manager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindAnyObjectByType<Manager>();
                }
                return _instance;
            }
        }

        private GameManager _gameManager;
        private PhotonManager _photonManager;

        private void Awake()
        {
            _gameManager = gameObject.AddComponent<GameManager>();
        }
        public GameManager GameManager => _instance?._gameManager;
    }

}
