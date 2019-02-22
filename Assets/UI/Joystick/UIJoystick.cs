using UnityEngine;
using UnityEngine.EventSystems;

namespace Elements.UI
{
    [AddComponentMenu("UI/Joystick", 36), RequireComponent(typeof(RectTransform))]
    public class UIJoystick : UIBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {

        [SerializeField, Tooltip("Element to drag by.")]
        private RectTransform handle;
        public RectTransform Handle
        {
            get { return handle; }
            set
            {
                handle = value;
                UpdateHandle();
            }
        }

        [SerializeField, Tooltip("Element on wich to drag.")]
        public RectTransform handlingArea;

        [SerializeField]
        private Vector2 axis;

        [SerializeField, Tooltip("Return speed of handle.")]
        public float returnSpeed = 20f;

        [SerializeField, Tooltip("The axis output will be zero 0 around this area.")]
        public float deadZone = 0.1f;

        [Tooltip("Customize the output that is sent in OnValueChange")]
        public AnimationCurve outputCurve = new AnimationCurve(new Keyframe(0, 0, 1, 1), new Keyframe(1, 1, 1, 1));


        public Vector2 JoystickAxis
        {
            get
            {
                Vector2 outputPoint = axis.magnitude > deadZone ? axis : Vector2.zero;
                float magnitude = outputPoint.magnitude;

                outputPoint *= outputCurve.Evaluate(magnitude);

                return outputPoint;
            }
            set { SetAxis(value); }
        }

        private bool isDragging;

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();

            // Fix anchors
            if (handlingArea != null)
            {
                handlingArea.anchorMin = new Vector2(0.5f, 0.5f);
                handlingArea.anchorMax = new Vector2(0.5f, 0.5f);
            }

            UpdateHandle();
        }
#endif

        protected override void OnEnable()
        {
            base.OnEnable();

            if (handlingArea == null)
                handlingArea = transform as RectTransform;
        }


        protected void LateUpdate()
        {
            if (isActiveAndEnabled && !isDragging)
            {
                if (axis != Vector2.zero)
                {
                    Vector2 newAxis = axis - (axis * Time.unscaledDeltaTime * returnSpeed);

                    if (newAxis.sqrMagnitude <= .0001f)
                        newAxis = Vector2.zero;

                    SetAxis(newAxis);
                }
            }
        }

        public void SetAxis(Vector2 newAxis)
        {
            axis = Vector2.ClampMagnitude(newAxis, 1);

            Vector2 outputPoint = axis.magnitude > deadZone ? axis : Vector2.zero;
            float magnitude = outputPoint.magnitude;

            outputPoint *= outputCurve.Evaluate(magnitude);

            UpdateHandle();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!IsActive() || handlingArea == null)
                return;

            Vector2 newAxis = handlingArea.InverseTransformPoint(eventData.position);
            newAxis.x /= handlingArea.sizeDelta.x * 0.5f;
            newAxis.y /= handlingArea.sizeDelta.y * 0.5f;

            SetAxis(newAxis);
            isDragging = true;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            isDragging = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (handlingArea == null)
                return;

            Vector2 newAxis = Vector2.zero;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(handlingArea, eventData.position, eventData.pressEventCamera, out newAxis);

            newAxis -= handlingArea.rect.center;
            newAxis.x /= handlingArea.sizeDelta.x * 0.5f;
            newAxis.y /= handlingArea.sizeDelta.y * 0.5f;

            SetAxis(newAxis);
        }

        private void UpdateHandle()
        {
            if (handle && handlingArea)
            {
                handle.anchoredPosition = new Vector2(axis.x * handlingArea.sizeDelta.x * 0.5f, axis.y * handlingArea.sizeDelta.y * 0.5f);
            }
        }

    }
}
