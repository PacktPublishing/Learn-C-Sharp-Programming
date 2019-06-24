using System;
using System.Collections.Generic;
using System.Text;

namespace chapter_05
{
    class CreditCard
    {
        protected double DefaultLimit { get; set; }
        public CreditCard(double defaultLimit)
        {
            DefaultLimit = defaultLimit;
        }
        public virtual double CardLimit()
        {
            return DefaultLimit;
        }
    }

    class GoldCard : CreditCard
    {
        public GoldCard(double cardLimit) : base(cardLimit)
        {

        }
        public override double CardLimit()
        {
            return DefaultLimit + (0.1 * DefaultLimit);
        }
    }

    class PlatinumCard : CreditCard
    {
        public PlatinumCard(double cardLimit) : base(cardLimit)
        {

        }
        public override double CardLimit()
        {
            return DefaultLimit + (0.2 * DefaultLimit);
        }
    }
}
