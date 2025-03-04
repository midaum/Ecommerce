using System;
using System.Text.RegularExpressions;

namespace Domain.ShoppingCart.CartItemData
{
    public record CartItemName
    {
        private static readonly Regex ValidNamePattern = new(@"^[a-zA-Z0-9\-_ ]+$", RegexOptions.Compiled);

        public string Value { get; }

        public CartItemName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Der Name des Artikels darf nicht leer sein.", nameof(value));
            }

            if (value.Length < 3 || value.Length > 100)
            {
                throw new ArgumentException("Der Name muss zwischen 3 und 100 Zeichen lang sein.", nameof(value));
            }

            if (!ValidNamePattern.IsMatch(value))
            {
                throw new ArgumentException("Der Name darf nur Buchstaben, Zahlen, Leerzeichen, Bindestriche oder Unterstriche enthalten.", nameof(value));
            }

            Value = value;
        }

        public override string ToString() => Value;
    }
}
