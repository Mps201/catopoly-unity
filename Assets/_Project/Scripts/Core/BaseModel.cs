using System;

namespace Catopoly.Core
{
    public abstract class BaseModel
    {
        public event Action<BaseModel> OnChanged;

        protected void NotifyChanged()
        {
            OnChanged?.Invoke(this);
        }

        public virtual void Cleanup()
        {
            OnChanged = null;
        }
    }
}