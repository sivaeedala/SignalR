using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Console_SelfHost.Panini
{

    public class PaniniAPI
    {
        IntPtr hwnd;

        public PaniniAPI()
        {
            HiddenWin hiddenWin = new HiddenWin();
            hwnd = hiddenWin.Handle;
        }

        [DllImport("libVisionApi.dylib")]
        private static extern int VApiSetDeviceEngine(int deviceId);

        [DllImport("libVisionApi.dylib")]
        private static extern int StartUp(IntPtr handle, int sorterMessage);

        public int SetDeviceEngine(int deviceType)
        {
            return VApiSetDeviceEngine(deviceType);
        }

        int deviceId;
        public const int WM_SORTER_API = 32778;


        public int StartUp()
        {
            deviceId = StartUp(hwnd, WM_SORTER_API);
            return deviceId;
        }

        [DllImport("libVisionApi.dylib")]
        public static extern bool GetApiError(ref int errorCode);

        public const int API_ERR_DEVICE = 14;
        public const int DEVICE_ERR_USB = 2;

        [DllImport("libVisionApi.dylib")]
        private static extern bool GetDeviceError(int deviceId, ref int result);

        [DllImport("libVisionApi.dylib")]
        private static extern bool GetUsbError(int deviceId, ref int errorCode);

        [DllImport("libVisionApi.dylib")]
        public static extern bool GetUsbErrorString(int deviceId, StringBuilder errorString, int maxLength);

        [DllImport("libVisionApi.dylib")]
        public static extern bool GetDeviceErrorString(int deviceId, StringBuilder errorString, int maxLength);

        [DllImport("libVisionApi.dylib")]
        private static extern bool GetApiErrorString(StringBuilder errorString, int maxLength);

        [DllImport("libVisionApi.dylib")]
        public static extern bool GetSerialNumber(int deviceId, StringBuilder serialNumber, int maxLength);

        [DllImport("libVisionApi.dylib")]
        public static extern bool GetDriverRelease(StringBuilder driverRelease, int maxLength);


        [DllImport("libVisionApi.dylib")]
        public static extern bool GetApiRelease(StringBuilder apiRelease, int maxLength);

        [DllImport("libVisionApi.dylib")]
        public static extern bool GetFwVersion(int deviceId, StringBuilder fwVersion, int maxLength);


        public string GetError(ref int errorType, ref int errorCode)
        {
            errorCode = -1;
            errorType = 9;

            StringBuilder errorText = new StringBuilder(256);
            GetApiError(ref errorCode);

            if (errorCode == API_ERR_DEVICE)
            {
                GetDeviceError(deviceId, ref errorCode);
                if (errorCode == DEVICE_ERR_USB)
                {
                    errorType = 8;
                    GetUsbError(deviceId, ref errorCode);
                    GetUsbErrorString(deviceId, errorText, 109);
                }
                else
                {
                    errorType = 11;
                    GetDeviceErrorString(deviceId, errorText, 256);
                }

            }
            else if (errorCode == 14)
            {
                errorType = 8;
                GetUsbError(deviceId, ref errorCode);
                GetUsbErrorString(deviceId, errorText, 109);
            }
            else
            {
                GetApiErrorString(errorText, 256);
            }

            return errorText.ToString();
        }



    }
}
