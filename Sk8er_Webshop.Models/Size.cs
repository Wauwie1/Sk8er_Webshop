namespace Sk8er_Webshop.Models
{
    public class Size
    {
        public EnumSizes SizeType { get; set; }
        public int Amount { get; set; }

        public Size(EnumSizes sizeType, int amount)
        {
            this.SizeType = sizeType;
            this.Amount = amount;
        }
    }
}