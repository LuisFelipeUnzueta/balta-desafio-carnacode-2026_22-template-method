namespace DesignPatternChallenge.Models;

public record Order(
    string CustomerId,
    List<string> Items,
    decimal Amount);
