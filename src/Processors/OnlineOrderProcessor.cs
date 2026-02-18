using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Processors;

public class OnlineOrderProcessor : OrderProcessor
{
    protected override string ChannelName => "Online";

    protected override OrderCalculations CalculateAmounts(Order order)
    {
        Console.WriteLine($"[{ChannelName}] Calculating values...");
        decimal shipping = 15.00m;
        decimal total = order.Amount + shipping;
        
        Console.WriteLine($"  → Subtotal: R$ {order.Amount:N2}");
        Console.WriteLine($"  → Shipping: R$ {shipping:N2}");
        Console.WriteLine($"  → Total: R$ {total:N2}");

        return new OrderCalculations(order.Amount, shipping, total, "Shipping");
    }

    protected override void ProcessPayment(Order order, OrderCalculations calculations)
    {
        Console.WriteLine($"[{ChannelName}] Processing credit card payment...");
        Console.WriteLine("✓ Payment approved");
    }

    protected override void ScheduleDelivery(Order order)
    {
        Console.WriteLine($"[{ChannelName}] Scheduling delivery via Post Office...");
        Console.WriteLine("✓ Delivery scheduled");
    }

    protected override void Notify(Order order)
    {
        Console.WriteLine($"[{ChannelName}] Sending confirmation email...");
        Console.WriteLine("✓ Email sent");
    }
}
