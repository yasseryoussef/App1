using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Syncfusion.SfDataGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App1
{
    [Activity(Label = "Activity1")]
    public class Activity1 : Activity
    {
        BluetoothAdapter blue;
        List<devices_list_model> mitems = new List<devices_list_model>();
        SfDataGrid datagrid; 
        public class devices_list_model
        {
            public string device_name { get; set; }
            public string device_address { get; set; }
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            blue = BluetoothAdapter.DefaultAdapter;
            foreach (BluetoothDevice bt in blue.BondedDevices)
            {
                mitems.Add(new devices_list_model
                {

                    device_name = bt.Name,
                    device_address = bt.Address
                });

            }

           datagrid = new Syncfusion.SfDataGrid.SfDataGrid(this);
            datagrid.ItemsSource = mitems;


            SetContentView(datagrid);

            datagrid.GridTapped += Datagrid_GridTapped;
            // Create your application here
        }

        private void Datagrid_GridTapped(object sender, Syncfusion.SfDataGrid.GridTappedEventArgs e)
        {
            var row = e.RowColumnIndex.RowIndex;
           
            var rowData = datagrid.GetRecordAtRowIndex(row);
            string cellValue = datagrid.GetCellValue(rowData, "device_address").ToString();

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(Android.App.Application.Context);
            ISharedPreferencesEditor editor = prefs.Edit();


            editor.PutString("printer_mac", cellValue);
            editor.Apply();
            this.Finish();
        }
    }
}