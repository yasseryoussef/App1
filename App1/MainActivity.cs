using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.AppCompat.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Snackbar;
using Android.Content;
using Android.Bluetooth;
using Java.IO;
using Java.Util;
using Android.Preferences;
using Android.Graphics;
using System.IO;
using ZJ.Com.Customize.Sdk;

namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        Android.Widget.Button btn,btn_print;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            btn = FindViewById<Android.Widget.Button>(Resource.Id.button1);
            btn.Click += Btn_Click;
            btn_print = FindViewById<Android.Widget.Button>(Resource.Id.button2);
            btn_print.Click += Btn_print_Click;
        }

        private void Btn_print_Click(object sender, EventArgs e)
        {
            BluetoothDevice hxm;
            PrintWriter oStream;
            UUID applicationUUID = UUID.FromString("00001101-0000-1000-8000-00805F9B34FB");
            string bt_printer;
            ISharedPreferences prefs;
            prefs = PreferenceManager.GetDefaultSharedPreferences(this);

            bt_printer = prefs.GetString("printer_mac", "");

            hxm = BluetoothAdapter.DefaultAdapter.GetRemoteDevice(bt_printer);
            BluetoothSocket socket = null;
            socket = hxm.CreateRfcommSocketToServiceRecord(applicationUUID);
            var x = BluetoothAdapter.DefaultAdapter.BondedDevices;
            BufferedWriter outReader = null;
            outReader = new BufferedWriter(new OutputStreamWriter(socket.OutputStream));
            oStream = new PrintWriter(socket.OutputStream, true); ;

            if (socket.IsConnected == false)

            {
                socket.Connect();
            }

            Bitmap bm1;

            MemoryStream mst = new MemoryStream();
            //  AssetManager assets = this.Assets;

              bm1 = BitmapFactory.DecodeFile("pr.bmp");
           
            Bitmap bmp;
            byte nMode;
            short nPaperWidth;
            string txt_msg = " الكلام بالعربيس ";
            bmp = Other.CreateAppIconText(bm1, txt_msg, 25.0F, true, 600);
            nMode = 0;
            nPaperWidth = 384;
            string printer_width = (prefs.GetString("paper_type", ""));
            if (printer_width == "80")
            {
                nPaperWidth = 550;
                bmp = Other.CreateAppIconText(bm1, txt_msg, 25.0F, false, 600);
              
            }
            bmp= PrintPicture.resize_bitmap(bmp, nPaperWidth, nMode);

            byte[] data= PrintPicture.POS_PrintBMP(bmp, nPaperWidth, nMode);
            socket.OutputStream.Write(command.ESC_Init, 0, command.ESC_Init.Length);
            socket.OutputStream.Write(command.LF, 0, command.LF.Length);
            socket.OutputStream.Write(data, 0, data.Length);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this.ApplicationContext, typeof(Activity1));
            StartActivity(intent);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
	}
}
