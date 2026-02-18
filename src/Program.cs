using DesignPatternChallenge.Models;
using DesignPatternChallenge.Processors;

Console.WriteLine("=== Order Processing System (Template Method Pattern) ===");

var items = new List<string> { "Notebook", "Mouse", "Keyboard" };

// 1. Online Order
var onlineOrder = new Order("CUST001", items, 2500.00m);
OrderProcessor onlineProcessor = new OnlineOrderProcessor();
onlineProcessor.ProcessOrder(onlineOrder);

// 2. Wholesale Order
var wholesaleOrder = new Order("COMP001", items, 5000.00m);
OrderProcessor wholesaleProcessor = new WholesaleOrderProcessor();
wholesaleProcessor.ProcessOrder(wholesaleOrder);

// 3. Marketplace Order
var marketplaceOrder = new Order("SELL001", items, 3000.00m);
OrderProcessor marketplaceProcessor = new MarketplaceOrderProcessor();
marketplaceProcessor.ProcessOrder(marketplaceOrder);

Console.WriteLine("\n=== Solutions Provided by Template Method ===");
Console.WriteLine("✓ Algorithm structure defined in ONE place (OrderProcessor.ProcessOrder)");
Console.WriteLine("✓ Subclasses customize steps via abstract/virtual methods");
Console.WriteLine("✓ Sequence of execution is GUARANTEED by the template method");
Console.WriteLine("✓ Common steps (VerifyStock, PrepareItems) are REUSED and not duplicated");
Console.WriteLine("✓ Clean code: easier to maintain and extend with new channels");

/*
 * REFLECTION QUESTIONS:
 * 
 * - How to define the structure of the algorithm in only one place?
 *   ANSWER: Use a Template Method in an abstract base class. This method contains 
 *   the workflow (skeleton) and calls other methods (steps) in a specific order.
 * 
 * - How to allow subclasses to customize specific steps?
 *   ANSWER: The Template Method calls abstract or virtual methods. Subclasses 
 *   override these primitive operations to provide their own specific logic.
 * 
 * - How to ensure that the sequence is always respected?
 *   ANSWER: By making the Template Method itself final (non-virtual in C# or 
 *   just not intended for override), the structure is locked in the base class.
 * 
 * - How to reuse common steps between implementations?
 *   ANSWER: Implement these steps directly in the base class. Subclasses 
 *   inherit this logic for free and don't need to duplicate it.
 */
