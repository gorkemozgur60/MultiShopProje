namespace MultiShop.Discount.Dtos
{
    public class ResultCoupon
    {
        public int CouponId { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public int Rate { get; set; }
        public DateTime valiDate { get; set; }
    }
}
