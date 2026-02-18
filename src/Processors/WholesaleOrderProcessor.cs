using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Processors;

public class WholesaleOrderProcessor : OrderProcessor
{
    protected override string ChannelName => "Wholesale";

    protected override bool ValidateOrder(Order order)
    {
        Console.WriteLine($"[{ChannelName}] Validating order...");
        if (string.IsNullOrEmpty(order.CustomerId))
        {
            Console.WriteLine("❌ Invalid company");
            return false;
        }

        if (order.Amount < 1000.00m)
        {
            Console.WriteLine("❌ Minimum order of R$ 1,000.00 for wholesale");
            return false;
        }

        Console.WriteLine("✓ Order validated");
        return true;
    }

    protected override OrderCalculations CalculateAmounts(Order order)
    {
        Console.WriteLine($"[{ChannelName}] Calculating values...");
        decimal discount = order.Amount * 0.10m; // 10% wholesale discount
        decimal total = order.Amount - discount;
        
        Console.WriteLine($"  → Subtotal: R$ {order.Amount:N2}");
        Console.WriteLine($"  → Discount (10%): -R$ {discount:N2}");
        Console.WriteLine($"  → Total: R$ {total:N2}");

        return new OrderCalculations(order.Amount, discount, total, "Discount (10%)");
    }

    protected override void ProcessPayment(Order order, OrderCalculations calculations)
    {
        Console.WriteLine($"[{ChannelName}] Generating bank slip...");
        Console.WriteLine("✓ Bank slip generated");
    }

    protected override void ScheduleDelivery(Order order)
    {
        Console.WriteLine($"[{ChannelName}] Scheduling pickup with carrier...");
        Console.WriteLine("✓ Pickup scheduled");
    }

    protected override void Notify(Order order)
    {
        Console.WriteLine($"[{ChannelName}] Notifying company...");
        Console.WriteLine("  → Email sent");
        Console.WriteLine("  → SMS sent");
        Console.WriteLine("✓ Notifications sent");
    }
}
