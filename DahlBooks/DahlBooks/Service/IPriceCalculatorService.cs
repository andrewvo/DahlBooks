namespace DahlBooks.Service
{
    public interface IPriceCalculatorService
    {
        decimal GetPrice(int[] books);
    }
}