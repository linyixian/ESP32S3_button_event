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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private static void ButtonPin_ValueChanged(object sender, PinValueChangedEventArgs e)
        {
            Debug.WriteLine(buttonPin.Read().ToString());
            if (e.ChangeType == PinEventTypes.Rising)   //PinÇÃìdà≥Ç™í·Ç¢èÛë‘Ç©ÇÁçÇÇ¢èÛë‘Ç…ïœâªÇµÇΩéû
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
