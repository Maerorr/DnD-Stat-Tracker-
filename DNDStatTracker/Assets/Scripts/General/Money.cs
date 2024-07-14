using System;
using System.Collections.Generic;

public class Money
{
    public Dictionary<string, int> money;

    public Money(int copper, int silver, int electrum, int gold, int platinum)
    {
        money = new Dictionary<string, int>
        {
            { "Copper", copper },
            { "Silver", silver },
            { "Electrum", electrum },
            { "Gold", gold },
            { "Platinum", platinum },
        };
    }

    public void AddMoney(Currency cur, int value)
    {
        money[cur.ToString()] += value;
    }
    
    public void SubtractMoney(Currency cur, int value)
    {
        if (money[cur.ToString()] < value)
        {
            money[cur.ToString()] = 0;
        }
        else
        {
            money[cur.ToString()] -= value;
        }
    }

    public void ConvertMoney(int amount, Currency from, Currency to)
    {
        int fromAmount = money[from.ToString()];
        if (fromAmount < amount)
        {
            return;
        }

        int? newAmount = from.ConvertTo(to, amount);
        if (newAmount is null) return;
        AddMoney(to, newAmount.Value);
        SubtractMoney(from, amount);
    }
}

public enum Currency 
{
    Copper,
    Silver,
    Electrum,
    Gold,
    Platinum,
}

public static class CurrencyExtensions
{
    public static string ToString(this Currency currency)
    {
        return currency switch
        {
            Currency.Copper => "Copper",
            Currency.Silver => "Silver",
            Currency.Electrum => "Electrum",
            Currency.Gold => "Gold",
            Currency.Platinum => "Platinum",
            _ => throw new ArgumentOutOfRangeException(nameof(currency), currency, null)
        };
    }

    public static Currency? FromString(string s)
    {
        return s switch
        {
            "Copper" => Currency.Copper,
            "Silver" => Currency.Silver,
            "Electrum" => Currency.Electrum,
            "Gold" => Currency.Gold,
            "Platinum" => Currency.Platinum,
            _ => (Currency?)null
        };
    }

    public static int ToMultiplier(this Currency currency)
    {
        return currency switch
        {
            Currency.Copper => 1,
            Currency.Silver => 10,
            Currency.Electrum => 50,
            Currency.Gold => 100,
            Currency.Platinum => 1000,
            _ => throw new ArgumentOutOfRangeException(nameof(currency), currency, null)
        };
    }

    public static int? ConvertTo(this Currency fromCurrency, Currency toCurrency, int amount)
    {
        int fromMultiplier = fromCurrency.ToMultiplier();
        int toMultiplier = toCurrency.ToMultiplier();

        int copperAmount = amount * fromMultiplier;
        int convertedAmount = copperAmount / toMultiplier;

        return convertedAmount == 0 ? (int?)null : convertedAmount;
    }
}
