using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using NodeManagement;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Net.NetworkInformation;

namespace NodeManagerUI
{
    public partial class MainWindow 
    {
        NodeManager nodeMan; 
        ObservableCollection<INetworkInterfaceObject> nodes;
        CancellationTokenSource simulateTokenSource;
        CancellationToken simulateToken;

        public MainWindow()
        {
            InitializeComponent();

            btnAdd.IsEnabled = true;
            btnRemove.IsEnabled = false;
            btnOptions.IsEnabled = false;
            btnSimulate.IsEnabled = false;
            btnSimulateOff.IsEnabled = false;

            nodeMan = new NodeManager();
            nodes =  new ObservableCollection<INetworkInterfaceObject>(nodeMan.GetNodes());

            dataGrid.ItemsSource = nodes;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (!btnSimulate.IsEnabled)
            {
                simulateTokenSource = new CancellationTokenSource();
                simulateToken = simulateTokenSource.Token;

                simulateTokenSource.Cancel();
            }

            btnAdd.IsEnabled = false;
            btnOptions.IsEnabled = false;
            btnSimulate.IsEnabled = false;
            btnSimulateOff.IsEnabled = false;

            Task<ObservableCollection<INetworkInterfaceObject>> T = Task.Factory.StartNew((n) =>
            {
                ObservableCollection<INetworkInterfaceObject> nio = (ObservableCollection<INetworkInterfaceObject>)n;

                Thread.Sleep(600);

                return nio;
            },
            nodes
            );
            Task T2 = T.ContinueWith((previousTask) =>
            {
                NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

                foreach (NetworkInterface ni in interfaces)
                {
                    previousTask.Result.Add(new NetworkInterfaceObject(ni.Id, ni.Name, ni.Description, ni.NetworkInterfaceType, ni.Speed, ni.OperationalStatus));
                }

                // code to update UI once previousTask is finished
                //btnAdd.IsEnabled = true;
                btnOptions.IsEnabled = true;
                btnSimulate.IsEnabled = true;
            },
            TaskScheduler.FromCurrentSynchronizationContext()
            );
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            List<NetworkInterfaceObject> selectedRows = dataGrid.SelectedItems.Cast<NetworkInterfaceObject>().ToList();

            foreach (var selectedRow in selectedRows)
            {
                nodes.Remove(selectedRow);
            }
        }

        //private void On_Click(object sender, RoutedEventArgs e)
        //{
        //    List<NetworkInterfaceObject> selectedRows = dataGrid.SelectedItems.Cast<NetworkInterfaceObject>().ToList();

        //    foreach (var selectedRow in selectedRows)
        //    {
        //        foreach (var node in nodes)
        //        {
        //            if (node.Equals(selectedRow))
        //            {
        //                node.SetOnline();
        //            }
        //        }
        //    }
        //}

        //private void Off_Click(object sender, RoutedEventArgs e)
        //{
        //    List<NetworkInterfaceObject> selectedRows = dataGrid.SelectedItems.Cast<NetworkInterfaceObject>().ToList();

        //    foreach (var selectedRow in selectedRows)
        //    {
        //        foreach (var node in nodes)
        //        {
        //            if (node.Equals(selectedRow))
        //            {
        //                node.SetOffline();
        //            }
        //        }
        //    }
        //}

        private void Options_Click(object sender, RoutedEventArgs e)
        {
            List<NetworkInterfaceObject> selectedRows = dataGrid.SelectedItems.Cast<NetworkInterfaceObject>().ToList();

            OptionsWindow optionsWindow = new OptionsWindow(selectedRows, nodes);
            optionsWindow.Show();
        }

        private async void Simulate_Click(object sender, RoutedEventArgs e)
        {
            btnSimulate.IsEnabled = false;
            btnSimulateOff.IsEnabled = true;

            simulateTokenSource = new CancellationTokenSource();
            simulateToken = simulateTokenSource.Token;

            try
            {
                await Task.Factory.StartNew(() =>
                {
                    try
                    {
                        NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                       
                        while (true)
                        {
                            if (simulateToken.IsCancellationRequested)
                            {
                                // cleanup

                                simulateToken.ThrowIfCancellationRequested();
                            }

                            foreach (var item in nodes)
                            {
                                NetworkInterface ni = interfaces.Where(i => i.Id == item.NetworkInterfaceId).FirstOrDefault();

                                if (ni != null)
                                {
                                    item.BytesReceived = ni.GetIPv4Statistics().BytesReceived;
                                    item.BytesSent = ni.GetIPv4Statistics().BytesSent;
                                }
                                
                            }

                            Thread.Sleep(500);
                        }
                    }
                    catch (OperationCanceledException)
                    {

                    }

                }, simulateToken);
            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();

                foreach (var ex in ae.InnerExceptions)
                {
                    if (ex is OperationCanceledException)
                    {
                        ; // ignore cancel
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show("Error in Simulation Task" + ex.Message, "Simulation Task Error");
                    }
                }
            }
        }

        //private async void Simulate_Click(object sender, RoutedEventArgs e)
        //{
        //    btnSimulate.IsEnabled = false;
        //    btnSimulateOff.IsEnabled = true;

        //    simulateTokenSource = new CancellationTokenSource();
        //    simulateToken = simulateTokenSource.Token;

        //    try
        //    {
        //        await Task.Factory.StartNew(() =>
        //        {
        //            try
        //            {
        //                while (true)
        //                {
        //                    if (simulateToken.IsCancellationRequested)
        //                    {
        //                        // cleanup

        //                        simulateToken.ThrowIfCancellationRequested();
        //                    }

        //                    foreach (Node node in nodes)
        //                    {
        //                        if (node.IsOnline)
        //                        {
        //                            node.SimulateRandomMetrics();
        //                        }
        //                    }

        //                    Thread.Sleep(500);
        //                }
        //            }
        //            catch (OperationCanceledException)
        //            {

        //            }

        //        }, simulateToken);
        //    }
        //    catch (AggregateException ae)
        //    {
        //        ae = ae.Flatten();

        //        foreach (var ex in ae.InnerExceptions)
        //        {
        //            if (ex is OperationCanceledException)
        //            {
        //                ; // ignore cancel
        //            }
        //            else
        //            {
        //                MessageBoxResult result = MessageBox.Show("Error in Simulation Task" + ex.Message, "Simulation Task Error");
        //            }
        //        }
        //    }
        //}

        private void SimulateOff_Click(object sender, RoutedEventArgs e)
        {
            btnSimulateOff.IsEnabled = false;

            simulateTokenSource.Cancel();

            foreach (NetworkInterfaceObject node in nodes)
            {
                node.ResetMetrics();
            }

            btnSimulate.IsEnabled = true;
        }

        private void windowsMain_Loaded(object sender, RoutedEventArgs e)
        {
            // height of window to be 80% of the screen Height
            Height = SystemParameters.PrimaryScreenHeight * 0.8;
        }
    }
}