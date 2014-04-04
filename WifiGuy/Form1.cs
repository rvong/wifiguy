using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagedWifi;
using System.Diagnostics;


namespace WifiGuy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        WlanClient wc = new WlanClient();  
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (WlanInterface wItf in wc.Interfaces)
            {
                Debug.WriteLine("==================");
                Debug.WriteLine("Autoconf: " + wItf.Autoconf);
                Debug.WriteLine("BssType: " + wItf.BssType);
                Debug.WriteLine("Channel: " + wItf.Channel);

                Debug.WriteLine("CurrentConnection: " + wItf.CurrentConnection.isState);
                Debug.WriteLine("Dot11Bssid: " + wItf.CurrentConnection.wlanAssociationAttributes.Dot11Bssid);
                Debug.WriteLine("wlanConnectionMode: " + wItf.CurrentConnection.wlanConnectionMode);
                Debug.WriteLine("CurrentOperationMode: " + wItf.CurrentOperationMode);


                Debug.WriteLine("InterfaceDescription: " + wItf.InterfaceDescription);
                Debug.WriteLine("InterfaceState: " + wItf.InterfaceState);
                Debug.WriteLine("InterfaceGuid: " + wItf.InterfaceGuid);

                Debug.WriteLine("Description: " + wItf.NetworkInterface.Description);
                Debug.WriteLine("Id: " + wItf.NetworkInterface.Id);
                Debug.WriteLine("IsReceiveOnly: " + wItf.NetworkInterface.IsReceiveOnly);
                Debug.WriteLine("Name: " + wItf.NetworkInterface.Name);
                Debug.WriteLine("NetworkInterfaceType: " + wItf.NetworkInterface.NetworkInterfaceType);
                Debug.WriteLine("OperationalStatus: " + wItf.NetworkInterface.OperationalStatus);
                Debug.WriteLine("Speed: " + wItf.NetworkInterface.Speed / 1000000);
                Debug.WriteLine("SupportsMulticast: " + wItf.NetworkInterface.SupportsMulticast);

                Debug.WriteLine("RSSI: " + wItf.Rssi);
                Debug.WriteLine("==================");
                foreach (Wlan.WlanAvailableNetwork wAvail in wItf.GetAvailableNetworkList(Wlan.WlanGetAvailableNetworkFlags.IncludeAllAdhocProfiles))
                {
                    Debug.WriteLine("----- W AVAIL ------");
                    Debug.WriteLine("SSID: " + Encoding.Default.GetString(wAvail.dot11Ssid.SSID));
                    Debug.WriteLine("");
                    Debug.WriteLine("AuthAlgo: " + wAvail.dot11DefaultAuthAlgorithm);
                    Debug.WriteLine("CipherAlgo: " + wAvail.dot11DefaultCipherAlgorithm);
                    Debug.WriteLine("SignalQual: " + wAvail.wlanSignalQuality);

                }

                foreach (Wlan.WlanBssEntryN bss in wItf.GetNetworkBssList())
                {
                    Debug.WriteLine("----- BSS ENTRY ----");
                    Debug.WriteLine("chCenterFrequency: " + bss.BaseEntry.chCenterFrequency);
                    Debug.WriteLine("dot11Bssid: " + BitConverter.ToString(bss.BaseEntry.dot11Bssid));
                    Debug.WriteLine("dot11BssPhyType: " + bss.BaseEntry.dot11BssPhyType);
                    Debug.WriteLine("dot11BssType: " + bss.BaseEntry.dot11BssType);
                    Debug.WriteLine("dot11Ssid: " + Encoding.Default.GetString(bss.BaseEntry.dot11Ssid.SSID));
                    Debug.WriteLine("");
                    Debug.WriteLine("ieOffsetv" + bss.BaseEntry.ieOffset);
                    Debug.WriteLine("ieSize: " + bss.BaseEntry.ieSize);
                    Debug.WriteLine("linkQuality: " + bss.BaseEntry.linkQuality);
                    Debug.WriteLine("rssi: " + bss.BaseEntry.rssi);
                    Debug.WriteLine("wlanRateSet Rates: " + String.Join(", ", bss.BaseEntry.wlanRateSet.Rates));

                    Debug.WriteLine(Encoding.Default.GetString(bss.IEs));
                }
                  
            }
        }

    }
}
