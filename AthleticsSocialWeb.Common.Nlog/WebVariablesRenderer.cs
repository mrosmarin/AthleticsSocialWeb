using System.Globalization;
using System.Text;
using System.Web;
using System.Xml;
using NLog;
using NLog.Config;
using NLog.LayoutRenderers;

namespace AthleticsSocialWeb.Common.Nlog
{
    [LayoutRenderer("web_variables")]
    public class WebVariablesRenderer : LayoutRenderer
    {

        ///
        /// Initializes a new instance of the  class.
        ///
        public WebVariablesRenderer()
        {
            Format = "";
            Culture = CultureInfo.InvariantCulture;
        }

        //protected override int GetEstimatedBufferSize(LogEventInfo ev)
        //{
        //    // This will be XML of an unknown size
        //    return 10000;
        //}

        ///
        /// Gets or sets the culture used for rendering.
        ///
        ///
        public CultureInfo Culture { get; set; }

        ///
        /// Gets or sets the date format. Can be any argument accepted by DateTime.ToString(format).
        ///
        ///
        [DefaultParameter]
        public string Format { get; set; }

        ///<summary>
        /// Renders the current date and appends it to the specified .
        ///</summary>
        /// <param name="builder">The  to append the rendered data to.</param>
        /// <param name="logEvent">Logging event.</param>
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            var sb = new StringBuilder();
            var writer = XmlWriter.Create(sb);

            writer.WriteStartElement("error");

            // -----------------------------------------
            // Server Variables
            // -----------------------------------------
            writer.WriteStartElement("serverVariables");

            foreach (string key in HttpContext.Current.Request.ServerVariables.AllKeys)
            {
                writer.WriteStartElement("item");
                writer.WriteAttributeString("name", key);

                writer.WriteStartElement("value");
                writer.WriteAttributeString("string", HttpContext.Current.Request.ServerVariables[key]);
                writer.WriteEndElement();

                writer.WriteEndElement();
            }

            writer.WriteEndElement();

            // -----------------------------------------
            // Cookies
            // -----------------------------------------
            writer.WriteStartElement("cookies");

            foreach (string key in HttpContext.Current.Request.Cookies.AllKeys)
            {
                writer.WriteStartElement("item");
                writer.WriteAttributeString("name", key);

                writer.WriteStartElement("value");
                var httpCookie = HttpContext.Current.Request.Cookies[key];
                if (httpCookie != null)
                    writer.WriteAttributeString("string", httpCookie.Value);
                writer.WriteEndElement();

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            // -----------------------------------------

            writer.WriteEndElement();
            // -----------------------------------------

            writer.Flush();
            writer.Close();

            var xml = sb.ToString();

            builder.Append(xml);
        }

    }
}