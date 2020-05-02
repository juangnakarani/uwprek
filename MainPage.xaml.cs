using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using uwprek.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace uwprek
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, IReceivingHeader
    {
        private List<ReceivingHeader> receivingHeaders;
        private NetworkTask networkTask;
        public MainPage()
        {
            this.InitializeComponent();

            networkTask = new NetworkTask(this);

        }

        public void OnSuccessReceivingHeaders(List<ReceivingHeader> receivingHeaders)
        {
            this.receivingHeaders = receivingHeaders;

            foreach (ReceivingHeader rh in this.receivingHeaders)
            {
                System.Diagnostics.Debug.WriteLine(rh.ID);
                System.Diagnostics.Debug.WriteLine(rh.DocDate);
                System.Diagnostics.Debug.WriteLine(rh.DocNumber);
                System.Diagnostics.Debug.WriteLine(rh.Notes);
                System.Diagnostics.Debug.WriteLine(rh.RFID);
                System.Diagnostics.Debug.WriteLine(rh.Species.ID);
                System.Diagnostics.Debug.WriteLine(rh.Supplier.ID);
                System.Diagnostics.Debug.WriteLine("+==========================================+");
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            /*NetworkRequest nw = new NetworkRequest();
            nw.GetReceivingHeaders();*/
            this.networkTask.DownloadReceivingData();

            
        }
    }
}
