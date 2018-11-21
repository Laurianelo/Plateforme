using UnityEngine;

namespace UnitySampleAssets._2D
{

    public class Camera2DFollow : MonoBehaviour
    {

        public Transform target;
        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;

        private float offsetZ;
        private Vector3 lastTargetPosition;
        private Vector3 currentVelocity;
        private Vector3 lookAheadPos;


        private void Start()
        {
            lastTargetPosition = target.position;
            offsetZ = (transform.position - target.position).z;
            transform.parent = null;
        }


        private void Update()
        {
            if(target == null)
            {
                return;
            }
            // only update lookahead pos if accelerating or changed direction
            float _xMoveDelta = (target.position - lastTargetPosition).x;

            bool _updateLookAheadTarget = Mathf.Abs(_xMoveDelta) > lookAheadMoveThreshold;

            if (_updateLookAheadTarget)
            {
                lookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(_xMoveDelta);
            }
            else
            {
                lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
            }

            Vector3 _aheadTargetPos = target.position + lookAheadPos + Vector3.forward*offsetZ;
            Vector3 _newPos = Vector3.SmoothDamp(transform.position, _aheadTargetPos, ref currentVelocity, damping);

            float _newPosY = Mathf.Clamp(_newPos.y, -2, Mathf.Infinity);

            _newPos.y = _newPosY;

            transform.position = _newPos;

            lastTargetPosition = target.position;
        }
    }
}