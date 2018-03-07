using EPiServer.Core.PropertySettings;
using EPiServer.Editor.TinyMCE;
using EPiServer.Security;
using System;
using System.Collections.Generic;

namespace Boost.Seo.Ascend.Playground.Business.Rendering
{
    public class DefaultTinyMceSettings : PropertySettings<TinyMCESettings>
    {
        public override Guid ID => new Guid("29b4d928-1928-4844-91fc-7e78ad9c0321");

        public DefaultTinyMceSettings()
        {
            IsDefault = true;
            DisplayName = "Default settings";
            Description = "Default settings";
        }

        public override TinyMCESettings GetPropertySettings()
        {
            var settings = new TinyMCESettings();

            var firstToolbar = new ToolbarRow(new List<string>
            {
                TinyMCEButtons.BulletedList,
                TinyMCEButtons.NumericList,
                TinyMCEButtons.StyleSelect,
                TinyMCEButtons.CleanUp,
                TinyMCEButtons.RemoveFormat,
                TinyMCEButtons.Separator,
                TinyMCEButtons.Cut,
                TinyMCEButtons.Copy,
                TinyMCEButtons.Paste,
                TinyMCEButtons.PasteWord
            });

            settings.ToolbarRows.Add(firstToolbar);

            if (PrincipalInfo.CurrentPrincipal.IsInRole("WebAdmins"))
            {
                var secondToolbar = new ToolbarRow(new List<string>
                {
                    TinyMCEButtons.Code
                });

                settings.ToolbarRows.Add(secondToolbar);
            }

            settings.Height = 300;
            settings.Width = 600;

            settings.NonVisualPlugins.Add("paste_auto_cleanup_on_paste");

            return settings;
        }
    }
}