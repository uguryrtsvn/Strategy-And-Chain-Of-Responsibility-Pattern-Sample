
using StrategyAndChainOfResponsibilityPattern;
using StrategyAndChainOfResponsibilityPattern.Models;
using StrategyAndChainOfResponsibilityPattern.Rules;



RequestModel model = new();
model.IMEI = "111222333444555";
model.RefreshToken = "98349785389732";
//model.Token = "234234223423";
model.UserID = 1;
model.TokenExpireDate = DateTime.Now.AddHours(3);

IRule firstRule = new CheckPlatformRule();
while (firstRule.NextRule != null)
{
    if (firstRule.Run(model))
    {
        firstRule = firstRule.NextRule;
    }
    else
    {
        Console.WriteLine("Unauthorized 401!");
        break;
    }
}
//Working Tail Rule Process
if (firstRule.NextRule == null)
{
    if (firstRule.Run(model))
    {
        Console.WriteLine("Authorized 200 OK!");
    }
    else
    {
        Console.WriteLine("Unauthorized 401!");
    }
}

Console.WriteLine($"Token: {DummyData.Token}");
Console.WriteLine($"RefreshToken: {DummyData.RefreshToken}");
Console.WriteLine($"Token Expire Date: ${DummyData.TokenExpireDate}");
Console.WriteLine("Hello, World!");
