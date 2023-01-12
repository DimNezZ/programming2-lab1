namespace Buyer
{

    public class Customer
    {
        /// <summary>
        /// ФИО покупателя
        /// </summary>
        private readonly string Name;

        /// <summary>
        /// Домашний адрес
        /// </summary>
        private readonly string HomeAddress;

        /// <summary>
        /// Номер карты лояльности
        /// </summary>
        private int LoyaltyCardNumber;

        /// <summary>
        /// Процент скидки
        /// </summary>
        private double DiscountPercentage;

        /// <summary>
        /// Итоговая сумма покупока
        /// </summary>
        private readonly double TotalCost;

        public Customer(string name, string homeAddress, int loyaltyCardNumber, double discountPercentage, double totalCost)
        {
            Name = name;
            HomeAddress = homeAddress;
            LoyaltyCardNumber = loyaltyCardNumber;
            DiscountPercentage = HasLoyaltyCard() ? discountPercentage : 0;
            TotalCost = totalCost;
        }

        /// <summary>
        /// Есть ли у покупателя карта лояльности
        /// </summary>
        /// <returns></returns>
        public bool HasLoyaltyCard()
        {
            return LoyaltyCardNumber != -1;
        }

        /// <summary>
        /// Выдать карту лояльности покупателю
        /// </summary>
        /// <param name="loyaltyCardNumber">Номер карты лояльности</param>
        public void GiveLoyaltyCard(int loyaltyCardNumber)
        {
            if (!HasLoyaltyCard())
            {
                LoyaltyCardNumber = loyaltyCardNumber;
            }
        }

        /// <summary>
        /// Изменить процент скидки покупателя
        /// </summary>
        /// <param name="discountPercentage">Процент скидки</param>
        public void ChangeDiscountPercent(double discountPercentage)
        {
            if (HasLoyaltyCard())
            {
                DiscountPercentage = discountPercentage;
            }
        }

        /// <summary>
        /// Получить стоимость покупок с учетом скидки
        /// </summary>
        /// <returns></returns>
        public double CalculateTotalCost()
        {
            return Math.Round(TotalCost - TotalCost * DiscountPercentage / 100, 2);
        }

        /// <summary>
        /// Получить информацию о покупателе
        /// </summary>
        /// <returns></returns>
        public string GetInformation()
        {
            List<string> result = new List<string>()
            {
                $"Покупатель: {Name}",
                $"Адрес проживания: {HomeAddress}",
                HasLoyaltyCard() ? $"Номер карты лояльности покупателя: {LoyaltyCardNumber}" : "Нет карты лояльности покупателя",
                $"Процент скидки: {DiscountPercentage}%",
                $"Итоговая сумма (без скидки): {TotalCost}",
                $"Итоговая сумма (со скидкой): {CalculateTotalCost()}",
            };

            return String.Join("\n", result);
        }
    }

}