public class Fraction
{
    private int _top;
    private int _bottom;

    Fraction()
    {
    }
    Fraction(int wholeNumber)
    {

    }
    Fraction(int top, int bottom)
    {
        this._top = top;
        this._bottom  = bottom;
    }

    public void GetTop()
    {
        Console.WriteLine($"{this._top}");
    }

    public void SetTop (int top)
    {
        this._top = top;
    }

    public void GetBottom(){
        Console.WriteLine($"{_bottom}");
    }

    public void SetBottom(int bottom)
    {
        this._bottom = bottom;
    }

    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    public double GetDecimalValue()
    {
        return _top/_bottom;
    }
}