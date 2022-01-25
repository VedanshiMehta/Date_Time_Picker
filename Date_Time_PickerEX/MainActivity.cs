using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace Date_Time_PickerEX
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private DatePickerDialoguefragment datePickerDialoguefragment;
        private TimePickerDialogueFragment timePickerDialogueFragment;
        private TextView dateText;
        private TextView timeText;
        private Button datebutton;
        private Button timebutton;
        private readonly string _tag = "Main Activity";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            UIReference();
            ObjectCreation();
            BindEventofDateChange();
            BindEventofTimeChange();
            UIClickEVent();
        }

        private void BindEventofTimeChange()
        {
            timePickerDialogueFragment.OnTimeChangeHandler += TimePickerDialogueFragment_OnTimeChangeHandler;
        }

        private void TimePickerDialogueFragment_OnTimeChangeHandler(object sender, DateTime e)
        {
            timeText.Text = e.ToShortTimeString();
                
        }
        private void BindEventofDateChange()
        {
            datePickerDialoguefragment.OnDateChangeHandler += DatePickerDialoguefragment_OnDateChangeHandler;
        }

        private void DatePickerDialoguefragment_OnDateChangeHandler(object sender, DateTime e)
        {
            dateText.Text = e.ToString(format:"dd/MM/yyyy");
        }

        private void UIClickEVent()
        {
            datebutton.Click += Datebutton_Click;
            timebutton.Click += Timebutton_Click;
        }

        private void Timebutton_Click(object sender, EventArgs e)
        {
            timePickerDialogueFragment.Show(SupportFragmentManager, _tag);
        }

        private void Datebutton_Click(object sender, EventArgs e)
        {
            datePickerDialoguefragment.Show(SupportFragmentManager,_tag);
        }

       
        private void ObjectCreation()
        {
            datePickerDialoguefragment = new DatePickerDialoguefragment();
            timePickerDialogueFragment = new TimePickerDialogueFragment();
        }

        private void UIReference()
        {
            dateText = FindViewById<TextView>(Resource.Id.myTextDate);
            datebutton = FindViewById<Button>(Resource.Id.myButtonDate);
            timeText = FindViewById<TextView>(Resource.Id.myTextTime);
            timebutton = FindViewById<Button>(Resource.Id.myButtonTime);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}