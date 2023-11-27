using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessiblee.InputController.InputVariations
{

    public class InteractionInput : IInputModifier
    {
        #region Disable Functionality

        /// <summary>
        /// We want to make sure we are disabling all features related to this modifier
        /// </summary>

        bool active = false;

        void IInputModifier.Disable()
        {
            if (!active)
                return;

            // Disable features
        }

        #endregion

        void IInputModifier.Stream()
        {

        }
    }
}
