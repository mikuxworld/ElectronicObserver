using ElectronicObserver.Window.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot {
    public class Plugin : DockPlugin {
        public override string MenuTitle {
            get { return "BOT"; }
        }

        public override string Version {
            get { return "0.0.1"; }
        }

        public override PluginSettingControl GetSettings () {
            return new Settings();
        }
    }
}
