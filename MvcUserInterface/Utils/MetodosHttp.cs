using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace MvcUserInterface.Utils
{
    public class MetodosHttp <T>
    {
        #region Metodos para los llamados al rest api

        //Metodo generico para los llamados HttpGet al rest api
        public T metodoGet(string endpoint)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["ServidorRestApi"] + endpoint);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
                        return result;
                    }
                }
                else
                {
                    return default;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo generico para los llamados HttpPost al rest api
        public T metodoPost(string url, T modelo)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://localhost:44305/apitarea/" + url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";               

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(modelo);

                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
                        return result;
                    }
                }
                else
                {
                    return default;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

        #endregion
    }
}