﻿using StrategyAndChainOfResponsibilityPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyAndChainOfResponsibilityPattern.Rules
{
    public class CheckTokenExpireRule : Rule, IRule
    {
        public CheckTokenExpireRule()
        {
            NextRule = new CheckRefreshToken();
        }
        public Platform Platform { get; set; }

        public bool Run(RequestModel model)
        {
            switch (Platform)
            {
                case Platform.Gsm:
                    {
                        NextRule.Platform = Platform.Gsm;
                        if (model.TokenExpireDate < DummyData.TokenExpireDate.AddHours(2))
                        {
                            return true;
                        }
                        return false;
                    }
                case Platform.Web:
                    {
                        NextRule.Platform = Platform.Web;
                        if (model.TokenExpireDate < DummyData.TokenExpireDate)
                        {
                            return true;
                        }
                        return false;
                    }
                default:
                    {
                        return false;

                    }
            }
        }
    }
}
