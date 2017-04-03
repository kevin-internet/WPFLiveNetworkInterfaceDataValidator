using NodeManagement;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NodeManagerUI
{
    public partial class OptionsWindow
    {
        private List<NetworkInterfaceObject> _selectedRows;
        ObservableCollection<INetworkInterfaceObject> _nodes;

        public OptionsWindow(List<NetworkInterfaceObject> selectedRows, ObservableCollection<INetworkInterfaceObject> nodes)
        {
            _selectedRows = selectedRows;
            _nodes = nodes;

            InitializeComponent();
            
            txtBytesSent.Text = MaximumThresholdValues.MaxBytesSent.ToString();
            txtBytesReceived.Text = MaximumThresholdValues.MaxBytesReceived.ToString();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            SetMaxThresholdValues();
            this.Close();
        }

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            SetMaxThresholdValues();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SetMaxThresholdValues()
        {
            long fMaxBytesSent;
            long fMaxReceived;

            try
            {
                fMaxBytesSent = long.Parse(txtBytesSent.Text);
                fMaxReceived = long.Parse(txtBytesReceived.Text);
            }
            catch (Exception ex)
            {
                MessageBoxResult result = MessageBox.Show("Error Entering a Max Threshold Value " + ex.Message, "Max Threshold Values - User Input Error");

                return;
            }

            if (_selectedRows.Count > 0)
            {
                foreach (var selectedRow in _selectedRows)
                {
                    foreach (var node in _nodes)
                    {
                        if (node.Equals(selectedRow))
                        {
                            MaximumThresholdValues.MaxBytesSent = fMaxBytesSent;
                            MaximumThresholdValues.MaxBytesReceived = fMaxReceived;
                        }
                    }
                }
            }
            
        }
    }
}
