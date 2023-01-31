using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
//using RestSharp;
using Novasoft.Logger;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;

namespace RestClientLib
{
    public partial class RESTClient : IDisposable
    {
        //private Logger _Logger;

        static HttpClient httpClient = null;

        public RESTClient(string eqpType = "BASE", string unitID = "NULL")
        {
            httpClient = new HttpClient();

            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            enRestEqpType restEqpType = (enRestEqpType)Enum.Parse(typeof(enRestEqpType), eqpType);
            enRestUnitID restUnitID = (enRestUnitID)Enum.Parse(typeof(enRestUnitID), unitID);

            string baseAddress = GetRestServerURI(restEqpType, restUnitID);
            httpClient.BaseAddress = new Uri(baseAddress);

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            //_Logger = new Logger(CRestModulePath.LOG_PATH, LogMode.Hour);
        }
        public async Task<string> GetJson(enActionType actionID, object RequestBody)
        {
            try
            {
                string RequestUri = CRestModulePath.POST_SQL;

                JObject reqBody = new JObject();
                reqBody["ACTION_ID"] = actionID.ToString();
                reqBody["REQUEST_TIME"] = DateTime.Now.ToString();
                reqBody["QUERY"] = RequestBody.ToString();

                HttpResponseMessage response = httpClient.PostAsJsonAsync(RequestUri, reqBody).Result;

                var responseString = await response.Content.ReadAsStringAsync();

                return responseString;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### GetJson, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                return null;
            }
        }

        public async Task<string> SetJson(string RequestUri, object RequestBody)
        {
            try
            {
                HttpResponseMessage response = httpClient.PostAsJsonAsync(RequestUri, RequestBody).Result;

                var responseString = await response.Content.ReadAsStringAsync();

                return responseString;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### SetJsonManualCommnad, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                return null;
            }
        }

        private string GetRestServerURI(enRestEqpType serverType, enRestUnitID unitID)
        {
            string baseAddress = @"https://210.91.148.176";
            //string baseAddress = @"http://localhost:30001/";

            string ecsAddress = @"https://210.91.148.176";

            string address;

            switch (serverType)
            {
                case enRestEqpType.BASE:
                    address = $"{baseAddress}:{(int)serverType}/";
                    break;
                case enRestEqpType.HPC:
                case enRestEqpType.CHG:
                    address = $"{ecsAddress}:{(int)unitID}/";
                    break;
                default:
                    address = $"{ecsAddress}:{(int)serverType}/";
                    break;
            }

            return address;
        }

        /// <summary>
        /// Json data를 가져온다.
        /// </summary>
        //public string GetJson(enActionType actionID, string queryBody)
        //{
        //    try
        //    {
        //        string dateTime = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}";

        //        var request = new RestRequest();
        //        request.Resource = CRestModulePath.POST_SQL;

        //        JObject reqBody = new JObject();
        //        reqBody["ACTION_ID"] = actionID.ToString();
        //        reqBody["REQUEST_TIME"] = dateTime;
        //        reqBody["QUERY"] = queryBody;
        //        request.AddJsonBody(reqBody.ToString());

        //        var response = _RESTClient.Post(request);

        //        if ((response != null) &&
        //            (response.StatusCode == System.Net.HttpStatusCode.OK) &&
        //            (response.ResponseStatus == ResponseStatus.Completed))
        //        {
        //            string msg = $"Send a message to ECS.\n{reqBody}";
        //            _Logger.Write(LogLevel.REST, msg, LogFileName.REST);
        //            return response.Content;
        //        }

        //        _Logger.Write(LogLevel.Error, response.ErrorMessage, LogFileName.ErrorLog);
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
        //        return null;
        //    }
        //}

        //public async Task<string> GetJsonAsync(enActionType actionID, string queryBody)
        //{
        //    try
        //    {
        //        string dateTime = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}";

        //        var request = new RestRequest();
        //        request.Resource = CRestModulePath.POST_SQL;

        //        JObject reqBody = new JObject();
        //        reqBody["ACTION_ID"] = actionID.ToString();
        //        reqBody["REQUEST_TIME"] = dateTime;
        //        reqBody["QUERY"] = queryBody;
        //        request.AddJsonBody(reqBody.ToString());

        //        var response = await _RESTClient.PostAsync(request);

        //        if ((response != null) &&
        //            (response.StatusCode == System.Net.HttpStatusCode.OK) &&
        //            (response.ResponseStatus == ResponseStatus.Completed))
        //        {
        //            string msg = $"Send a message to ECS.\n{reqBody}";
        //            _Logger.Write(LogLevel.REST, msg, LogFileName.REST);
        //            return response.Content;
        //        }

        //        _Logger.Write(LogLevel.Error, response.ErrorMessage, LogFileName.ErrorLog);
        //        return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
        //        return null;
        //    }            
        //}


        #region [IDisposable Impl.]
        // Track whether Dispose has been called.
        private bool disposed = false;

        // Implement IDisposable.
        // Do not make this method virtual.
        // A derived class should not be able to override this method.
        public void Dispose()
        {
            Dispose(disposing: true);
            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SuppressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        // Dispose(bool disposing) executes in two distinct scenarios.
        // If disposing equals true, the method has been called directly
        // or indirectly by a user's code. Managed and unmanaged resources
        // can be disposed.
        // If disposing equals false, the method has been called by the
        // runtime from inside the finalizer and you should not reference
        // other objects. Only unmanaged resources can be disposed.
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    //if (_session != null)
                    //{
                    //    _session.Disconnect(SubscriptionCleanupPolicy.Delete, null);
                    //    _session.Dispose();
                    //    _session = null;
                    //}
                }

                // Call the appropriate methods to clean up
                // unmanaged resources here.
                // If disposing is false,
                // only the following code is executed.
                //CloseHandle(handle);
                //handle = IntPtr.Zero; // such as file handle, memory handle or other UN-MANAGED HANDLES!

                // Note disposing has been done.
                disposed = true;
            }
        }

        // Use interop to call the method necessary
        // to clean up the unmanaged resource.
        //[System.Runtime.InteropServices.DllImport("Kernel32")]
        //private extern static Boolean CloseHandle(IntPtr handle);

        // Use C# finalizer syntax for finalization code.
        // This finalizer will run only if the Dispose method
        // does not get called.
        // It gives your base class the opportunity to finalize.
        // Do not provide finalizer in types derived from this class.
        ~RESTClient()
        {

            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(disposing: false) is optimal in terms of
            // readability and maintainability.
            Dispose(disposing: false);
        }
#endregion
    }


}
