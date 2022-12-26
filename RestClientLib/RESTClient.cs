﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using Novasoft.Logger;

namespace RestClientLib
{
    public partial class RESTClient : IDisposable
    {
        private Logger _Logger;
        RestClient _RESTClient = null;

        public RESTClient()
        {
            _RESTClient = new RestClient(CRestModulePath.BaseUrl);

            _Logger = new Logger(CRestModulePath.LOG_PATH, LogMode.Hour);
        }

        /// <summary>
        /// Json data를 가져온다.
        /// </summary>
        public string GetJson(enActionType actionID, string queryBody)
        {
            try
            {
                string dateTime = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}";

                var request = new RestRequest();
                request.Resource = CRestModulePath.POST_SQL;

                JObject reqBody = new JObject();
                reqBody["ACTION_ID"] = actionID.ToString();
                reqBody["REQUEST_TIME"] = dateTime;
                reqBody["QUERY"] = queryBody;
                request.AddJsonBody(reqBody.ToString());

                var response = _RESTClient.Post(request);

                if ((response != null) &&
                    (response.StatusCode == System.Net.HttpStatusCode.OK) &&
                    (response.ResponseStatus == ResponseStatus.Completed))
                {
                    string msg = $"Send a message to ECS.\n{reqBody}";
                    _Logger.Write(LogLevel.REST, msg, LogFileName.REST);
                    return response.Content;
                }

                _Logger.Write(LogLevel.Error, response.ErrorMessage, LogFileName.ErrorLog);
                return null;
            }
            catch (Exception ex)
            {
                _Logger.Write(LogLevel.Error, ex.Message, LogFileName.ErrorLog);
                return null;
            }
        }

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