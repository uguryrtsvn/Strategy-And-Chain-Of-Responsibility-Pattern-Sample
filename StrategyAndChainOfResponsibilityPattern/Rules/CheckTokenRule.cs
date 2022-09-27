using StrategyAndChainOfResponsibilityPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyAndChainOfResponsibilityPattern.Rules
{
    public class CheckTokenRule : Rule, IRule
    {
        public CheckTokenRule()
        {
            NextRule = new CheckTokenExpireRule();
        }

        public Platform Platform { get; set; }

        public bool Run(RequestModel model)
        {
            switch (Platform)
            {
                case Platform.Gsm:
                    {
                        NextRule.Platform = Platform.Gsm;
                        return model.UserID == DummyData.UserID && 
                            (model.Token == DummyData.Token || model.RefreshToken == DummyData.RefreshToken);
                    }
                case Platform.Web:
                    {
                        NextRule.Platform = Platform.Web;
                        return model.UserID==DummyData.UserID && model.Token == DummyData.Token;
                    }
                default:
                    {
                        return false;
                    }
            }
        }
    }
}
