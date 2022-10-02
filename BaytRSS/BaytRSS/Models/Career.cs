using BaytRSS.Helper;
using System;
using System.Collections.Generic;
using System.Xml;

namespace BaytRSS.Models
{
    public class Career
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Guid { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Profile { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime PostedDate { get; set; }
        public string Division { get; set; }
        public static List<Career> RetrieveAllCareers(string baseAddress, string endPoint)
        {
            var payload = HttpClientHelper.HttpGet(baseAddress, endPoint);
            var careers = RetrieveItemsFromRss(payload);
            return careers;
        }
        private static List<Career> RetrieveItemsFromRss(string xml)
        {
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            var list = document.GetElementsByTagName("item");

            var careers = GetItems(list);
            return careers;
        }
        private static List<Career> GetItems(XmlNodeList node)
        {
            List<Career> careers = new List<Career>();
            foreach (XmlNode item in node)
            {
                Career career = new Career
                {
                    Id = System.Guid.NewGuid(),
                    Title = item?.SelectSingleNode("title")?.InnerText,
                    Link = item?.SelectSingleNode("link")?.InnerText,
                    Guid = item?.SelectSingleNode("guid")?.InnerText,
                    Description = item?.SelectSingleNode("description")?.InnerText,
                    Category = item?.SelectSingleNode("category")?.InnerText,
                    City = item?.SelectSingleNode("city")?.InnerText,
                    Profile = item?.SelectSingleNode("profile")?.InnerText,
                    Country = item?.SelectSingleNode("country")?.InnerText,
                    PostedDate = DateTime.Parse(item?.SelectSingleNode("posted_date")?.InnerText),
                    Division = item?.SelectSingleNode("division")?.InnerText
                };
                careers.Add(career);
            }

            return careers;
        }
    }
}