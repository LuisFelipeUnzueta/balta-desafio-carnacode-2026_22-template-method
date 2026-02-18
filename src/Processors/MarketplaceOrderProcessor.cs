using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Processors;

public class MarketplaceOrderProcessor : OrderProcessor
{
    protected override string ChannelName => "Marketplace";

    protected override bool ValidateOrder(Order order)
    {
        Console.WriteLine($"[{ChannelName}] Validating order...");
        if (string.IsNullOrEmpty(order.CustomerId))
        {
            Console.WriteLine("❌ Invalid seller");
            return false;
        }
        Console.WriteLine("✓ Order validated");
        return true;
    }

    protected override OrderCalculations CalculateAmounts(Order order)
    {
        Console.WriteLine($"[{ChannelName}] Calculating values...");
        decimal commission = order.Amount * 0.15m; // 15% commission
        decimal sellerAmount = order.Amount - commission;
        
        Console.WriteLine($"  → Total Value: R$ {order.Amount:N2}");
        Console.WriteLine($"  → Commission (15%): R$ {commission:N2}");
        Console.WriteLine($"  → Seller Transfer: R$ {sellerAmount:N2}");

        return new OrderCalculations(order.Amount, commission, sellerAmount, "Commission (15%)");
    }

    protected override void ProcessPayment(Order order, OrderCalculations calculations)
    {
        Console.WriteLine($"[{ChannelName}] Processing split payment...");
        Console.WriteLine($"  → R$ {calculations.ExtraAmount:N2} for marketplace");
        Console.WriteLine($"  → R$ {calculations.Total:N2} for seller");
        Console.WriteLine("✓ Payment split");
    }

    protected override void ScheduleDelivery(Order order)
    {
        Console.WriteLine($"[{ChannelName}] Scheduling delivery with seller's option...");
        Console.WriteLine("✓ Delivery scheduled");
    }

    protected override void Notify(Order order)
    {
        Console.WriteLine($"[{ChannelName}] Notifying parties...");
        Console.WriteLine("  → Customer notified");
        Console.WriteLine("  → Seller notified");
        Console.WriteLine("✓ Notifications sent");
    }
}
