using UnityEngine;
using Catopoly.Core;

namespace Catopoly.Models
{
    public enum CatState
    {
        Idle,
        Walking,
        Working,
        Hungry,
        Sleeping
    }

    public class CatModel : BaseModel
    {
        private const float GroundOffset = 0.5f;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public CatState State { get; private set; }
        public Vector3 Position { get; private set; }
        public Vector3 TargetPosition { get; private set; }

        public CatModel(int id, string name, Vector3 startPosition)
        {
            Id = id;
            Name = name;
            Position = SnapToGround(startPosition);
            TargetPosition = Position;
            State = CatState.Idle;
        }

        public void MoveTo(Vector3 targetPosition)
        {
            if (State == CatState.Sleeping || State == CatState.Hungry)
                return;

            State = CatState.Walking;
            TargetPosition = SnapToGround(targetPosition);
            NotifyChanged();
        }

        public void SetState(CatState newState)
        {
            State = newState;
            NotifyChanged();
        }

        public void UpdatePosition(float speed)
        {
            if (State != CatState.Walking)
                return;

            Position = Vector3.MoveTowards(Position, TargetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(Position, TargetPosition) < 0.01f)
            {
                Position = TargetPosition;
                State = CatState.Idle;
                NotifyChanged();
            }
        }

        private Vector3 SnapToGround(Vector3 pos)
        {
            pos.y = GroundOffset;
            return pos;
        }
    }
}