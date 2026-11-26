using UnityEngine;
using Catopoly.Core;
using Catopoly.Models;

namespace Catopoly.Views
{
    public class CatView : BaseView<CatModel>
    {
        [SerializeField] private float moveSpeed = 3f;
        private Vector3 _lastPosition;

        public override void Bind(CatModel model)
        {
            base.Bind(model);
            _lastPosition = Model.Position;
            UpdatePosition();
            UpdateState();
        }

        protected override void OnModelChanged(BaseModel model)
        {
            UpdateState();
        }

        private void Update()
        {
            if (Model != null)
            {
                Model.UpdatePosition(moveSpeed);
                UpdatePosition();
                UpdateRotation();
            }
        }

        private void UpdatePosition()
        {
            transform.position = Model.Position;
        }

        private void UpdateRotation()
        {
            Vector3 direction = Model.TargetPosition - Model.Position;
            if (direction.magnitude > 0.01f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
            }
        }

        private void UpdateState()
        {
            Debug.Log($"Cat {Model.Name} state: {Model.State}");
        }
    }
}