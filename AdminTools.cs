using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitizenFX;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;

namespace AdminTools
{
    public class AdminTools : BaseScript
    {
        public Entity LocalEntity
        {
            get
            {
                return (Entity.FromHandle(Game.PlayerPed.Handle));
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
            adminToolState = !adminToolState;

            if (adminToolState)
            {
                LocalPlayer.IsInvincible = true;
                //LocalPlayer.IgnoredByEveryone = true;
                LocalEntity.IsVisible = false;
                Screen.ShowNotification("On");
            }
            else
            {
                LocalPlayer.IsInvincible = false;
                //LocalPlayer.IgnoredByEveryone = false;
                LocalEntity.IsVisible = true;
                Screen.ShowNotification("Off");
            }
        }
    }
}
