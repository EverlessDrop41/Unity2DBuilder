using UnityEngine;
using System.Collections;

namespace TwoDBuilder.Controllers
{
    public class CameraControl : MonoBehaviour
    {

        public float MoveSpeed = 10f;
        public float ZoomSpeed = 1f;
        public Camera GameCamera;

        public float MaxCameraSize = 30f;
        public const float MinCameraSize = 1f;

        private float _relativeMoveSpeed;

        // Use this for initialization
        void Start()
        {
            _relativeMoveSpeed = MoveSpeed;
            if (GameCamera == null)
            {
                GameCamera = Camera.main;
            }
        }

        // Update is called once per frame
        void Update()
        {
            float zoomInput = Input.GetAxis("CameraZoom");
            GameCamera.orthographicSize += zoomInput * ZoomSpeed;
            GameCamera.orthographicSize = Mathf.Clamp(GameCamera.orthographicSize, MinCameraSize, MaxCameraSize);

            _relativeMoveSpeed = MoveSpeed * GameCamera.orthographicSize / 2;

            float horzInpt = Input.GetAxis("Horizontal");
            float vertInpt = Input.GetAxis("Vertical");

            float horzMove = horzInpt * _relativeMoveSpeed;
            float vertMove = vertInpt * _relativeMoveSpeed;

            GameCamera.transform.position += new Vector3(horzMove * Time.deltaTime, vertMove * Time.deltaTime);
        }
    }
}