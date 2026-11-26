using UnityEngine;
using Catopoly.Core;

namespace Catopoly.Views
{
    public abstract class BaseView<TModel> : MonoBehaviour where TModel : BaseModel
    {
        protected TModel Model;

        public virtual void Bind(TModel model)
        {
            Model = model;
            Model.OnChanged += OnModelChanged;
        }

        protected virtual void OnModelChanged(BaseModel model)
        {
            // Переопределяется в наследниках
        }

        protected virtual void OnDestroy()
        {
            if (Model != null)
            {
                Model.OnChanged -= OnModelChanged;
            }
        }
    }
}