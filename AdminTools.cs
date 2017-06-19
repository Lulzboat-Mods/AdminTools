using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace AdminTools
{
    public class AdminTools : BaseScript
    {
        public Entity LocalEntity
        {
            get
            {
                return (Entity.FromHandle(LocalPlayer.Handle));
            }
            private set { }
        }
        bool adminToolState = false;

        public AdminTools()
        {
            Tick += OnTick;
        }

        async Task OnTick()
        {
            if (Game.IsControlJustPressed(0, Control.MultiplayerInfo))
                ToggleAdminTool();
        }

        void ToggleAdminTool()
        {
            if (adminToolState)
            {
                LocalPlayer.IsInvincible = true;
                LocalPlayer.IgnoredByEveryone = true;
                LocalEntity.IsVisible = true;
            }
            else
            {
                LocalPlayer.IsInvincible = false;
                LocalPlayer.IgnoredByEveryone = false;
                LocalEntity.IsVisible = false;
            }
        }
    }
}
