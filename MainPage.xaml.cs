using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<ReceivingHeader> receivingHeaderObservable;
        private NetworkTask networkTask;
        public MainPage()
        {
            this.InitializeComponent();

            networkTask = new NetworkTask(this);
            receivingHeaderObservable = new ObservableCollection<ReceivingHeader>();
        }

        public void OnSuccessReceivingHeaders(List<ReceivingHeader> receivingHeaders)
        {
            receivingHeaders.ForEach(o => receivingHeaderObservable.Add(o));
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            /*NetworkRequest nw = new NetworkRequest();
            nw.GetReceivingHeaders();*/
            this.networkTask.DownloadReceivingData();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.networkTask.DownloadReceivingData();
        }
    }
}
