using UnityEngine;
using Catopoly.Core;

namespace Catopoly.Controllers
{
    public abstract class BaseController : MonoBehaviour
    {
        public BaseModel Model;
        public MonoBehaviour View;

        public virtual void Initialize()
        {
            // Переопределяется в наследниках
        }

        protected virtual void OnDestroy()
        {
            if (Model != null)
            {
                Model.Cleanup();
            }
        }
    }
}