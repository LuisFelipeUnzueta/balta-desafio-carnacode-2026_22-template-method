using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Processors;

/// <summary>
/// The Template Method defines the skeleton of an algorithm in the base class 
/// but lets subclasses override specific steps of the algorithm without 
/// changing its structure.
/// </summary>
public abstract class OrderProcessor
{
    protected abstract string ChannelName { get; }

    // This is the Template Method. It defines the fixed structure of the algorithm.
    public void ProcessOrder(Order order)
    {
        Console.WriteLine($"\n=== Processing {ChannelName} Order ===");

        if (!ValidateOrder(order))
        {
            return;
        }

        VerifyStock(order);
        var calculations = CalculateAmounts(order);
        ProcessPayment(order, calculations);
        PrepareItems(order);
        ScheduleDelivery(order);
        Notify(order);

        OnOrderProcessed(order);

        Console.WriteLine($"\n✅ {ChannelName} order processed successfully!");
    }

    // Default implementation, can be overridden if needed.
    protected virtual bool ValidateOrder(Order order)
    {
        Console.WriteLine($"[{ChannelName}] Validating order...");
        if (string.IsNullOrEmpty(order.CustomerId))
        {
            Console.WriteLine("❌ Invalid customer");
            return false;
        }
        Console.WriteLine("✓ Order validated");
        return true;
    }

    // Common implementation for all channels.
    protected void VerifyStock(Order order)
    {
        Console.WriteLine($"[{ChannelName}] Verifying stock...");
        foreach (var item in order.Items)
        {
            Console.WriteLine($"  → {item}: Available");
        }
        Console.WriteLine("✓ Stock confirmed");
    }

    // Abstract methods to be implemented by subclasses.
    protected abstract OrderCalculations CalculateAmounts(Order order);
    protected abstract void ProcessPayment(Order order, OrderCalculations calculations);
    protected abstract void ScheduleDelivery(Order order);
    protected abstract void Notify(Order order);

    // Common implementation for all channels.
    protected void PrepareItems(Order order)
    {
        Console.WriteLine($"[{ChannelName}] Separating items in stock...");
        Console.WriteLine("✓ Items separated");
    }

    // Hook: Subclasses can override this but it's optional.
    protected virtual void OnOrderProcessed(Order order) { }
}

public record OrderCalculations(decimal Subtotal, decimal ExtraAmount, decimal Total, string ExtraDescription);
