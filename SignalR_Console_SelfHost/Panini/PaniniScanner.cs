using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_Console_SelfHost.Panini
{
    public class PaniniScanner
    {

        PaniniAPI _PaniniAPI = null;
        public PaniniScanner()
        {
            _PaniniAPI = new PaniniAPI();
        }

        private bool _scannerOnline = false;
        public bool ScannerOnline { get { return _scannerOnline; } }

        private int _DeviceId;

        public bool InitializeScanner()
        {
            Console.WriteLine("PaniniScanner Intialize Scanner");

            try
            {
                int DEVICE_VISION = 0, DEVICEIDEAL = 2;
                DateTime startTime = DateTime.Now;

                int retCode = 0;
                retCode = _PaniniAPI.SetDeviceEngine(DEVICE_VISION);
                Console.WriteLine("SetDeviceEngine retcode:{0}", retCode);

                _DeviceId = _PaniniAPI.StartUp();
                Console.WriteLine("Api Startup DeviceId:{0}", _DeviceId);
                if (_DeviceId == 0)
                    GetError();
                GetScannerDetails();
                return true;

            }
            catch (DllNotFoundException ex)
            {
                Console.WriteLine("----------------------Error:");
                Console.WriteLine("Dll Not Found Exception:{0}", ex.ToString());
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("----------------------Error:");
                Console.WriteLine("Exception at IntializeScanner:{0}", ex.ToString());
                return false;
            }
        }

        public string GetError()
        {
            int errorType = 0;
            int errorCode = 0;
            string errorText = _PaniniAPI.GetError(ref errorType, ref errorCode);
            Console.WriteLine("Error:{0},ErrorType:{1},ErrorCode:{2}", errorText, errorType.ToString(), errorCode.ToString());

            return errorText;
        }

        public void GetScannerDetails()
        {      
            
            try
            {
                StringBuilder fwVersion = new StringBuilder(250);
                PaniniAPI.GetFwVersion(_DeviceId, fwVersion, fwVersion.Capacity);
                Console.WriteLine("FileVersion:{0}", fwVersion.ToString());

                StringBuilder serialNumber = new StringBuilder(15);
                PaniniAPI.GetSerialNumber(_DeviceId, serialNumber, serialNumber.Capacity);
                Console.WriteLine("serialNumber:{0}", serialNumber.ToString());

                StringBuilder driverReleaseVersion = new StringBuilder(250);
                PaniniAPI.GetDriverRelease(driverReleaseVersion, driverReleaseVersion.Capacity);
                Console.WriteLine("driverReleaseVersion:{0}", driverReleaseVersion.ToString());

                StringBuilder apiReleaseDesc = new StringBuilder(250);
                PaniniAPI.GetApiRelease(apiReleaseDesc, apiReleaseDesc.Capacity);
                Console.WriteLine("apiReleaseDesc:{0}", apiReleaseDesc.ToString());
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }




        }
    }
}
