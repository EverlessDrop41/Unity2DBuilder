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

        // Use this for initialization
        void Start()
        {
            if (GameCamera == null)
            {
                GameCamera = Camera.main;
            }
        }

        // Update is called once per frame
        void Update()
        {
            float horzInpt = Input.GetAxis("Horizontal");
            float vertInpt = Input.GetAxis("Vertical");

            float horzMove = horzInpt * MoveSpeed;
            float vertMove = vertInpt * MoveSpeed;

            GameCamera.transform.position += new Vector3(horzMove * Time.deltaTime, vertMove * Time.deltaTime);

            float zoomInput = Input.GetAxis("CameraZoom");
            GameCamera.orthographicSize += zoomInput * ZoomSpeed;
            GameCamera.orthographicSize = Mathf.Clamp(GameCamera.orthographicSize, MinCameraSize, MaxCameraSize);
        }
    }
}