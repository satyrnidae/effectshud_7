using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Client;
using Vintagestory.API.Common;

namespace effectshud.src.gui
{
    public static class GuiElementHelpersForImageWithTier
    {
        public static GuiComposer AddImageWithTier(this GuiComposer composer, ElementBounds bounds, string imageAsset, int tier = 0, bool positive = true)
        {
            if (!composer.Composed)
            {
                composer.AddStaticElement(new GuiElementImageWithTier(composer.Api, bounds, imageAsset, tier, positive), null);
            }
            return composer;
        }
    }
}
