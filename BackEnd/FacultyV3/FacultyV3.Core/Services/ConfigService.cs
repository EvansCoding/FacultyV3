namespace FacultyV3.Core.Services
{
    using System.Collections.Generic;
    using System.Xml;
    using SiteConfig;
    using Models.Enums;
    using Interfaces.IServices;

    public partial class ConfigService : IConfigService
    {
        private readonly ICacheService _cacheService;

        public ConfigService(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        #region Settings

        public Dictionary<string, string> GetConfig()
        {
            const string key = "SiteConfig";
            var siteConfig = _cacheService.Get<Dictionary<string, string>>(key);
            if (siteConfig == null)
            {
                siteConfig = new Dictionary<string, string>();
                var root = SiteConfig.Instance.GetSiteConfig();
                var nodes = root?.SelectNodes("/faculty/settings/setting");
                if (nodes != null)
                {
                    foreach (XmlNode node in nodes)
                    {
                        //<emoticon symbol="O:)" image="angel-emoticon.png" />  
                        if (node.Attributes != null)
                        {
                            var keyAttr = node.Attributes["key"];
                            var valueAttr = node.Attributes["value"];
                            if (keyAttr != null && valueAttr != null)
                            {
                                siteConfig.Add(keyAttr.InnerText, valueAttr.InnerText);
                            }
                        }
                    }

                    _cacheService.Set(key, siteConfig, CacheTimes.OneDay);
                }

            }
            return siteConfig;
        }

        #endregion
    }

}
