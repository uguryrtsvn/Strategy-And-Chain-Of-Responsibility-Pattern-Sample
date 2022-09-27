using StrategyAndChainOfResponsibilityPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyAndChainOfResponsibilityPattern.Rules
{
    public class CheckPlatformRule : Rule, IRule
    {
        public CheckPlatformRule()
        {
            NextRule = new CheckTokenRule();
        }
        public Platform Platform { get; set; }
        public bool Run(RequestModel model)
        { 
            if (string.IsNullOrWhiteSpace(model.IMEI))
            {
                NextRule.Platform = Platform.Web;
                return model.Token != String.Empty && model.Token != null;
            }
            else if (!string.IsNullOrWhiteSpace(model.IMEI))
            {
                NextRule.Platform = Platform.Gsm;
                return (model.Token != String.Empty && model.Token != null) || (model.RefreshToken != String.Empty && model.RefreshToken != null);
            }
            return false;
        }
    }
}
