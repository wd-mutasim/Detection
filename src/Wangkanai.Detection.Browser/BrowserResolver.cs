// Copyright (c) 2018 Sarin Na Wangkanai, All Rights Reserved.
// The GNU GPLv3. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Http;
using System;
using Wangkanai.Detection.Collections;

namespace Wangkanai.Detection
{
    public class BrowserResolver : IBrowserResolver
    {
        public IBrowser Browser => _browser;
        public IUserAgent UserAgent => _service.UserAgent;

        private HttpContext _context => _service.Context;

        private readonly Browser _browser;
        private readonly IDetectionService _service;

        public BrowserResolver(IDetectionService service)
        {
            if (_service == null) throw new ArgumentNullException(nameof(service));

            _service = service;

            _browser = GetBrowser();
        }

        private Browser GetBrowser()
        {
            var agent = UserAgent.ToString();

            var firefox = new Firefox(agent);
            if (firefox.Type == BrowserType.Firefox)
                return firefox;
            var chrome = new Chrome(agent);
            if (chrome.Type == BrowserType.Chrome)
                return chrome;
            var safari = new Safari(agent);
            if (safari.Type == BrowserType.Safari)
                return safari;
            var ie = new InternetExplorer(agent);
            if (ie.Type == BrowserType.IE)
                return ie;
            var edge = new Edge(agent);
            if (edge.Type == BrowserType.Edge)
                return edge;
            var opera = new Opera(agent);
            if (opera.Type == BrowserType.Opera)
                return opera;

            return new Browser();
        }
    }
}