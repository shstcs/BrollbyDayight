using Photon.Pun;
using UnityEngine;
namespace Com.Yeonho.BbyD
{
    public class PlayerAnimatorManager : MonoBehaviourPun
    {
        #region Private Field

        private Animator _animator;
        [SerializeField] private float directionDampTime = 0.25f;

        #endregion
        #region MonoBehaviour Callbacks

        void Start()
        {
            _animator = GetComponent<Animator>();
            if (!_animator)
            {
                Debug.LogError("PlayerAnimatorManager is Missing Animator Component", this);
            }
        }

        void Update()
        {
            if(photonView.IsMine == false && PhotonNetwork.IsConnected == true)
            {
                return;
            }
            if (!_animator)
            {
                return;
            }
            AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);

            if(stateInfo.IsName("Base Layer.Run"))
            {
                if (Input.GetButtonDown("Fire2"))
                {
                    _animator.SetTrigger("Jump");
                }
            }
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            if (v < 0) v = 0;
            _animator.SetFloat("Forward", h * h + v * v);
            _animator.SetFloat("Turn", h,directionDampTime,Time.deltaTime);
        }

        #endregion
    }

}
