using System;
using System.Diagnostics;
using System.Threading;

using System.Device.Gpio;

namespace ESP32S3_button_event
{
    public class Program
    {
        private static GpioPin ledPin;
        private static GpioPin buttonPin;

        public static void Main()
        {
            GpioController controller = new GpioController();

            ledPin = controller.OpenPin(2, PinMode.Output);
            ledPin.Write(PinValue.Low);

            buttonPin = controller.OpenPin(35, PinMode.InputPullDown);

            buttonPin.ValueChanged += ButtonPin_ValueChanged;

            Thread.Sleep(Timeout.Infinite);
        }

        private static void ButtonPin_ValueChanged(object sender, PinValueChangedEventArgs e)
        {
            Debug.WriteLine(buttonPin.Read().ToString());
            if (e.ChangeType == PinEventTypes.Rising)   //Pinの電圧が低い状態から高い状態に変化した時
            {
                ledPin.Write(PinValue.High);
            }
            else
            {
                ledPin.Write(PinValue.Low); 
            }
        }
    }
}
