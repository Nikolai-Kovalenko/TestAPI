using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

using OwinInterface = System.Func<System.Collections.Generic.IDictionary<string, object>, System.Threading.Tasks.Task>;

namespace OWIN_WebAPI
{
    public class LoggerModule
    {
        private readonly Func<IDictionary<string, object>, Task> _next;

        private readonly string _prefix;

        public LoggerModule(OwinInterface next, string prefix)
        {
            if(next == null)
            {
                throw new ArgumentNullException("next");
            }

            if (string.IsNullOrEmpty(prefix))
            {
                throw new ArgumentNullException("prefix can`t be null or empty");
            }

            this._next = next;
            this._prefix = prefix;
        }

        public Task Invoke(IDictionary<string, object> env) 
        {
            try
            {
                Debug.WriteLine($"{this._prefix} Request: {env["owin.RequestPath"]}");
            }
            catch(Exception ex)
            {
                var tcs = new TaskCompletionSource<object>();
                tcs.SetException(ex);
                return tcs.Task;
            }
             
            return this._next(env);
        }
    }

    
}