﻿using Glimpse.Core.Extensibility;
using Glimpse.Core.Message;
using System.Collections.Generic;
using System.Reflection;
using System.Web.WebPages;

namespace NavigationGlimpse
{
    public class StateRouteHandler : AlternateType<Navigation.StateRouteHandler>
    {
        private IEnumerable<IAlternateMethod> allMethods;

        public StateRouteHandler(IProxyFactory proxyFactory)
            : base(proxyFactory)
        {
        }

        public override IEnumerable<IAlternateMethod> AllMethods
        {
            get
            {
                return allMethods ?? (allMethods = new List<IAlternateMethod>
                    {
                        new GetDisplayInfoForPage(),
                        new GetPageForDisplayInfo(),
                        new GetDisplayInfoForMaster(),
                        new GetMasterForDisplayInfo(),
                        new GetDisplayInfoForTheme(),
                        new GetThemeForDisplayInfo()
                    });
            }
        }

        public class GetDisplayInfoForPage : AlternateMethod
        {
            public GetDisplayInfoForPage()
                : base(typeof(Navigation.StateRouteHandler), "GetDisplayInfoForPage", BindingFlags.NonPublic | BindingFlags.Instance)
            {
            }

            public override void PostImplementation(IAlternateMethodContext context, TimerResult timerResult)
            {
                var displayInfo = context.ReturnValue as DisplayInfo;
                var message = new Message(displayInfo.DisplayMode.DisplayModeId, displayInfo.FilePath);
                context.MessageBroker.Publish(message);
            }

            public class Message : MessageBase
            {
                public Message(string displayMode, string page)
                {
                    DisplayMode = displayMode;
                    Page = page;
                }

                public string DisplayMode { get; set; }

                public string Page { get; set; }
            }
        }

        public class GetPageForDisplayInfo : AlternateMethod
        {
            public GetPageForDisplayInfo()
                : base(typeof(Navigation.StateRouteHandler), "GetPageForDisplayInfo", BindingFlags.NonPublic | BindingFlags.Instance)
            {
            }

            public override void PostImplementation(IAlternateMethodContext context, TimerResult timerResult)
            {
            }
        }

        public class GetDisplayInfoForMaster : AlternateMethod
        {
            public GetDisplayInfoForMaster()
                : base(typeof(Navigation.StateRouteHandler), "GetDisplayInfoForMaster", BindingFlags.NonPublic | BindingFlags.Instance)
            {
            }

            public override void PostImplementation(IAlternateMethodContext context, TimerResult timerResult)
            {
            }
        }

        public class GetMasterForDisplayInfo : AlternateMethod
        {
            public GetMasterForDisplayInfo()
                : base(typeof(Navigation.StateRouteHandler), "GetMasterForDisplayInfo", BindingFlags.NonPublic | BindingFlags.Instance)
            {
            }

            public override void PostImplementation(IAlternateMethodContext context, TimerResult timerResult)
            {
            }
        }

        public class GetDisplayInfoForTheme : AlternateMethod
        {
            public GetDisplayInfoForTheme()
                : base(typeof(Navigation.StateRouteHandler), "GetDisplayInfoForTheme", BindingFlags.NonPublic | BindingFlags.Instance)
            {
            }

            public override void PostImplementation(IAlternateMethodContext context, TimerResult timerResult)
            {
            }
        }

        public class GetThemeForDisplayInfo : AlternateMethod
        {
            public GetThemeForDisplayInfo()
                : base(typeof(Navigation.StateRouteHandler), "GetThemeForDisplayInfo", BindingFlags.NonPublic | BindingFlags.Instance)
            {
            }

            public override void PostImplementation(IAlternateMethodContext context, TimerResult timerResult)
            {
            }
        }
    }
}