using EventMatcha.Shared;

namespace EventMatcha.Domain.FAQs
{
    public class FaqsErrors
    {
        public static readonly Error FaqExist = new("Faq.FaqExist", "Faq already exist");
        public static readonly Error FaqNotFound = new("Faq.FaqNotFound", "Faq does not exist");
    }
}
