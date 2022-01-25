using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Date_Time_PickerEX
{
    class TimePickerDialogueFragment : AndroidX.Fragment.App.DialogFragment, TimePickerDialog.IOnTimeSetListener
    {
        public event EventHandler<DateTime> OnTimeChangeHandler;
        public override Android.App.Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            DateTime currentDT = DateTime.Now;
            TimePickerDialog timepicker = new TimePickerDialog(Activity, Resource.Style._mydatepicker, this, currentDT.Hour,currentDT.Minute,true);
            return timepicker;
        }

        public void OnTimeSet(TimePicker view, int hourOfDay, int minute)
        {
            DateTime currentDate = DateTime.Now;
            DateTime dt = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour, currentDate.Minute, second: 0);
            OnTimeChangeHandler?.Invoke(this, dt);
        }
    
    }
}