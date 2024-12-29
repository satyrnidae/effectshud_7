using Cairo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.Common;

namespace effectshud.src.gui
{
    public class GuiElementImageWithTier : GuiElementTextBase
    {
        private readonly string imageAsset;
        int tier;
        bool positive;
        public GuiElementImageWithTier(ICoreClientAPI capi, ElementBounds bounds, string imageAsset, int tier, bool positive) : base(capi, "", null, bounds)
        {
            this.imageAsset = imageAsset;
            this.tier = tier;
            this.positive = positive;
        }
        public override void ComposeElements(Context context, ImageSurface surface)
        {
            context.Save();
            IAsset asset = api.Assets.TryGet(string.Format("effectshud:textures/effects/{0}.png", imageAsset));
            ImageSurface imageSurface = GuiElement.getImageSurfaceFromAsset(this.api, asset.Location, 255);
            SurfacePattern pattern = GuiElement.getPattern(this.api, asset.Location, true, 255, 1f);
            pattern.Filter = Filter.Best;
            context.SetSource(pattern);
            context.Rectangle(this.Bounds.drawX, this.Bounds.drawY, this.Bounds.OuterWidth, this.Bounds.OuterHeight);
            context.SetSourceSurface(imageSurface, (int)this.Bounds.drawX, (int)this.Bounds.drawY);

            context.Paint();
            if (tier > 0)
            {
                var assetTier = api.Assets.TryGet("effectshud:textures/effects/tier" + tier + (positive ? "p" : "n") + ".png");
                if (assetTier != null)
                {
                    var gemSurface = GuiElement.getImageSurfaceFromAsset(api, api.Assets.TryGet("effectshud:textures/effects/tier" + tier + (positive ? "p" : "n") + ".png").Location, 255);
                    context.SetSourceSurface(gemSurface, (int)this.Bounds.drawX, (int)this.Bounds.drawY);
                    context.Paint();             
                }
            }
            context.FillPreserve();
            context.Restore();
            pattern.Dispose();
            imageSurface.Dispose();
        }

    }
}
