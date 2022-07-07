using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher
{
    public class DynastioSettings
    {
        public static bool DeleteDynastioRegistry()
        {
            try
            {
                string keyName = @"SOFTWARE\Whalebox Studio";
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName, true))
                {
                    key.DeleteSubKeyTree("Dynast.io");
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool ChangeServer(string server)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(server + "x");
            bytes[bytes.Length - 1] = 0;
            try
            {
                using (RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Whalebox Studio\\Dynast.io"))
                {
                    registryKey.SetValue("selected_server_h1540196278", bytes);
                    registryKey.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool ChangeNickname(string Nickname)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(Nickname + "x");
            bytes[bytes.Length - 1] = 0;
            try
            {
                using (RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Whalebox Studio\\Dynast.io"))
                {
                    registryKey.SetValue("nickname_h1560818637", bytes);
                    registryKey.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool ChangeSkinColor(byte[] colorBytes1 = null, byte[] colorBytes2 = null)
        {
            byte[] bytes = { 00, 00, 00, 00, 00, 00, 255, 255 };
            try
            {
                using (RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Whalebox Studio\\Dynast.io"))
                {
                    registryKey.SetValue("primarycoloridx_h3130811969", colorBytes1 ?? bytes);
                    registryKey.SetValue("secondarycoloridx_h1304026039", colorBytes2 ?? bytes);
                    registryKey.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
